using Immersed.AR;
using UnityEngine;

namespace Immersed.Systems.StateSystem.States
{
    public class StateMenu : State
    {
        [Header("Dependencies")]
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private InputManager _inputManager;

        [Header("State properties")]
        [SerializeField] private LayerMask _interactableLayer;

        public override void OnEnter()
        {
            base.OnEnter();

            _inputManager.OnPointerDownEvent = HandleOnButtonPressedDownEvent;
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

        private void HandleOnButtonPressedDownEvent(Vector2 inputPosition)
        {
            _arPointer.RegisterOnPointerSelected(inputPosition);
        }

        private void HandleOnPointerDragEvent(Vector2 inputPosition)
        {
            _arPointer.RegisterOnPointerDrag(inputPosition);
        }

        private void HandleOnPointerUpEvent(Vector2 inputPosition)
        {
            _arPointer.RegisterOnPointerUp(inputPosition);
        }
    }
}