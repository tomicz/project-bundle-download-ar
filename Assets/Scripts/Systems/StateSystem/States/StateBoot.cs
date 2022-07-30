using Immersed.AR;
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

        public override void OnEnter()
        {
            base.OnEnter();
            _arPlaneManager.enabled = true;
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
            ClearExistingARPlanes();
            _arPlaneManager.enabled = false;
            _arContentPlacerController.OnContentPlacedEvent -= HandleOnContentPlacedEvent;
            _arContentPlacerController.Disable();
        }

        private void HandleOnContentPlacedEvent()
        {
            _stateMachine.ChangeState(_nextState);
        }

        private void ClearExistingARPlanes()
        {
            foreach (var plane in _arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }
    }
}