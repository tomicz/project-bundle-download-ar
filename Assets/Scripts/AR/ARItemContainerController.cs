using UnityEngine;

namespace Immersed.AR
{
    public class ARItemContainerController : MonoBehaviour
    {
        private Transform _grabbedItem;

        public void GrabItem(Transform transform)
        {
            _grabbedItem = transform;
            _grabbedItem.SetParent(transform);
        }

        public void RemoveItem()
        {
            _grabbedItem.SetParent(null);
            _grabbedItem = null;
        }

        public void SetPosition(Vector3 position) => transform.position = position;

        public void SetLocalPosition(Vector3 position) => transform.localPosition = position;
    }
}