﻿using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine.Data;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI;
using R3;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Shelter
{
    public class ShelterModel : IInteractableModel, IInitializable
    {
        public readonly ReactiveProperty<EGameplaySubState> GameplaySubState = new();
        private IGameplayModel _gameplayModel;

        [Inject]
        private void Construct(IGameplayModel gameplayModel)
        {
            _gameplayModel = gameplayModel;
        }

        public void InteractOnEnter()
        {
            // show ui
            _gameplayModel.SetGameState(new StateData(EGameState.Gameplay, EGameplaySubState.ShelterMenu));
        }

        public void InteractOnStay()
        {
            // dance
        }

        public void InteractOnExit()
        {
            // hide ui
            _gameplayModel.SetGameState(new StateData(EGameState.Gameplay, EGameplaySubState.Main));
        }

        public void Initialize()
        {
        }
    }
}
