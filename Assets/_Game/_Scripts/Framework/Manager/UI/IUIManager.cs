using System;
using _Game._Scripts.Framework.Data.Enums.States;

namespace _Game._Scripts.Framework.Manager.UI
{
    public interface IUIManager
    {
        public void ShowView(EGameState eGameState, Enum subState, bool toSafe = false);
        public void HideView(EGameState eGameState, Enum subState);
        public void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
    }
}
