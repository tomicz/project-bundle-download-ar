using UnityEngine;

namespace Immersed.AR
{
    public class ARContentPlacerController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private ARItemContainerController _arItemContainerController;

        private bool _canPlaceContent = false;

        private void OnEnable()
        {
            _inputManager.OnButtonPressDownEvent += HandleOnButtonPressedEvent;
            _arPointer.OnPointerEnterEvent += HandleOnARPointerEnterEvent;
            _arPointer.OnPointerExitEvent += HandleOnARPointerExitEvent;
        }

        private void OnDisable()
        {
            _inputManager.OnButtonPressDownEvent -= HandleOnButtonPressedEvent;
            _arPointer.OnPointerEnterEvent -= HandleOnARPointerEnterEvent;
            _arPointer.OnPointerExitEvent -= HandleOnARPointerExitEvent;
        }

        public void SetItem(Transform transform)
        {
            _arItemContainerController.GrabItem(transform);
        }

        private void HandleOnButtonPressedEvent()
        {
            if (_canPlaceContent)
            {
                PlaceItemOntoGround();
            }
        }

        private void HandleOnARPointerEnterEvent(Vector3 hitPosition)
        {
            _canPlaceContent = true;
            _arItemContainerController.SetPosition(hitPosition);
        }

        private void HandleOnARPointerExitEvent()
        {
            _canPlaceContent = false;
        }

        private void PlaceItemOntoGround()
        {
            _arItemContainerController.RemoveItem();
        }
    }
}