using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public interface IGameplayViewModel : IUIViewModel
    {
        public Subject<Unit> MenuButtonClicked { get; }
        public ReadOnlyReactiveProperty<int> PlayerHealth { get; }
        public ReadOnlyReactiveProperty<int> PlayerInitialHealth { get; }

        // public ReadOnlyReactiveProperty<int> KillCount => Model.KillCount;
        // public ReadOnlyReactiveProperty<int> KillToWin => Model.KillToWin;
        // public ReadOnlyReactiveProperty<int> EnemiesCount => Model.EnemiesCount;
        // public ReadOnlyReactiveProperty<int> Experience => Model.Experience;
        // public ReadOnlyReactiveProperty<int> Level => Model.Level;
        // public ReadOnlyReactiveProperty<int> ExpToNextLevel => Model.ExperienceToNextLevel;
        public ReadOnlyReactiveProperty<bool> IsTouchPositionVisible { get; }
        public ReadOnlyReactiveProperty<Vector2> RingPosition { get; }

        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent evt);
        public void OnOutEvent(PointerOutEvent evt);
    }
}
