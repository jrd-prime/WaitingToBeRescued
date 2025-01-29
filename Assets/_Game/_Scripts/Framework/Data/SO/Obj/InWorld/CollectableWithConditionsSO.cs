using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Framework.Data.SO.Obj.InWorld
{
    [CreateAssetMenu(
        fileName = "CollectableObjWithConditions",
        menuName = SOPathConst.InWorldItem + "New Collectable With Conditions",
        order = 100)]
    public class CollectableWithConditionsSO : CollectableSO
    {
        [FormerlySerializedAs("collectionConditions")] public CollectionConditionsData collectConditions;

        public override void ShowDebug() => Debug.LogWarning("CollectableWithConditionsSO / " + name);
    }
}
