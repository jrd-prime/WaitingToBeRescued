using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.NonLootable
{
    [CreateAssetMenu(
        fileName = "newSkillSettings",
        menuName = SOPathConst.InGameItem + "New Skill",
        order = 100)]
    public class SkillSettings : NonLootableItemSettings
    {
        public override string ItemNameId => "Not Set";
    }
}
