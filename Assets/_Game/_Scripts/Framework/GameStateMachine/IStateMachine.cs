using System;
using _Game._Scripts.Framework.Data.Enums.States;
using VContainer.Unity;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public interface IStateMachine : IStartable, IDisposable
    {
        public void ChangeStateTo(EGameState eGameState);
    }
}
