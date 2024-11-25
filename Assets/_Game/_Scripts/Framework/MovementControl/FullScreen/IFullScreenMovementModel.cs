using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.MovementControl.FullScreen
{
    public interface IFullScreenMovementModel : IMovementControlModel
    {
        public ReactiveProperty<bool> IsTouchPositionVisible { get; }
        public ReactiveProperty<Vector2> RingPosition { get; }

    }
}
