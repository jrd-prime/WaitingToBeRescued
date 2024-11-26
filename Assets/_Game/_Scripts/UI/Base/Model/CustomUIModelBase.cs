using System;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using UnityEngine;

namespace _Game._Scripts.UI.Base.Model
{
    public abstract class CustomUIModelBase<TSubStateEnum> : UIModelBase, IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
        public abstract void Initialize();

        public void SetGameState(StateData stateData) => _ra.SetStateData(stateData);

        public void SetPreviousState()
        {
            var stateData = UIManager.GetPreviousState();

            Debug.LogWarning(
                $"<color=darkblue>[Set PREVIOUS State]</color> Previous: {stateData.State}.{stateData.SubState}");

            _ra.SetStateData(stateData);
        }
    }
}
