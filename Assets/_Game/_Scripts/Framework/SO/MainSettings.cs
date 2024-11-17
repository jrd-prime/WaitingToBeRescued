using System.Configuration;
using _Game._Scripts.Framework.Constants;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Game._Scripts.Framework.SO
{
    [CreateAssetMenu(
        fileName = "MainSettings",
        menuName = SOPathConst.ConfigPath + "Main Settings",
        order = 100)]
    public class MainSettings : SettingsSO
    {
        public override string Description => "Main Settings";

        public CharacterSettings character;

        // public EnemyManagerSettings enemyManager;
        // public EnemiesMainSettings enemies;
        // public WeaponSettings weapon;
        public MovementControlSettings movementControl;
        // public GameSettings gameSettings;

        private void OnValidate()
        {
            Assert.IsNotNull(character, "Main Configurations: Character config is null!");
            // Assert.IsNotNull(enemyManager, "Main Configurations: Enemy Manager config is null!");
            // Assert.IsNotNull(enemies, "Main Configurations: Enemy config is null!");
            // Assert.IsNotNull(weapon, "Main Configurations: Weapon config is null!");
            Assert.IsNotNull(movementControl, "Main Configurations: Movement Control config is null!");
            // Assert.IsNotNull(gameSettings, "Main Configurations: Game Settings config is null!");
        }
    }
}
