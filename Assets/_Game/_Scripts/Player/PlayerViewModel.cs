using System;
using R3;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Player
{
    public interface IPlayerViewModel
    {
        public ReadOnlyReactiveProperty<Vector3> MoveDirection { get; }
        public ReadOnlyReactiveProperty<float> MoveSpeed { get; }
        public ReadOnlyReactiveProperty<Quaternion> Rotation { get; }
        public ReadOnlyReactiveProperty<Vector3> Position { get; }
        public ReadOnlyReactiveProperty<float> RotationSpeed { get; }
        public ReactiveProperty<CharacterActionDto> CharacterAction { get; }
        public ReactiveProperty<bool> IsInAction { get; }
        public ReadOnlyReactiveProperty<bool> IsMoving { get; }
        public ReadOnlyReactiveProperty<bool> IsShooting { get; }
        public ReactiveProperty<bool> IsGameStarted { get; }
        public void SetModelPosition(Vector3 value);
        public void SetModelRotation(Quaternion value);
    }

    public class PlayerViewModel : IPlayerViewModel, IDisposable
    {
        public ReadOnlyReactiveProperty<Vector3> Position => _model.Position;
        public ReadOnlyReactiveProperty<Quaternion> Rotation => _model.Rotation;
        public ReadOnlyReactiveProperty<Vector3> MoveDirection => _model.MoveDirection;
        public ReadOnlyReactiveProperty<bool> IsMoving => _model.IsMoving;
        public ReadOnlyReactiveProperty<bool> IsShooting => _model.IsShooting;
        public ReactiveProperty<bool> IsGameStarted => _model.IsGameStarted;
        public ReadOnlyReactiveProperty<float> MoveSpeed => _model.MoveSpeed;
        public ReadOnlyReactiveProperty<float> RotationSpeed => _model.RotationSpeed;

        public ReactiveProperty<CharacterActionDto> CharacterAction { get; } = new();
        public ReactiveProperty<bool> IsInAction { get; } = new(false);

        private IPlayerModel _model;

        [Inject]
        private void Construct(IObjectResolver container) => _model = container.Resolve<IPlayerModel>();

        public void SetModelPosition(Vector3 value) => _model.SetPosition(value);
        public void SetModelRotation(Quaternion value) => _model.SetRotation(value);

        public void Dispose()
        {
            CharacterAction?.Dispose();
            IsInAction?.Dispose();
        }
    }
}
