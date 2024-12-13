using _Game._Scripts.Framework.Data.SO.Game;
using _Game._Scripts.Framework.Manager;
using R3;

namespace _Game._Scripts.Player.Interfaces
{
    public interface IPlayerModel : IMovableModel, ITrackableModel
    {
        public ReactiveProperty<int> Health { get; }
        public CharacterSettings CharSettings { get; }
        public ReactiveProperty<bool> IsShooting { get; }
        public void SetHealth(int health);
        public void TakeDamage(int damage);
        public void ResetPlayer();
        public ReactiveProperty<bool> IsGameStarted { get; }
        public void SetGameStarted(bool value);
    }
}
