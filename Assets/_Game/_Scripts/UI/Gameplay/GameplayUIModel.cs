using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UI.MovementControl.FullScreen;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Gameplay
{
    public class GameplayModel : CustomUIModelBase<GameplaySubStateType>, IGameplayModel
    {
        public ReadOnlyReactiveProperty<int> PlayerHealth => GameManager.PlayerHealth;

        public ReadOnlyReactiveProperty<int> PlayerInitialHealth => GameManager.PlayerInitialHealth;


        public void MenuButtonClicked()
        {
        }

        // MenuButtonsHandler.MenuButtonClicked();


        public ReactiveProperty<bool> IsTouchPositionVisible => _movementModel.IsTouchPositionVisible;
        public ReactiveProperty<Vector2> RingPosition => _movementModel.RingPosition;

        private IFullScreenMovementModel _movementModel;

        public override void Initialize()
        {
            _movementModel = ResolverHelp.ResolveAndCheck<IFullScreenMovementModel>(Container);
        }

        public void OnDownEvent(PointerDownEvent evt) => _movementModel.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => _movementModel.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent _) => _movementModel.OnUpEvent(_);
        public void OnOutEvent(PointerOutEvent _) => _movementModel.OnOutEvent(_);
        public ReactiveProperty<EGameplaySubState> CurrentSubState { get; }
    }

    public enum GameplaySubStateType
    {
    }
}
