using UnityEngine.UIElements;

namespace _Game._Scripts.UIOLD.MovementControl
{
    public interface IMovementControlViewModel
    {
        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent evt);
        public void OnOutEvent(PointerOutEvent evt);
    }
}
