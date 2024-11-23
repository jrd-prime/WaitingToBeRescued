using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.UI;
using R3;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.Model
{
    public abstract class UIModelBase
    {
        protected IUIManager UIManager { get; private set; }
        protected IObjectResolver Container { get; private set; }
        protected IGameManager GameManager { get; private set; }

        protected readonly CompositeDisposable Disposables = new();

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            Container = resolver;
            UIManager = Container.Resolve<IUIManager>();
            GameManager = Container.Resolve<IGameManager>();
        }
    }

    public abstract class CustomUIModelBase<TSubStateEnum> : UIModelBase, IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
        public abstract void Initialize();
        public ReactiveProperty<TSubStateEnum> CurrentSubState { get; } = new();
        public ReactiveProperty<EGameState> GameState { get; } = new();
    }

    public interface IUIModel<TSubStateEnum> : IInitializable where TSubStateEnum : Enum
    {
        public ReactiveProperty<TSubStateEnum> CurrentSubState { get; }
        public ReactiveProperty<EGameState> GameState { get; }

        public void SetSubState(TSubStateEnum menuSubStateType) => CurrentSubState.Value = menuSubStateType;
        public void SetGameState(EGameState eGameState) => GameState.Value = eGameState;
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
