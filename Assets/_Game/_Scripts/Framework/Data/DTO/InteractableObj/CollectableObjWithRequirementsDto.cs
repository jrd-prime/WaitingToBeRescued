using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interact.Character;

namespace _Game._Scripts.Framework.Data.DTO.InteractableObj
{
    public struct CollectableObjWithRequirementsDto : IReturns, IRequirements
    {
        public LootableObjReturnsDto Returns { get; }
        public LootableObjRequirementsDto Requirements { get; }

        public CollectableObjWithRequirementsDto(CollectableObjWithRequirementsSettings settings)
        {
            Returns = settings.objReturnsDto;
            Requirements = settings.objRequirementsDto;
        }

        public void ShowDebug()
        {
            Returns.ShowDebug();
            Requirements.ShowDebug();
        }
    }
}
