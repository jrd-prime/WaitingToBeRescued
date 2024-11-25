using System;
using _Game._Scripts.Framework.Data.Enums.States;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Manager.UI
{
    public interface IUIManager : IInitializable
    {
        public void ShowView(EGameState eGameState, Enum subState );
        public void HideView(EGameState eGameState, Enum subState);
        public void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
    }
}
