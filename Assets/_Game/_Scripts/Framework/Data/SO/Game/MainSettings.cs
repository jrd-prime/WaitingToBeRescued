using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Game
{
    /// <summary>
    /// Main Settings. Add to the RootContext prefab
    /// </summary>
    [CreateAssetMenu(
        fileName = "main-settings",
        menuName = SOPathConst.ConfigPath + "main-settings",
        order = 100)]
    public class MainSettings : SettingsSO
    {
        [Header("Character")] [RequiredField] public CharacterSettings characterSettings;
        [RequiredField] public MovementControlSettings movementControlSettings;

        [Space(10)] [Header("Gameplay")] [RequiredField]
        public GameplaySettings gameplaySettings;

        [RequiredField] public EnergySettings energySettings;

        [RequiredField] public TemperatureSettings temperatureSettings;
        [RequiredField] public GameTimerSettings GameTimerSettings;
        
        [RequiredField] public BackpackSettings backpackSettings;
    }
}
