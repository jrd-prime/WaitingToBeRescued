using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.MovementControl;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public interface IGameplayModel : IUIModel<EGameplaySubState>
    {
        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent _);
        public void OnOutEvent(PointerOutEvent _);
        public ReadOnlyReactiveProperty<ShelterEnergyDto> ShelterEnergyData { get; }
    }

    public class GameplayModel : CustomUIModelBase<EGameplaySubState>, IGameplayModel
    {
        public ReadOnlyReactiveProperty<ShelterEnergyDto> ShelterEnergyData => _shelterEnergyModel.ModelData;

        public ReadOnlyReactiveProperty<AmbientTempDTO> AmbientTempData => _ambientTempModel.ModelData;

        private IMovementControlModel _movementModel;
        private ShelterEnergyModel _shelterEnergyModel;
        private AmbientTemperatureModel _ambientTempModel;

        public override void Initialize()
        {
            _movementModel = ResolverHelp.ResolveAndCheck<IMovementControlModel>(Resolver);
            _shelterEnergyModel = ResolverHelp.ResolveAndCheck<ShelterEnergyModel>(Resolver);
            _ambientTempModel = ResolverHelp.ResolveAndCheck<AmbientTemperatureModel>(Resolver);
        }

        public void OnDownEvent(PointerDownEvent evt) => _movementModel.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => _movementModel.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent _) => _movementModel.OnUpEvent(_);
        public void OnOutEvent(PointerOutEvent _) => _movementModel.OnOutEvent(_);
    }
}
