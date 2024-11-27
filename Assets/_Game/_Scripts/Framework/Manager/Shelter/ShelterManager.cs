using System;
using _Game._Scripts.Framework.Manager.Shelter.Timer;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    public sealed class ShelterManager : MonoBehaviour
    {
        private ShelterTimerModel _shelterTimerModel;

        private void Awake()
        {
            _shelterTimerModel = new ShelterTimerModel();
        }
    }
}
