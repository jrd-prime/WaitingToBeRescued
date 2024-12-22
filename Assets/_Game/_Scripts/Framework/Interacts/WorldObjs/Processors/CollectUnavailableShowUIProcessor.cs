using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsBehaviour;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings;
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
        public override void Process(InGameObjectSettings objSettings, EInteractState state)
        {
            if (objSettings is CollectableSettings settings && state == EInteractState.NotEnoughForCollect)
            {
                Debug.LogWarning("NOT ENOUGH FOR COLLECT UI INFO");
                return;
            }

            base.Process(objSettings, state);
        }
    }
}
