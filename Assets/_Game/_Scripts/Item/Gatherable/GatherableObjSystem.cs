using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Item.Gatherable
{
    public class GatherableObjSystem : LootableObjSystem<GatherableObjSettings>
    {
        protected override void Enter()
        {
            Debug.LogWarning("GatherableItemSystem.OnEnter / " + Settings);
        }

        protected override void Stay()
        {
        }

        protected override void Exit()
        {
            Debug.LogWarning("GatherableItemSystem.OnExit / " + Settings);
        }
    }
}
