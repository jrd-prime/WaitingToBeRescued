using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers.Extensions;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.Framework.MovementControl
{
    [RequireComponent(typeof(UIDocument))]
    public class MovementUIController : MonoBehaviour
    {
        private VisualElement root;
        private VisualElement _movementRoot;
        private IMovementControlModel ViewModel;

        [Inject]
        private void Construct(IMovementControlModel movementControlViewModel)
        {
            ViewModel = movementControlViewModel;
        }

        private void Awake()
        {
            root = GetComponent<UIDocument>().rootVisualElement ?? throw new NullReferenceException("Root is null");

            root.style.display = DisplayStyle.None;
            _movementRoot = root.Q<VisualElement>(UIConst.MovementRootIDName).CheckOnNull();
            _movementRoot.RegisterCallback<PointerDownEvent>(OnPointerDown);
            _movementRoot.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            _movementRoot.RegisterCallback<PointerUpEvent>(OnPointerUp);
            _movementRoot.RegisterCallback<PointerOutEvent>(OnPointerCancel);
        }


        private void OnDestroy()
        {
            _movementRoot.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            _movementRoot.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            _movementRoot.UnregisterCallback<PointerUpEvent>(OnPointerUp);
            _movementRoot.UnregisterCallback<PointerOutEvent>(OnPointerCancel);
        }

        private void Start()
        {
            if (ViewModel == null) throw new NullReferenceException("ViewModel is null");
        }


        private void OnPointerCancel(PointerOutEvent evt)
        {
            ViewModel.OnOutEvent(evt);
        }

        private void OnPointerDown(PointerDownEvent evt)
        {
            ViewModel.OnDownEvent(evt);
        }

        private void OnPointerMove(PointerMoveEvent evt)
        {
            ViewModel.OnMoveEvent(evt);
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            ViewModel.OnUpEvent(evt);
        }

        public void Show()
        {
            root.style.display = DisplayStyle.Flex;
        }

        public void Hide()
        {
            root.style.display = DisplayStyle.None;
        }
    }
}
