using System;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Data.SO.State;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Manager.UI
{
    public interface IUIManager : IInitializable
    {
        public void ShowView(EGameState eGameState, Enum subState, EShowLogic showLogic = EShowLogic.Default);
        public void HideView(EGameState eGameState, Enum subState, EShowLogic showLogic);
        public void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
        public StateData GetPreviousState();
    }
}
