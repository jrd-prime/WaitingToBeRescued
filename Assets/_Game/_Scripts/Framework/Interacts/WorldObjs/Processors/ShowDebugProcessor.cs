using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Item._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class ShowDebugProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings objSettings, EInteractState interactState)
        {
            if (objSettings is null) throw new ArgumentNullException(nameof(objSettings));

            Debug.LogWarning($"dbg: {objSettings.GetType().Name}");
            objSettings.ShowDebug();


            base.Process(objSettings, interactState);
        }
    }
}
