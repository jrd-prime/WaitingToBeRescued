using R3;
using UnityEngine;

namespace _Game._Scripts.UI.MovementControl
{
    public interface IMovementControlModel
    {
        public ReactiveProperty<Vector3> MoveDirection { get; }
    }
}
