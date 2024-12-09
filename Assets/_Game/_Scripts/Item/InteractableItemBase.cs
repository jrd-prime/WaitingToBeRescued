using UnityEngine;

namespace _Game._Scripts.Item
{
    [RequireComponent(typeof(Collider))]
    public abstract class InteractableItemBase : MonoBehaviour, IInteractableItem
    {
        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }

    public interface IInteractableItem
    {
    }
}
