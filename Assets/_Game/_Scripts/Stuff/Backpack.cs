using System.Collections.Generic;
using System.Linq;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using _Game._Scripts.Framework.Systems.SaveLoad;
using _Game._Scripts.Framework.Tickers;
using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Stuff
{
    public interface IBackpack
    {
        public void AddItems(Dictionary<int, float> dictionary);
        public void RemoveItems(Dictionary<int, float> dictionary);

        public bool IsResourcesEnough(List<CustomItemValue<ResourceSO>> settingsCollectionConditions,
            out Dictionary<int, float> resourceSos);
    }

    public sealed class Backpack : SavableDataModelBase<BackpackSO, BackpackSavableData>, IBackpack
    {
        protected override void InitializeDataModel()
        {
        }

        protected override BackpackSavableData GetDefaultModelData() => new(new Dictionary<int, float>());

        protected override string GetDebugLine()
        {
            var a = CachedModelData.Items.Aggregate("--- Items in backpack: ",
                (current, item) => current + $"/ {GameItemTypes.GetEnumName(item.Key)}({item.Key}) : {item.Value} /");
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
                        $"Item in backpack {item.Key} : {GameItemTypes.GetEnumName(item.Key)} already exists. Was {CachedModelData.Items[item.Key]}, added {item.Value}. Now {CachedModelData.Items[item.Key]}");
                }
                else if (!CachedModelData.Items.ContainsKey(item.Key))
                {
                    CachedModelData.Items.TryAdd(item.Key, item.Value);
                    Debug.LogWarning($" Added new {item.Key} {GameItemTypes.GetEnumName(item.Key)} :  {item.Value}");
                }
                else
                {
                    Debug.LogWarning(
                        $"<color=red>No item in backpack {item.Key}  {GameItemTypes.GetEnumName(item.Key)}  and not added</color>");
                }
            }

            Debug.LogWarning(GetDebugLine());
        }

        public void RemoveItems(Dictionary<int, float> dictionary)
        {
            Debug.LogWarning(GetDebugLine());
        }

        public bool IsResourcesEnough(List<CustomItemValue<ResourceSO>> settingsCollectionConditions,
            out Dictionary<int, float> resourceSos)
        {
            resourceSos = new Dictionary<int, float>();
            foreach (var requiredResource in settingsCollectionConditions)
            {
                var requiredResourceId = requiredResource.itemSettings.GetID();

                if (CachedModelData.Items.ContainsKey(requiredResourceId))
                {
                    // if key exists

                    if (CachedModelData.Items[requiredResourceId] < requiredResource.value)
                    {
                        resourceSos.Add(requiredResourceId, CachedModelData.Items[requiredResourceId]);
                    }
                }
                else
                {
                    // if key doesn't exist
                }

                if (CachedModelData.Items.ContainsKey(requiredResourceId) &&
                    CachedModelData.Items[requiredResourceId] >= requiredResource.value)
                {
                    continue;
                }
            }

            resourceSos = null;
            return false;
        }
    }

    [MessagePackObject]
    public class BackpackSavableData : ISavableData
    {
        [Key(0)] public Dictionary<int, float> Items { get; }

        public BackpackSavableData(Dictionary<int, float> items)
        {
            Items = items;
        }
    }
}
