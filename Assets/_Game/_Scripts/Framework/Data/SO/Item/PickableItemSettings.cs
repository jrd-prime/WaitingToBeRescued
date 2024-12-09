using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "pickable-item-settings",
        menuName = SOPathConst.Resource + "New Pickable Item",
        order = 100)]
    public class PickableItemSettings : GameItemSettings
    {
    }
}
