namespace _Game._Scripts.Item._Base
{
    public interface IInteractableItemSystem
    {
        public void OnEnter(IItemDto itemDto);
        public void OnStay();
        public void OnExit();
    }

    public interface IItemDto
    {
    }
}
