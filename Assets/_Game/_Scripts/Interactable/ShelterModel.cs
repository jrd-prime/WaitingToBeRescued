using _Game._Scripts.Framework.Data.Enums.States;
using R3;
using VContainer.Unity;

namespace _Game._Scripts.Interactable
{
    public class ShelterModel : IInteractableModel, IInitializable
    {
        public readonly ReactiveProperty<EGameplaySubState> GameplaySubState = new();

        public void InteractOnEnter()
        {
            // show ui
            GameplaySubState.Value = EGameplaySubState.ShelterMenu;
        }

        public void InteractOnStay()
        {
            // dance
        }

        public void InteractOnExit()
        {
            // hide ui
        }

        public void Initialize()
        {
        }
    }
}
