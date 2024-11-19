using _Game._Scripts.UI;

namespace _Game._Scripts.Framework.Manager.UI
{
    public interface IUIManager
    {
        public void ShowView(GameStateType gameStateType);
        public void HideView(GameStateType gameStateType);
    }
}
