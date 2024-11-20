﻿using UnityEngine;

namespace _Game._Scripts.Framework.Input
{
    public sealed class MobileInput : MonoBehaviour
    {
        private JInputActions _gameInputActions;

        private void Awake()
        {
            _gameInputActions = new JInputActions();
            _gameInputActions.Enable();
        }
    }
}
