﻿using System;
using _Game._Scripts.Framework.Data;
using R3;
using UnityEngine;

namespace _Game._Scripts.Framework.JrdStateMachine
{
    public class StateMachineReactiveAdapter : IStateMachineReactiveAdapter
    {
        public ReactiveProperty<StateData> StateData { get; } = new();

        public void SetStateData(StateData stateData)
        {
            Debug.Log($"<b>State change requested to {stateData.State}.{stateData.SubState}</b>");
            StateData.Value = stateData;
        }

        public void Dispose()
        {
            StateData?.Dispose();
        }
    }

    public interface IStateMachineReactiveAdapter: IDisposable
    {
        public ReactiveProperty<StateData> StateData { get; }
        public void SetStateData(StateData stateData);
    }
}
