using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using R3;
using UnityEngine;

namespace _Game._Scripts.Framework.JrdStateMachine
{
    public class StateMachineReactiveAdapter : IStateMachineReactiveAdapter
    {
        public ReactiveProperty<StateData> StateData { get; } = new();

        public void SetStateData(StateData stateData)
        {
            Debug.LogWarning("Set state data");
            StateData.Value = stateData;
        }
    }

    public interface IStateMachineReactiveAdapter
    {
        public ReactiveProperty<StateData> StateData { get; }
        public void SetStateData(StateData stateData);
    }
}
