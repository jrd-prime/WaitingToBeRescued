using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    /// <summary>
    /// If conditions are not met, show conditions require UI
    /// </summary>
    [UsedImplicitly]
    public class CollectUnavailableShowUIProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSO objSO, EInteractState state)
        {
            if (objSO is CollectableSO settings && state == EInteractState.NotEnoughForCollect)
            {
                Debug.LogWarning("NOT ENOUGH FOR COLLECT UI INFO");
                return;
            }

            base.Process(objSO, state);
        }
    }
}
