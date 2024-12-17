using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Framework.Data.DTO.InteractableObj
{
    public struct PickableObjDto : IInteractObjectDto
    {
        public InGameObjectSettings Settings { get; set; }
    }
}
