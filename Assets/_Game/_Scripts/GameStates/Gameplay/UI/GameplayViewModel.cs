using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public class GameplayViewModel : UIViewModelBase<IGameplayModel, EGameplaySubState>, IGameplayViewModel
    {
        public Subject<Unit> MenuBtnClicked { get; } = new();
        public Subject<Unit> CloseBtnClicked { get; } = new();
        public ReadOnlyReactiveProperty<ShelterEnergyDto> ShelterEnergyData => Model.ShelterEnergyData;


        public override void Initialize()
        {
            MenuBtnClicked
                .Subscribe(_ => Model.SetGameState(new StateData(EGameState.Menu)))
                .AddTo(Disposables);

            CloseBtnClicked
                .Subscribe(_ => Model.SetPreviousState())
                .AddTo(Disposables);
        }

        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);
    }
}
