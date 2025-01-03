using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
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
            if (objSO is UsableSO && interactState == EInteractState.EnoughForUse)
            {
                Debug.LogWarning("Settings is UsableSO or UsableWithConditionsSO and interactState is EnoughForUse");
            }

            base.Process(objSO, interactState);
        }
    }
}
