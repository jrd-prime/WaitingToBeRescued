using System.Collections.Generic;
using System.Linq;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Game;
using _Game._Scripts.Framework.Shelter;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Inventory
{
    public sealed class Backpack : SavableDataModelBase<BackpackSettings, BackpackData>
    {
        protected override void InitModel()
        {
        }

        protected override BackpackData GetDefaultModelData() => new(new Dictionary<int, float>());

        protected override string GetDebugLine()
        {
            var a = CachedModelData.Items.Aggregate("--- Items in backpack: ",
                (current, item) => current + $"/ {GameItemTypes.getEnumName(item.Key)}({item.Key}) : {item.Value} /");
            return a;
        }

        public void AddItems(Dictionary<int, float> dictionary)
        {
            foreach (var item in dictionary)
            {
                if (CachedModelData.Items.ContainsKey(item.Key))
                {
                    CachedModelData.Items[item.Key] += item.Value;
                    Debug.LogWarning(
                        $"Item in backpack {item.Key} : {GameItemTypes.getEnumName(item.Key)} already exists. Was {CachedModelData.Items[item.Key]}, added {item.Value}. Now {CachedModelData.Items[item.Key]}");
                }
                else if (!CachedModelData.Items.ContainsKey(item.Key))
                {
                    CachedModelData.Items.TryAdd(item.Key, item.Value);
                    Debug.LogWarning($" Added new {item.Key} {GameItemTypes.getEnumName(item.Key)} :  {item.Value}");
                }
                else
                {
                    Debug.LogWarning(
                        $"<color=red>No item in backpack {item.Key}  {GameItemTypes.getEnumName(item.Key)}  and not added</color>");
                }
            }

            Debug.LogWarning(GetDebugLine());
        }

        public void RemoveItems(Dictionary<int, float> dictionary)
        {
            Debug.LogWarning(GetDebugLine());
        }
    }

    [MessagePackObject]
    public class BackpackData : IDataComponent
    {
        [Key(0)] public Dictionary<int, float> Items { get; private set; }

        public BackpackData(Dictionary<int, float> items)
        {
            Items = items;
        }
    }
}
