﻿using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine._Base;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.State.SubState;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI;

namespace _Game._Scripts.Framework.JStateMachine.State.Gameplay.State
{
    public sealed class GamePlayState : GameStateBase<IGameplayModel, EGameplaySubState>
    {
        protected override void InitializeSubStates()
        {
            SubStatesCache.TryAdd(EGameplaySubState.Main,
                new GameplayMainSubState(UIManager, EGameState.Gameplay, EGameplaySubState.Main));
            SubStatesCache.TryAdd(EGameplaySubState.ShelterMenu,
                new GameplayShelterMenuSubState(UIManager, EGameState.Gameplay, EGameplaySubState.ShelterMenu));
        }

        protected override void InitCustomSubscribes()
        {
        }

        protected override void OnBaseStateEnter()
        {
            ShowMove();
            GameManager.StartNewGame();
        }

        protected override void OnBaseStateExit()
        {
            HideMove();
            GameManager.Pause();
        }
    }
}
