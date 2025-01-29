using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Interacts.WorldObjs;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Obj.InWorld
{
    [CreateAssetMenu(
        fileName = "UsableObj",
        menuName = SOPathConst.InWorldItem + "New Usable",
        order = 100)]
    public class UsableSO : InWorldObjectSO
    {
        public EInteract interact;

        public override void ShowDebug()
        {
            Debug.LogWarning("UsableSO / " + name);
        }
    }
}
