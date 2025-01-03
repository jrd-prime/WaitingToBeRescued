using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Item._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class ShowDebugProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (objSO is null) throw new ArgumentNullException(nameof(objSO));

            Debug.LogWarning($"dbg: {objSO.GetType().Name}");
            objSO.ShowDebug();


            base.Process(objSO, interactState);
        }
    }
}
