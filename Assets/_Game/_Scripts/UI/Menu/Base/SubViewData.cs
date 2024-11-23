using System;
using _Game._Scripts.UI.Base.View;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Menu.Base
{
    [Serializable]
    public struct SubViewData<TSubStateEnum> where TSubStateEnum : Enum
    {
        public TSubStateEnum subState;
        public SubViewBase subView;
    }
}
