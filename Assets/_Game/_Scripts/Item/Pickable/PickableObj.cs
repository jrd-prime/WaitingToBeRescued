﻿using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Item.NonLootable;
using _Game._Scripts.Item._Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Item.Pickable
{
    public class PickableObj : LootableItemObj<PickableItemSystem, PickableItemDto>
    {
    }

    [Serializable]
    public struct PickableItemDto : IItemDto
    {
        public LootableItemReturns lootableItemReturns;
    }

    [Serializable]
    public struct CustomItemValue<T> where T : SettingsSO
    {
        public T itemSettings;
        public float value;
    }

    [Serializable]
    public struct LootableItemReturns
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<ToolSettings>> tools;
        public List<CustomItemValue<StuffSettings>> stuff;
    }

    [Serializable]
    public struct GatherableItemDto : IItemDto
    {
        public LootableItemReturns LootableItemReturns;
        public LootableItemRequirements LootableItemRequirements;
    }


    [Serializable]
    public struct LootableItemRequirements
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<BuildingSettings>> buildings;
        public List<CustomItemValue<SkillSettings>> skills;
        public List<CustomItemValue<ToolSettings>> tools;
    }

    public enum ESettingsType
    {
        NotSet = -1,
        Resource = 0,
        Building = 1,
        Skill = 2,
        Game = 100
    }
}
