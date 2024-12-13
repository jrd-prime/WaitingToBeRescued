using _Game._Scripts.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Item.Gatherable
{
    public class GatherableItemSystem : LootableItemSystemBase
    {
        public override void OnEnter(IItemDto settings)
        {
            Settings = (LootableItemSettingsDto)settings;

            Debug.LogWarning("GatherableItemSystem.OnEnter / " + Settings);
        }

        public override void OnStay()
        {
        }

        public override void OnExit()
        {
            Debug.LogWarning("GatherableItemSystem.OnExit / " + Settings);
        }
    }
}
