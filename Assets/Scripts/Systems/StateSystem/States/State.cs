using UnityEngine;

namespace Immersed.Systems.StateSystem
{
    public abstract class State : MonoBehaviour
    {
        protected StateMachine _stateMachine;
        protected StateEventManager _stateEventManager;

        public virtual void OnEnter()
        {

        }

        public abstract void StateUpdate();
        public abstract void StateFixedUpdate();
        public abstract void StateLateUpdate();

        public virtual void OnExit()
        {

        }

        public void SetStateMachine(StateMachine stateMachine) => _stateMachine = stateMachine;

        public void SetEventStateManager(StateEventManager stateEventManager) => _stateEventManager = stateEventManager;
    }
}