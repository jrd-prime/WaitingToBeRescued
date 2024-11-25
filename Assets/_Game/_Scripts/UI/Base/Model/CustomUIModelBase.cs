using System;
using _Game._Scripts.Framework.Data.Enums.States;
using R3;

namespace _Game._Scripts.UI.Base.Model
{
    public abstract class CustomUIModelBase<TSubStateEnum> : UIModelBase, IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
        public abstract void Initialize();
        public ReactiveProperty<TSubStateEnum> SubState { get; } = new();
        public ReactiveProperty<EGameState> GameState { get; } = new();
    }
}
