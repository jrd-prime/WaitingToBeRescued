using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO;

namespace _Game._Scripts.Framework.Interacts.WorldObjs
{
    public interface IWorldObjectDto
    {
        public void ShowDebug();
    }


    public interface IInteractable : IWorldObjectDto
    {
        public EInteract Interact { get; }
    }

    public interface IInteractableWithConditions : IInteractable, IConditions<CollectableObjWithRequirementsSettings>
    {
    }

    public struct InteractableObjConditionsDto
    {
    }


    public interface ICollectable : IWorldObjectDto
    {
        CollectableObjSettings Collectables { get; }
    }

    public interface ICollectableWithConditions : ICollectable, IConditions<CollectableObjWithRequirementsSettings>
    {
    }


    public interface IConditions<TConditions> : IWorldObjectDto where TConditions : InGameObjectSettings
    {
        public TConditions Conditions { get; }
    }
}
