using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Base.ViewModel;
using _Game._Scripts.UI.Menu.Base;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Gameplay
{
    public class GameplayViewModel : UIViewModelBase<IGameplayModel, EGameplaySubState>, IGameplayViewModel
    {
        public Subject<Unit> MenuButtonClicked { get; } = new();

        public ReadOnlyReactiveProperty<int> PlayerHealth { get; }

        public ReadOnlyReactiveProperty<int> PlayerInitialHealth { get; }

        public ReadOnlyReactiveProperty<bool> IsTouchPositionVisible { get; }

        public ReadOnlyReactiveProperty<Vector2> RingPosition { get; }

        public void OnDownEvent(PointerDownEvent evt)
        {
            throw new System.NotImplementedException();
        }

        public void OnMoveEvent(PointerMoveEvent evt)
        {
            throw new System.NotImplementedException();
        }

        public void OnUpEvent(PointerUpEvent evt)
        {
            throw new System.NotImplementedException();
        }

        public void OnOutEvent(PointerOutEvent evt)
        {
            throw new System.NotImplementedException();
        }
        // public ReadOnlyReactiveProperty<int> PlayerHealth => Model.PlayerHealth;

        // public ReadOnlyReactiveProperty<int> PlayerInitialHealth => Model.PlayerInitialHealth;

        // public ReadOnlyReactiveProperty<int> KillCount => Model.KillCount;
        // public ReadOnlyReactiveProperty<int> KillToWin => Model.KillToWin;
        // public ReadOnlyReactiveProperty<int> EnemiesCount => Model.EnemiesCount;
        // public ReadOnlyReactiveProperty<int> Experience => Model.Experience;
        // public ReadOnlyReactiveProperty<int> Level => Model.Level;
        // public ReadOnlyReactiveProperty<int> ExpToNextLevel => Model.ExperienceToNextLevel;
        // public ReadOnlyReactiveProperty<bool> IsTouchPositionVisible => Model.IsTouchPositionVisible;
        // public ReadOnlyReactiveProperty<Vector2> RingPosition => Model.RingPosition;

        // public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        // public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        // public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        // public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);

        public override void Initialize()
        {
            // MenuButtonClicked.Subscribe(_ => Model.MenuButtonClicked()).AddTo(Disposables);
        }
    }
}
