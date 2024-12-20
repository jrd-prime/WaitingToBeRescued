﻿using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Interacts.WorldObjs;
using UnityEngine;

namespace _Game._Scripts.Item._Base
{
    public abstract class InteractableObj<TObjectData, TObjSettings> : InteractableObjBase
        where TObjectData : IWorldObjectDto, new()
        where TObjSettings : InGameObjectSettings
    {
        [SerializeField] protected LayerMask layerForTrigger;
        [SerializeField] protected TObjSettings objSettings;

        private TObjectData _objectData;

        private void Awake()
        {
            if (objSettings == null) throw new NullReferenceException($"ObjSettings is null. {name}");
            _objectData = (TObjectData)Activator.CreateInstance(typeof(TObjectData), args: objSettings);
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
