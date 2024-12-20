using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.Enums;

namespace _Game._Scripts.Framework.Interact.Character
{
    public interface IInteractObjectDto
    {
        public void ShowDebug();
    }

    public interface IRequirements : IInteractObjectDto
    {
        LootableObjRequirementsDto Requirements { get; }
    }

    public interface IReturns : IInteractObjectDto
    {
        LootableObjReturnsDto Returns { get; }
    }

    public interface IInteracts : IInteractObjectDto
    {
        public EInteract Interact { get; }
    }
}
