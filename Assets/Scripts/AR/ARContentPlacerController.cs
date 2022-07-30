using Immersed.UI;
using UnityEngine;

namespace Immersed.AR
{
    public class ARContentPlacerController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private ARItemContainerController _arItemContainerController;
        [SerializeField] private UIViewConfirmAction _uiViewConfirmAction;

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
                TryPlacingItemOntoGround();
                _uiViewConfirmAction.AddConfirmAction("Are you sure you want to place an object here?", PlaceItemOntoGround);
                _uiViewConfirmAction.AddCancelAction(ReturnPlacedItem);
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

        private void TryPlacingItemOntoGround()
        {
            _arItemContainerController.ReleaseItem();
        }

        private void PlaceItemOntoGround()
        {
            _arItemContainerController.RemoveItem();
        }

        private void ReturnPlacedItem()
        {
            _arItemContainerController.GrabLastItem();
        }
    }
}