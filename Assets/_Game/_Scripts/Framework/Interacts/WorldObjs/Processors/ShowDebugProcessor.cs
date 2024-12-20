using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class ShowDebugProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings settings)
        {
            if (settings is null) throw new ArgumentNullException(nameof(settings));

            Debug.LogWarning($"dbg: {settings.GetType().Name}");
            settings.ShowDebug();


            base.Process(settings);
        }
    }
}
