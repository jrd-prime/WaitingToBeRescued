namespace _Game._Scripts.Item._Base
{
    public abstract class NonLootableItemSystemBase : IInteractableItemSystem
    {
        protected NonLootableItemSettingsDto Settings;
        public abstract void OnEnter(IItemDto itemDto);
        public abstract void OnStay();
        public abstract void OnExit();
    }
}
