using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Settings
{
    [CreateAssetMenu(
        fileName = "UsableWithConditions",
        menuName = SOPathConst.InWorldItem + "New Usable With Conditions",
        order = 100)]
    public class UsableWithConditionsSO : UsableSO
    {
        public UsingConditionsData useConditions;

        public override void ShowDebug()
        {
            base.ShowDebug();
        }
    }
}
