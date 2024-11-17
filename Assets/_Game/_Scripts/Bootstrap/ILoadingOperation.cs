namespace _Game._Scripts.Bootstrap
{
    public interface ILoadingOperation
    {
        string Description { get; }
        public void LoaderServiceInitialization();
    }
}
