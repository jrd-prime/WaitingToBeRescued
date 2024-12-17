using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Item.Pickable
{
    public class PickableObjSystem : LootableObjSystem<PickableObjSettings>
    {
        protected override void Enter()
        {
            Debug.LogWarning("PickableItemSystem.OnEnter / " + Settings.name);

            var a = new Dictionary<int, float>();

            foreach (var resource in Settings.objReturnsDto.resources)
            {
                Debug.LogWarning($"Returns: {resource.value} {resource.itemSettings.name} ");

                a.TryAdd((int)resource.itemSettings.itemId, resource.value);
            }


            Backpack.AddItems(a);
        }

        protected override void Stay()
        {
        }

        protected override void Exit()
        {
            Debug.LogWarning("PickableItemSystem.OnExit / " + Settings);
        }
    }
}
