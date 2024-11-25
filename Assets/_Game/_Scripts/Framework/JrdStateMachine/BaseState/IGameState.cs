using System;
using _Game._Scripts.Framework.Data.Enums.States;

namespace _Game._Scripts.Framework.JrdStateMachine.BaseState
{
    public interface IGameState
    {
        public void Enter();
        public void Exit();
        public void SetCallback(Action<EGameState> changeStateCallback);
    }
}
