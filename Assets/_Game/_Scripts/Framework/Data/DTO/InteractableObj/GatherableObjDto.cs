using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Framework.Data.DTO.InteractableObj
{
    public struct GatherableObjDto : IInteractObjectDto
    {
        public InGameObjectSettings Settings { get; set; }
    }
}
