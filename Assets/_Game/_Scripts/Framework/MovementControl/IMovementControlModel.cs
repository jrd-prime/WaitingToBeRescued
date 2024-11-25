using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.MovementControl
{
    public interface IMovementControlModel
    {
        public ReactiveProperty<Vector3> MoveDirection { get; }
        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent evt);
        public void OnOutEvent(PointerOutEvent evt);
    }
}
