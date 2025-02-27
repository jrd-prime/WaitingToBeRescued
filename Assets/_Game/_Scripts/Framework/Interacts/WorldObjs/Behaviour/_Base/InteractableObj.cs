﻿using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Obj.InWorld;
using _Game._Scripts.Framework.Helpers.Extensions;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base
{
    public abstract class InteractableObj<TInWorldObjSettings> : InteractableObjBase
        where TInWorldObjSettings : InWorldObjectSO
    {
        [SerializeField] protected LayerMask layerForTrigger;
        [SerializeField] protected TInWorldObjSettings objSettings;


        private void Awake()
        {
            if (objSettings == null) throw new NullReferenceException($"ObjSettings is null. {name}");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.IsRightLayer(layerForTrigger)) return;
            StartInteract(objSettings);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger))
            {
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.IsRightLayer(layerForTrigger)) return;
            // FinishInteract(_objectData);
        }
    }
}
