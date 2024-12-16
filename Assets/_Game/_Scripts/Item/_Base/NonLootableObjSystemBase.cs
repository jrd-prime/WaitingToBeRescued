using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Item._Base
{
    public abstract class NonLootableObjSystemBase<TObjSettings> : ILootableObjSystem<TObjSettings>
        where TObjSettings : InGameObjectSettings
    {
        protected TObjSettings Settings;

        public void SetObjSettings(TObjSettings objSettings) => Settings = objSettings;
        public abstract void OnEnter();
        public abstract void OnStay();
        public abstract void OnExit();
    }
}
