using System;
using _Game._Scripts.UI.Base.View;

namespace _Game._Scripts.Framework.Data
{
    [Serializable]
    public struct SubViewData<TSubStateEnum> where TSubStateEnum : Enum
    {
        public TSubStateEnum subState;
        public JSubViewBase subView;
    }
}
