﻿using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.SubState;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.JrdStateMachine.BaseState
{
    public abstract class GameStateBase<TUIModel, TSubStateEnum> : IGameState, IInitializable
        where TUIModel : IUIModel<TSubStateEnum> where TSubStateEnum : Enum
    {
        protected IGameManager GameManager { get; private set; }
        protected IUIManager UIManager { get; private set; }
        protected readonly Dictionary<TSubStateEnum, ISubState> SubStatesCache = new();

        private TUIModel _model;
        private IPlayerModel _playerModel;
        protected readonly CompositeDisposable Disposables = new();
        private TSubStateEnum _subStateType;
        private ISubState _subState;
        private ISubState CurrentSubState;

        [Inject]
        private void Construct(IGameManager gameManager, IUIManager uiController, IPlayerModel playerModel,
            TUIModel dataModel)
        {
            GameManager = gameManager;
            UIManager = uiController;
            _playerModel = playerModel;
            _model = dataModel;
        }

        public void Initialize()
        {
            if (GameManager == null) throw new NullReferenceException("GameManager is null");
            if (UIManager == null) throw new NullReferenceException("UIManager is null");
            if (_playerModel == null) throw new NullReferenceException("PlayerModel is null");
            if (_model == null) throw new NullReferenceException("DataModel is null");

            InitializeSubStates();
            Subscribe();

            //TODO uncomment
            //if (SubStatesCache.Count == 0) throw new Exception("SubStates is empty. You need to add substates." + this);

            if (Enum.GetNames(typeof(TSubStateEnum)).Length != SubStatesCache.Count)
                Debug.LogWarning(
                    $"<color=red>[{GetType().Name} / SUB STATES] Initialized substates: {SubStatesCache.Count} but should be {Enum.GetNames(typeof(TSubStateEnum)).Length}</color>");
        }

        private void Subscribe()
        {
            InitBaseSubscribes();
            InitCustomSubscribes();
        }

        private void InitBaseSubscribes()
        {
        }

        public void Enter()
        {
            Debug.LogWarning(
                $"<color=darkblue>[ENTER BASE]</color> {GetType().Name} (SubStates: {SubStatesCache.Count} / Disp: {Disposables.Count})");
            OnBaseStateEnter();

            if (!SubStatesCache.TryGetValue(_subStateType, out _subState))
                throw new KeyNotFoundException($"SubState: {_subStateType} not found! Base state: {GetType().Name}");

            _subState.Enter();
            CurrentSubState = _subState;
        }

        public void Exit()
        {
            CurrentSubState.Exit();
            CurrentSubState = null;
            OnBaseStateExit();
            Debug.LogWarning($"<color=darkblue>[EXIT BASE]</color> {GetType().Name}");
        }

        public void ChangeSubState(Enum stateDataSubState)
        {
            var subState = stateDataSubState == null ? default : (TSubStateEnum)stateDataSubState;
            if (subState == null) throw new NullReferenceException("SubState is null.");

            Debug.LogWarning(
                "<color=darkblue>[CHANGE SUB]</color> To " + subState + " from " + CurrentSubState);
            CurrentSubState?.Exit();

            CurrentSubState = SubStatesCache[subState];
            SubStatesCache[subState].Enter();
        }

        /// <summary>
        /// Initialize SubStates and add to cache <see cref="SubStatesCache"/>
        /// </summary>
        protected abstract void InitializeSubStates();

        protected abstract void InitCustomSubscribes();
        protected abstract void OnBaseStateEnter();
        protected abstract void OnBaseStateExit();
    }

    public struct StateData
    {
        public EGameState State;
        public Enum SubState;

        public StateData(EGameState baseState, Enum oSubState = default)
        {
            State = baseState;
            SubState = oSubState;
        }
    }
}
