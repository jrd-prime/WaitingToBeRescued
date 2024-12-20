﻿using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "InteractableWithRequirements",
        menuName = SOPathConst.InGameItem + "New Interactable With Requirements Obj Settings",
        order = 100)]
    public class InteractableObjWithRequirementsSettings : InteractableObjSettings
    {
       
        public override void ShowDebug()
        {
            base.ShowDebug();
        }
    }
}
