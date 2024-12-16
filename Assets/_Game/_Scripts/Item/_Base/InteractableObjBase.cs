using UnityEngine;

namespace _Game._Scripts.Item._Base
{
    public interface IInteractableItem
    {
    }

    [RequireComponent(typeof(Collider))]
    public abstract class InteractableObjBase : MonoBehaviour, IInteractableItem
    {
        private void Awake() => GetComponent<Collider>().isTrigger = true;
    }
}
