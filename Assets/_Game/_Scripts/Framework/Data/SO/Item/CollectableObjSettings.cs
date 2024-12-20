using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "Collectable",
        menuName = SOPathConst.InGameItem + "New Collectable Obj Settings",
        order = 100)]
    public class CollectableObjSettings : InGameObjectSettings
    {
        public CollectiblesData collectibles;

        public override void ShowDebug()
        {
            Debug.LogWarning("=== Returns ===");
            collectibles.resources.LogItems("Resource");
            collectibles.tools.LogItems("Tool");
            collectibles.stuff.LogItems("Stuff");
            Debug.LogWarning("===");
        }

        
    }
}
