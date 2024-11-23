using System;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Menu.Base
{
    [Serializable]
    public struct SubStateData<TSubStateEnum> where TSubStateEnum : Enum
    {
        public string headerNameId;
        public TSubStateEnum subStateType;
        public VisualTreeAsset visualTreeAsset;
    }
}
