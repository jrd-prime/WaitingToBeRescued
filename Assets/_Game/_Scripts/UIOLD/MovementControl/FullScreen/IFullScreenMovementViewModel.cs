using R3;
using UnityEngine;

namespace _Game._Scripts.UIOLD.MovementControl.FullScreen
{
    public interface IFullScreenMovementViewModel : IMovementControlViewModel
    {
        public ReadOnlyReactiveProperty<bool> IsTouchPositionVisible { get; }
        public ReadOnlyReactiveProperty<Vector2> RingPosition { get; }
    }
}
