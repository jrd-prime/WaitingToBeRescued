using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Obj.InGame.NonLootable
{
    [CreateAssetMenu(
        fileName = "newSkillSettings",
        menuName = SOPathConst.InGameItem + "New Skill",
        order = 100)]
    public class SkillSO : NonLootableItemSO<GameItemTypes.ESkillItem>
    {
        public override int GetID() => Convert.ToInt32(itemId);

        public override void ShowDebug()
        {
            Debug.LogWarning("SkillSO / " + name);
        }
    }
}
