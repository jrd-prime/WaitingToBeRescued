using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class AmbientTemperatureTimer : SubViewComponentBase<IGameplayViewModel>
    {
        private VisualElement _movementRoot;

        public AmbientTemperatureTimer(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _movementRoot = Root.Q<VisualElement>(UIConst.MovementRootIDName).CheckOnNull();
        }

        protected override void Init()
        {
            _movementRoot.RegisterCallback<PointerDownEvent>(OnPointerDown);
            _movementRoot.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            _movementRoot.RegisterCallback<PointerUpEvent>(OnPointerUp);
            _movementRoot.RegisterCallback<PointerOutEvent>(OnPointerCancel);
        }

        private void OnPointerCancel(PointerOutEvent evt) => ViewModel.OnOutEvent(evt);
        private void OnPointerDown(PointerDownEvent evt) => ViewModel.OnDownEvent(evt);
        private void OnPointerMove(PointerMoveEvent evt) => ViewModel.OnMoveEvent(evt);
        private void OnPointerUp(PointerUpEvent evt) => ViewModel.OnUpEvent(evt);
    }
}
