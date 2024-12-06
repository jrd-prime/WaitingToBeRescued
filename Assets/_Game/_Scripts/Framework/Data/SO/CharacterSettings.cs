using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO
{
    [CreateAssetMenu(
        fileName = "character-settings",
        menuName = SOPathConst.CharacterPath + "character-settings",
        order = 100)]
    public class CharacterSettings : SettingsSO
    {
        [Range(0.1f, 100f)] public float moveSpeed = 5f;

        [Range(45f, 270f)] public float rotationSpeed = 180f;
        [Range(30f, 1000f)] public int health = 30;

        // public WeaponSettings weapon;

        // private void OnValidate()
        // {
        //     Assert.IsNotNull(weapon, "Weapon config is null. Add to auto inject.");
        // }
    }
}
