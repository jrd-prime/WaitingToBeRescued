using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Interactable.WorldObject;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Interactable
{
    [CreateAssetMenu(
        fileName = "resourceSettings",
        menuName = SOPathConst.Resource + "resource-settings",
        order = 100)]
    public class GameItemSettings : GameItemSettingsBase
    {
    }
}
