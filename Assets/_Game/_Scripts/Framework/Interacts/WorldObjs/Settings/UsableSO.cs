using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Settings
{
    [CreateAssetMenu(
        fileName = "UsableObj",
        menuName = SOPathConst.InWorldItem + "New Usable",
        order = 100)]
    public class UsableSO : InGameObjectSO
    {
        public EInteract interact;

        public override void ShowDebug()
        {
            Debug.LogWarning($"Interact: {interact}");
        }
    }
}
