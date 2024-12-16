using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Item._Base
{
    public interface ILootableObjSystem<TSettings> where TSettings : InGameObjectSettings
    {
        public void SetObjSettings(TSettings objSettings);
        public void OnEnter();
        public void OnStay();
        public void OnExit();
    }

    public interface IItemDto
    {
    }
}
