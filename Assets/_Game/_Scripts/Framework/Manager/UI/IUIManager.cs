using _Game._Scripts.UIOLD;

namespace _Game._Scripts.Framework.Manager.UI
{
    public interface IUIManager
    {
        public void ShowView(GameStateType gameStateType, bool toSafe = false);
        public void HideView(GameStateType gameStateType);
        public void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
    }
}
