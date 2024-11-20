using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
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
    }
}
