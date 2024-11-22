﻿using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Gameplay
{
    public class GameplayViewModel : CustomUIViewModel<IGameplayUIModel>, IGameplayViewModel
    {
        public Subject<Unit> MenuButtonClicked { get; } = new();
        public ReadOnlyReactiveProperty<int> PlayerHealth => Model.PlayerHealth;

        public ReadOnlyReactiveProperty<int> PlayerInitialHealth => Model.PlayerInitialHealth;

        // public ReadOnlyReactiveProperty<int> KillCount => Model.KillCount;
        // public ReadOnlyReactiveProperty<int> KillToWin => Model.KillToWin;
        // public ReadOnlyReactiveProperty<int> EnemiesCount => Model.EnemiesCount;
        // public ReadOnlyReactiveProperty<int> Experience => Model.Experience;
        // public ReadOnlyReactiveProperty<int> Level => Model.Level;
        // public ReadOnlyReactiveProperty<int> ExpToNextLevel => Model.ExperienceToNextLevel;
        public ReadOnlyReactiveProperty<bool> IsTouchPositionVisible => Model.IsTouchPositionVisible;
        public ReadOnlyReactiveProperty<Vector2> RingPosition => Model.RingPosition;

        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);

        public override void Initialize()
        {
            MenuButtonClicked.Subscribe(_ => Model.MenuButtonClicked()).AddTo(Disposables);
        }
    }
}
