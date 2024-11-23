using _Game._Scripts.Framework.Data.Enums.States;

namespace _Game._Scripts.Framework.Manager.UI
{
    public interface IUIManager
    {
        public void ShowView(EGameState eGameState, bool toSafe = false);
        public void HideView(EGameState eGameState);
        public void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
    }
}
