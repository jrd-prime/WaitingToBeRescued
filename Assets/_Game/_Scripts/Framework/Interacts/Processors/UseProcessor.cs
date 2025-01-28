using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.Processors
{
    [UsedImplicitly]
    public class UseProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Use Processor";

        [Inject]
        private void Construct()
        {
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (objSO is UsableSO && interactState is EInteractState.EnoughForUse)
            {
                Debug.LogWarning("Use!");
            }

            base.Process(objSO, interactState);
        }
    }
}
