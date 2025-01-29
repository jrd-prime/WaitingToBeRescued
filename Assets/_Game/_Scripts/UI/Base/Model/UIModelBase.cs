﻿using _Game._Scripts.Framework.JStateMachine;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.UI;
using R3;
using VContainer;

namespace _Game._Scripts.UI.Base.Model
{
    public abstract class UIModelBase
    {
        protected IUIManager UIManager { get; private set; }
        protected IObjectResolver Resolver { get; private set; }
        protected IGameManager GameManager { get; private set; }
        protected IStateMachineReactiveAdapter _ra { get; private set; }

        protected readonly CompositeDisposable Disposables = new();

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            Resolver = resolver;
            UIManager = Resolver.Resolve<IUIManager>();
            GameManager = Resolver.Resolve<IGameManager>();
            _ra = Resolver.Resolve<IStateMachineReactiveAdapter>();
        }
    }
}
