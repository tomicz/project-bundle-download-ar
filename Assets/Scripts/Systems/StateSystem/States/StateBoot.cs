using Immersed.AR;
using Immersed.Debugging;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Immersed.Systems.StateSystem.States
{
    public class StateBoot : State
    {
        [Header("Next state")]
        [SerializeField] private State _nextState;

        [Header("State dependencies")]
        [SerializeField] private ARContentPlacerController _arContentPlacerController;
        [SerializeField] private Transform _worldCanvas;
        [SerializeField] private ARPlaneManager _arPlaneManager;
        [SerializeField] private ARRaycastDebugger _arRaycastDebugger;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private CanvasContainer _canvasContainer;

        public override void OnEnter()
        {
            base.OnEnter();

            _arRaycastDebugger.Enable();
            _arRaycastDebugger.enabled = true;
            _arPointer.ShowRaycaster(false);
            _arContentPlacerController.Enable();
            _arContentPlacerController.OnContentPlacedEvent += HandleOnContentPlacedEvent;
            _arContentPlacerController.SetItem(_worldCanvas.transform);
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

            _arContentPlacerController.OnContentPlacedEvent -= HandleOnContentPlacedEvent;
            _arContentPlacerController.Disable();
            _arPointer.ShowRaycaster(true);
        }

        private void HandleOnContentPlacedEvent(Vector3 hitPosition)
        {
            _canvasContainer.SetPosition(hitPosition);
            _stateMachine.ChangeState(_nextState);
        }
    }
}