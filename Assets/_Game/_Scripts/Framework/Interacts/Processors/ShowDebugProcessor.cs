using System;
using _Game._Scripts.Framework.Data.SO.Obj.InWorld;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.Processors
{
    [UsedImplicitly]
    public class ShowDebugProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Show Debug";

        public override void Process(InWorldObjectSO objSO, EInteractState interactState)
        {
            if (objSO is null) throw new ArgumentNullException(nameof(objSO));

            Debug.LogWarning($"dbg: {objSO.GetType().Name}");
            objSO.ShowDebug();


            base.Process(objSO, interactState);
        }
    }
}
