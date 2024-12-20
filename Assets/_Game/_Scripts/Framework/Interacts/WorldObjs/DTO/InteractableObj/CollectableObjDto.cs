using _Game._Scripts.Framework.Data.SO.Item;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj
{
    public struct CollectableDto : ICollectable
    {
        public CollectableObjSettings Collectables { get; }

        public CollectableDto(CollectableObjSettings settings)
        {
            Collectables = null;
        }

        public void ShowDebug() => Collectables.ShowDebug();
    }
}
