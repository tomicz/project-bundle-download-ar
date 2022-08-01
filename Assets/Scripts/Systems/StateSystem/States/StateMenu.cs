using Immersed.AR;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Immersed.Systems.StateSystem.States
{
    public class StateMenu : State
    {
        [Header("Dependencies")]
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private CanvasContainer _canvasContainer;

        [Header("State properties")]
        [SerializeField] private LayerMask _interactableLayer;
        [SerializeField] private LayerMask _groundLayer;

        public override void OnEnter()
        {
            base.OnEnter();
            _canvasContainer.Enable();
            _arPointer.ChangeTarget(_interactableLayer);

            _inputManager.OnPointerDownEvent += HandleOnButtonPressedDownEvent;
            _inputManager.OnPointerHoldEvent += HandleOnPointerDragEvent;
            _inputManager.OnPointerUpEvent += HandleOnPointerUpEvent;
        }

        public override void StateFixedUpdate()
        {

        }

        public override void StateLateUpdate()
        {

        }

        public override void StateUpdate()
        {

        }

        public override void OnExit()
        {
            base.OnExit();

            _inputManager.OnPointerDownEvent -= HandleOnButtonPressedDownEvent;
            _inputManager.OnPointerHoldEvent -= HandleOnPointerDragEvent;
            _inputManager.OnPointerUpEvent -= HandleOnPointerUpEvent;
        }

        private void HandleOnButtonPressedDownEvent()
        {
            _arPointer.RegisterOnPointerSelected();
        }

        private void HandleOnPointerDragEvent()
        {
            _arPointer.ChangeTarget(_groundLayer);
            _arPointer.RegisterOnPointerDrag();
        }

        private void HandleOnPointerUpEvent()
        {
            _arPointer.ChangeTarget(_interactableLayer);
        }
    }
}