using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using UnityEngine;

namespace _Game._Scripts.Item.Pickable
{
    public class PickableItemSystem : IInteractableItemSystem
    {
        private GameItemSettings _currentItemSettings;

        public void OnEnter(GameItemSettings itemSettings)
        {
            _currentItemSettings = itemSettings;
            Debug.LogWarning("PickableItemSystem.OnEnter / " + _currentItemSettings.name);
        }

        public void OnStay()
        {
        }

        public void OnExit()
        {
            Debug.LogWarning("PickableItemSystem.OnExit / " + _currentItemSettings.name);
        }
    }
}
