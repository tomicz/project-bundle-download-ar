using Immersed.AR;
using UnityEngine;

namespace Immersed.Systems.StateSystem.States
{
    public class StateBoot : State
    {
        [Header("Next state")]
        [SerializeField] private State _nextState;

        [Header("State dependencies")]
        [SerializeField] private ARContentPlacerController _arContentPlacerController;
        [SerializeField] private CanvasContainer _canvasContainer;

        public override void OnEnter()
        {
            base.OnEnter();

            _arContentPlacerController.SetItem(_canvasContainer.transform);
            _arContentPlacerController.OnContentPlacedEvent += HandleOnContentPlacedEvent;

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
        }

        private void HandleOnContentPlacedEvent(Vector3 hitPosition)
        {
            _stateMachine.ChangeState(_nextState);
        }
    }
}