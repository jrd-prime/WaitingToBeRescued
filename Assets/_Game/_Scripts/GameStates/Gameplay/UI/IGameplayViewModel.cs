using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public interface IGameplayViewModel : IUIViewModel
    {
        public Subject<Unit> MenuButtonClicked { get; }
    }
}
