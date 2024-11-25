using System;
using _Game._Scripts.Framework.Data.Enums.States;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.Model
{
    public interface IUIModel<TSubStateEnum> : IInitializable where TSubStateEnum : Enum
    {
        public ReactiveProperty<TSubStateEnum> SubState { get; }
        public ReactiveProperty<EGameState> GameState { get; }

        public void SetSubState(TSubStateEnum menuSubStateType)
        {
            Debug.LogWarning($"<color=yellow>[Set SUB State]</color> {menuSubStateType} . Current: {SubState.Value}");
            SubState.Value = menuSubStateType;
        }

        public void SetGameState(EGameState eGameState)
        {
            Debug.LogWarning(
                $"<color=darkblue>[Set BASE State]</color> {eGameState}. Current: {GameState.CurrentValue}");
            if (GameState.CurrentValue == eGameState)
            {
                GameState.ForceNotify();
                return;
            }

            GameState.Value = eGameState;
        }
    }

    public interface IMenuModel : IUIModel<EMenuSubState>
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
