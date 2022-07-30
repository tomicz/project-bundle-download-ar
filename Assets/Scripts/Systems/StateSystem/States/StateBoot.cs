using Immersed.AR;
using UnityEngine;

namespace Immersed.Systems.StateSystem.States
{
    public class StateBoot : State
    {
        [SerializeField] private ARContentPlacerController _arContentPlacerController;
        [SerializeField] private Transform _worldCanvas;

        public override void OnEnter()
        {
            base.OnEnter();
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
        }
    }
}