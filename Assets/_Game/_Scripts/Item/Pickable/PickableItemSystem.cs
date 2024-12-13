using _Game._Scripts.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Item.Pickable
{
    public class PickableItemSystem : LootableItemSystemBase
    {
        public override void OnEnter(IItemDto item)
        {
            Settings = (LootableItemSettingsDto)item;
            Debug.LogWarning("PickableItemSystem.OnEnter / " + Settings);
        }

        public override void OnStay()
        {
        }

        public override void OnExit()
        {
            Debug.LogWarning("PickableItemSystem.OnExit / " + Settings);
        }
    }
}
