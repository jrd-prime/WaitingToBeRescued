using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Obj.InWorld;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.Processors
{
    [UsedImplicitly]
    public class CheckInteractConditionsProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Collect With Condition Processor";

        public override void Process(InWorldObjectSO objSO, EInteractState interactState)
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

//TODO refact
        private EInteractState CheckCollectConditions(CollectableWithConditionsSO collectSettings)
        {
            var conditions =
                StuffDataManager.CheckCollectConditions(collectSettings.collectConditions, out var missingStuff);
            Debug.LogWarning($"USE missingStuff count: {missingStuff.Count} / conditions: {conditions}");

            return conditions ? EInteractState.EnoughForCollect : EInteractState.NotEnoughForCollect;
        }

        private EInteractState CheckUseConditions(UsableWithConditionsSO useSettings)
        {
            var conditions = StuffDataManager.CheckUseConditions(useSettings.useConditions, out var missingStuff);
            Debug.LogWarning($"COLLECT missingStuff count: {missingStuff.Count} / conditions: {conditions}");

            return conditions ? EInteractState.EnoughForUse : EInteractState.NotEnoughForUse;
        }
    }
}
