using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Interact.Character._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Interact.Character.Processors
{
    public class GatherProcessor : CharacterInteractProcessorBase
    {
        public override void Process(IInteractObjectDto objDto)
        {
            if (objDto is GatherableObjDto)
            {
                Debug.LogWarning("obj is Gatherable!!");
            }

            base.Process(objDto);
        }
    }
}
