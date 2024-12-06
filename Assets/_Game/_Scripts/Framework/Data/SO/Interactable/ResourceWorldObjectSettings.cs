using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Interactable
{
    [CreateAssetMenu(
        fileName = "worldObjectSettings",
        menuName = SOPathConst.WorldObject + "world-object-settings",
        order = 100)]
    public class ResourceWorldObjectSettings : WorldObjectSettings<ResourceSettings>
    {
    }
}
