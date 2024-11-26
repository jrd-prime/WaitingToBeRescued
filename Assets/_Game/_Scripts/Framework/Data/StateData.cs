using System;
using _Game._Scripts.Framework.Data.Enums.States;

namespace _Game._Scripts.Framework.Data
{
    public struct StateData
    {
        public EGameState State;
        public Enum SubState;

        public StateData(EGameState baseState, Enum oSubState = default)
        {
            State = baseState;
            SubState = oSubState;
        }
    }
}
