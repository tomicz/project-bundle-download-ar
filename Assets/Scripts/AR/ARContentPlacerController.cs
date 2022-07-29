using UnityEngine;

namespace Immersed.AR
{
    public class ARContentPlacerController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private ARItemContainerController _arItemContainerController;

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
            PlaceItemOntoGround();
        }

        private void HandleOnARPointerEnterEvent(Vector3 hitPosition)
        {
            _arItemContainerController.SetPosition(hitPosition);
        }

        private void HandleOnARPointerExitEvent()
        {

        }

        private void PlaceItemOntoGround()
        {
            _arItemContainerController.RemoveItem();
        }
    }
}