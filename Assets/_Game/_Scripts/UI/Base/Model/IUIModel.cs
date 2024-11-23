using System;
using _Game._Scripts.Framework.Data.Enums.States;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.Model
{
    public interface IUIModel<TSubStateEnum> : IInitializable where TSubStateEnum : Enum
    {
        public ReactiveProperty<TSubStateEnum> CurrentSubState { get; }
        public ReactiveProperty<EGameState> GameState { get; }

        public void SetSubState(TSubStateEnum menuSubStateType)
        {
            Debug.LogWarning("<color=yellow>SetSubState property</color> " + menuSubStateType);
            CurrentSubState.Value = menuSubStateType;
        }

        public void SetGameState(EGameState eGameState)
        {
            Debug.LogWarning("<color=yellow>SetGameState property</color> " + eGameState);
            GameState.Value = eGameState;
        }
    }

    public interface IMenuModel : IUIModel<EMenuSubState>
    {
    }

    public interface IGameplayModel : IUIModel<EGameplaySubState>
    {
    }

    public interface IGameoverModel : IUIModel<EGameoverSubState>
    {
    }

    public interface IPauseModel : IUIModel<EPauseSubState>
    {
    }

    public interface IWinModel : IUIModel<EWinSubState>
    {
    }
}
