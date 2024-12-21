using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Item._Base;
using _Game._Scripts.Player.Data;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class CollectWithConditionProcessor : CharacterInteractProcessorBase
    {
        private IPlayerDataManager _playerDataManager;

        [Inject]
        private void Construct(IPlayerDataManager playerDataManager)
        {
            _playerDataManager = playerDataManager;
        }

        public override void Process(InGameObjectSettings objSettings, EInteractState interactState)
        {
            if (objSettings is CollectableObjWithConditionsSettings settings &&
                interactState == EInteractState.Start)
            {
                Debug.LogWarning("Collect With Condition Processor");
                bool conditions = _playerDataManager.CheckCollectConditions(settings.collectionConditions);
                Debug.LogWarning($"conditions: {conditions}");
                interactState = conditions ? EInteractState.EnoughForCollect : EInteractState.NotEnoughForCollect;
            }

            base.Process(objSettings, interactState);
        }
    }
}
