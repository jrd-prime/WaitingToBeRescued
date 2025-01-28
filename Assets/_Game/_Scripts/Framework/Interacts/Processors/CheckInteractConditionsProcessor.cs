using System;
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
    public class CheckInteractConditionsProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Collect With Condition Processor";

        [Inject]
        private void Construct()
        {
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            Debug.LogWarning("--- Check Interact Conditions Processor");

            if (interactState is not EInteractState.Start) throw new Exception("InteractState is not Start!");

            interactState = objSO switch
            {
                UsableWithConditionsSO useSettings => CheckUseConditions(useSettings),
                CollectableWithConditionsSO collectSettings => CheckCollectConditions(collectSettings),
                UsableSO => EInteractState.EnoughForUse,
                CollectableSO => EInteractState.EnoughForCollect,
                _ => throw new Exception("objSO is not CollectableSO or UsableSO")
            };

            base.Process(objSO, interactState);
        }

        private EInteractState CheckCollectConditions(CollectableWithConditionsSO collectSettings)
        {
            var conditions = PlayerDataManager.CheckCollectConditions(collectSettings.collectionConditions);
            Debug.LogWarning($"USE conditions: {conditions}");

            return conditions ? EInteractState.EnoughForCollect : EInteractState.NotEnoughForCollect;
        }

        private EInteractState CheckUseConditions(UsableWithConditionsSO useSettings)
        {
            var conditions = PlayerDataManager.CheckUseConditions(useSettings.useConditions);
            Debug.LogWarning($"COLLECT conditions: {conditions}");

            return conditions ? EInteractState.EnoughForUse : EInteractState.NotEnoughForUse;
        }
    }
}
