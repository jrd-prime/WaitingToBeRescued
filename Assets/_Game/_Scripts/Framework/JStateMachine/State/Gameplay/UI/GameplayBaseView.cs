using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.View;

namespace _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI
{
    public class GameplayBaseView : CustomUIViewBase<IGameplayViewModel, EGameplaySubState>
    {
    }
}
