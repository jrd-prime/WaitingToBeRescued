using _Game._Scripts.Framework.Data.SO.Item;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj
{
    public struct CollectableWithConditionsDto : ICollectableWithConditions
    {
        public CollectableObjSettings Collectables { get; }
        public CollectableObjWithConditionsSettings Conditions { get; }

        public CollectableWithConditionsDto(CollectableObjWithConditionsSettings settings)
        {
            Collectables = null;
            Conditions = null;
        }

        public void ShowDebug()
        {
            Collectables.ShowDebug();
            Conditions.ShowDebug();
        }
    }
}
