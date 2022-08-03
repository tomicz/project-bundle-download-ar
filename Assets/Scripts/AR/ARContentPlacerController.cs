using System;
using Immersed.Debugging;
using Immersed.UI;
using UnityEngine;

namespace Immersed.AR
{
    public class ARContentPlacerController : MonoBehaviour
    {
        public Action<Vector3> OnContentPlacedEvent;

        [Header("Dependencies")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private ARRaycastDebugger _arRaycastDebugger;
        [SerializeField] private ARItemContainerController _arItemContainerController;
        [SerializeField] private UIViewConfirmAction _uiViewConfirmAction;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private LayerMask _interactableMask;

        private bool _canPlaceContent = false;
        private Vector3 _hitPosition;

        private void OnEnable()
        {
            _inputManager.OnPointerDownEvent += HandleOnButtonPressedEvent;
            _arPointer.OnPointerEnterEvent += HandleOnARPointerEnterEvent;
            _arPointer.OnPointerExitEvent += HandleOnARPointerExitEvent;
        }

        private void OnDisable()
        {
            _inputManager.OnPointerDownEvent -= HandleOnButtonPressedEvent;
            _arPointer.OnPointerEnterEvent -= HandleOnARPointerEnterEvent;
            _arPointer.OnPointerExitEvent -= HandleOnARPointerExitEvent;
        }

        public void SetItem(Transform transform)
        {
            _arRaycastDebugger.enabled = false;
            _arPointer.ShowRaycaster(false);
            _arPointer.ChangeTarget(_groundMask);
            _arItemContainerController.GrabItem(transform);
        }

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        private void HandleOnButtonPressedEvent(Vector2 inputPosition)
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
            _hitPosition = hitPosition;
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
            _arRaycastDebugger.enabled = true;
            _arPointer.ShowRaycaster(true);
            _arPointer.ChangeTarget(_interactableMask);
            OnContentPlacedEvent?.Invoke(_hitPosition);
            _arItemContainerController.RemoveItem();
        }

        private void ReturnPlacedItem()
        {
            _arItemContainerController.GrabLastItem();
        }
    }
}