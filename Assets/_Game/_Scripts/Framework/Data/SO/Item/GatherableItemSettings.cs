using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "gatherable-item-settings",
        menuName = SOPathConst.Resource + "New Gatherable Item",
        order = 100)]
    public class GatherableItemSettings : GameItemSettings
    {
    }
}
