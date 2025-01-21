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
    public class CollectWithConditionProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Collect With Condition Processor";


        [Inject]
        private void Construct()
        {
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (objSO is CollectableWithConditionsSO settings &&
                interactState == EInteractState.Start)
            {
                var conditions = PlayerDataManager.CheckCollectConditions(settings.collectionConditions);

                Debug.LogWarning($"COLLECT conditions: {conditions}");

                interactState = conditions ? EInteractState.EnoughForCollect : EInteractState.NotEnoughForCollect;
            }

            base.Process(objSO, interactState);
        }
    }
}
