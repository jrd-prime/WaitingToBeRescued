using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.UI.Base.View;

namespace _Game._Scripts.Framework.JStateMachine.Data
{
    [Serializable]
    public struct StateViewData
    {
        public EGameState uiForState;
        public UIViewBase viewHolder;
    }
}
