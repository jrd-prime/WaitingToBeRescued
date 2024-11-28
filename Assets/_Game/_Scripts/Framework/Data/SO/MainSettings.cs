using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO
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
        public override string Description => "Main Settings";

        [Header("Character")] [RequiredField] public CharacterSettings characterSettings;
        [RequiredField] public MovementControlSettings movementControlSettings;

        [Space(10)] [Header("Gameplay")] [RequiredField]
        public GameplaySettings gameplaySettings;

        [RequiredField] public EnergySettings energySettings;

        [RequiredField] public TemperatureSettings temperatureSettings;
    }
}
