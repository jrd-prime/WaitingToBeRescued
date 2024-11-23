namespace _Game._Scripts.Framework.GameStateMachine
{
    public interface IGameState
    {
        public void Enter();
        public void Exit();
    }

    public interface ISubState : IGameState
    {
    }
}
