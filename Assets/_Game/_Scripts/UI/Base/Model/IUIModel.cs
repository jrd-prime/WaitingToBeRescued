using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine.Data;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.Model
{
    public interface IUIModel<TSubStateEnum> : IInitializable where TSubStateEnum : Enum
    {
        public void SetGameState(StateData stateData);

        public void SetPreviousState();
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
