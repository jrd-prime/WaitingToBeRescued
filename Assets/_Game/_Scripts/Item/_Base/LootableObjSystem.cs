using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Inventory;
using VContainer;

namespace _Game._Scripts.Item._Base
{
    public abstract class LootableObjSystem<TObjectSettings> //: ILootableObjSystem<TObjectSettings>
        where TObjectSettings : InGameObjectSO
    {
        protected TObjectSettings Settings;
        protected Backpack Backpack;

        private bool _isSettingsSet;

        [Inject]
        private void Construct(Backpack backpack)
        {
            Backpack = backpack;
        }

        public void SetObjSettings(TObjectSettings objSettings)
        {
            if (Backpack == null) throw new NullReferenceException("Backpack is null.");
            Settings = objSettings ?? throw new ArgumentNullException(nameof(objSettings));
            _isSettingsSet = true;
        }

        public void OnEnter()
        {
            if (!_isSettingsSet) throw new NullReferenceException("Settings not set.");
            Enter();
        }

        public void OnStay() => Stay();

        public void OnExit()
        {
            Exit();
            _isSettingsSet = false;
        }

        protected abstract void Enter();
        protected abstract void Stay();
        protected abstract void Exit();
    }
}
