﻿using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Managers.Game;
using R3;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base
{
    public abstract class UIModelBase : IInitializable
    {
        protected StateMachine StateMachine { get; private set; }
        protected UIManager UIManager { get; private set; }
        protected IObjectResolver Container { get; private set; }
        protected GameManager GameManager { get; private set; }

        protected readonly CompositeDisposable Disposables = new();

        [Inject]
        private void Construct(StateMachine stateMachine, UIManager uiManager, IObjectResolver container)
        {
            StateMachine = stateMachine;
            UIManager = uiManager;
            Container = container;
            GameManager = Container.Resolve<GameManager>();
        }

        public abstract void Initialize();
    }
}
