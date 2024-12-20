using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interact.Character;

namespace _Game._Scripts.Framework.Data.DTO.InteractableObj
{
    public struct CollectableObjDto : IReturns
    {
        public LootableObjReturnsDto Returns { get; }

        public CollectableObjDto(CollectableObjSettings settings)
        {
            Returns = settings.objReturnsDto;
        }

        public void ShowDebug() => Returns.ShowDebug();
    }
}
