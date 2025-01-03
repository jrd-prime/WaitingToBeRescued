using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Settings
{
    [CreateAssetMenu(
        fileName = "UsableWithConditions",
        menuName = SOPathConst.InWorldItem + "New Usable With Conditions",
        order = 100)]
    public class UsableWithConditionsSO : UsableSO
    {
        public override void ShowDebug()
        {
            base.ShowDebug();
        }
    }
}
