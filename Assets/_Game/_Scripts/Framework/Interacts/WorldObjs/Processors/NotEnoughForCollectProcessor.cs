using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using UnityEngine;

namespace _Game._Scripts.Item._Base
{
    public class NotEnoughForCollectProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings objSettings, EInteractState state)
        {
            if (objSettings is CollectableObjSettings settings && state == EInteractState.NotEnoughForCollect)
            {
                Debug.LogWarning("NOT ENOUGH FOR COLLECT UI INFO");
                return;
            }
            
            base.Process(objSettings, state);
        }
    }
}
