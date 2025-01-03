using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.NonLootable
{
    [CreateAssetMenu(
        fileName = "newSkillSettings",
        menuName = SOPathConst.InGameItem + "New Skill",
        order = 100)]
    public class SkillSO : NonLootableItemSO<GameItemTypes.ESkillItem>
    {
        public override void ShowDebug()
        {
            Debug.LogWarning("SkillSO / " + name);
        }
    }
}
