using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
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

        public override void Initialize()
        {
            Debug.LogWarning("init gameplay view model = " + Model);
            MenuButtonClicked.Subscribe(_ => Model.SetGameState(EGameState.Menu)).AddTo(Disposables);
        }
    }
}
