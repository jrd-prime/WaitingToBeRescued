using System;
using _Game._Scripts.UIOLD;
using R3;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.Model
{
    public interface IUIModel<TSubStateEnum> : IInitializable where TSubStateEnum : Enum
    {
        public ReactiveProperty<TSubStateEnum> CurrentSubState { get; }
        public ReactiveProperty<GameStateType> GameState { get; }

        public  void SetSubState(TSubStateEnum menuSubStateType) => CurrentSubState.Value = menuSubStateType;
        public  void SetGameState(GameStateType gameStateType) => GameState.Value = gameStateType;
    }
}
