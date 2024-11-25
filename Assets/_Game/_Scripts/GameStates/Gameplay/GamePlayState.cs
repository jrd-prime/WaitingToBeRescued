using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.GameStates.Gameplay.SubState;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;

namespace _Game._Scripts.GameStates.Gameplay
{
    public sealed class GamePlayState : GameStateBase<IGameplayModel, EGameplaySubState>
    {
        protected override void InitializeSubStates()
        {
            SubStatesCache.TryAdd(EGameplaySubState.Main,
                new GameplayMainSubState(UIManager, EGameState.Gameplay, EGameplaySubState.Main));
        }

        protected override void InitCustomSubscribes()
        {
        }

        protected override void OnBaseStateEnter()
        {
        }

        protected override void OnBaseStateExit()
        {
        }

    }
}
