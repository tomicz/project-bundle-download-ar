using Immersed.AR;
using UnityEngine;

namespace Immersed.Debugging
{
    public class ARRaycastDebugger : MonoBehaviour
    {
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private Transform _visualiser;

        private void OnEnable()
        {
            _arPointer.OnPointerEnterEvent += HandleOnPointerEnterEvent;
            _arPointer.OnPointerExitEvent += HandleOnPointerExitEvent;
        }

        private void OnDisable()
        {
            _arPointer.OnPointerEnterEvent -= HandleOnPointerEnterEvent;
            _arPointer.OnPointerExitEvent -= HandleOnPointerExitEvent;
        }

        private void HandleOnPointerEnterEvent(Vector3 hitPosition)
        {
            _visualiser.gameObject.SetActive(true);
            _visualiser.transform.position = hitPosition;
        }

        private void HandleOnPointerExitEvent()
        {
            _visualiser.gameObject.SetActive(false);
        }
    }
}