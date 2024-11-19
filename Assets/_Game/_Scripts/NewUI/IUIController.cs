using _Game._Scripts.UI;

namespace _Game._Scripts.NewUI
{
    public interface IUIController
    {
        public void ShowView(GameStateType gameStateType);
        public void HideView(GameStateType gameStateType);
    }
}
