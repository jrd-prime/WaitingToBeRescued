﻿using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "newGatherableObjSettings",
        menuName = SOPathConst.InGameItem + "New Gatherable Obj Settings",
        order = 100)]
    public class GatherableObjSettings : InGameObjectSettings
    {
        [FormerlySerializedAs("objReturnsData")] [FormerlySerializedAs("objReturns")] public LootableObjReturnsDto objReturnsDto;
        [FormerlySerializedAs("objRequirements")] public LootableObjRequirementsDto objRequirementsDto;

        public override void ShowDebug()
        {
            Debug.LogWarning("GatherableObjSettings / " + name);
        }
    }
}
