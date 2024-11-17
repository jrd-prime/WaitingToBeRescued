using UnityEngine;

namespace _Game._Scripts.Framework.SO
{
    public abstract class SettingsSO : ScriptableObject, ISettings
    {
        public abstract string Description { get; }
    }

    public interface ISettings
    {
        public string Description { get; }
    }
}
