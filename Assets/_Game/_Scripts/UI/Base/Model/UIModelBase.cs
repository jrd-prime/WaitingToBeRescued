using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.UI;
using R3;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.Model
{
    public abstract class UIModelBase : IInitializable
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

        public abstract void Initialize();
    }
}
