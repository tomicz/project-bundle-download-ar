using UnityEngine;

namespace Immersed.AR
{
    public class ARItemContainerController : MonoBehaviour
    {
        private Transform _grabbedItem;
        private Transform _grabbedItemOriginalParent;

        public void GrabItem(Transform grabbedItem)
        {
            _grabbedItem = grabbedItem;
            _grabbedItemOriginalParent = _grabbedItem.parent;
            _grabbedItem.SetParent(transform);
            _grabbedItem.transform.localPosition = Vector3.zero;
        }

        public void GrabLastItem()
        {
            _grabbedItem.SetParent(transform);
        }

        public void ReleaseItem()
        {
            _grabbedItem.SetParent(_grabbedItemOriginalParent);
        }

        public void RemoveItem()
        {
            _grabbedItem.SetParent(_grabbedItemOriginalParent);
            _grabbedItem = null;
            _grabbedItemOriginalParent = null;
        }

        public void SetPosition(Vector3 position) => transform.position = position;

        public void SetLocalPosition(Vector3 position) => transform.localPosition = position;
    }
}