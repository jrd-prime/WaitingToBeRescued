using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    /// <summary>
    /// If settings = UsableWithConditionsSO and interactState = Start, check conditions
    /// </summary>
    [UsedImplicitly]
    public class UseWithConditionProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Use With Condition Processor";

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (objSO is UsableWithConditionsSO settings && interactState == EInteractState.Start)
            {
                var conditions = PlayerDataManager.CheckUseConditions(settings.useConditions);
                
                Debug.LogWarning($"USE conditions: {conditions}");
                
                interactState = conditions ? EInteractState.EnoughForUse : EInteractState.NotEnoughForUse;
                
            }

            base.Process(objSO, interactState);
        }
    }
}
