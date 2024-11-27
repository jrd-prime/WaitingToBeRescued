using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Base
{
    public interface IGameplayViewModel : IUIViewModel
    {
        public Subject<Unit> MenuBtnClicked { get; }
        public Subject<Unit> CloseBtnClicked { get; }
        public ReadOnlyReactiveProperty<ShelterEnergyDto> ShelterEnergyData { get; }

        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent evt);
        public void OnOutEvent(PointerOutEvent evt);
    }
}
