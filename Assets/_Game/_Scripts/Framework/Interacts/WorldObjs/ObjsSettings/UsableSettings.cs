using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings
{
    [CreateAssetMenu(
        fileName = "UsableObj",
        menuName = SOPathConst.InWorldItem + "New Usable",
        order = 100)]
    public class UsableSettings : InGameObjectSettings
    {
        public EInteract interact;

        public override void ShowDebug()
        {
            Debug.LogWarning($"Interact: {interact}");
        }
    }
}
