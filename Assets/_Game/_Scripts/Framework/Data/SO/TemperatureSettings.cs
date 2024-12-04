﻿using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO
{
    [CreateAssetMenu(
        fileName = "temperature-settings",
        menuName = SOPathConst.ConfigPath + "temperature-settings",
        order = 100)]
    public class TemperatureSettings : SettingsSO
    {
        public override string Description => "Ambient Temperature";
        public float startTempInCelsius = 33f;
        public float baseDailyTemperatureDrop = 1f;
    }
}
