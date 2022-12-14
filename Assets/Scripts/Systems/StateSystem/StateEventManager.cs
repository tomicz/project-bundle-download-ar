using UnityEngine;

namespace Immersed.Systems.StateSystem
{
    public class StateEventManager : MonoBehaviour
    {
        [Header("State dependencies")]
        [SerializeField] private State _bootState;
        [SerializeField] private State[] _states;

        private StateMachine _stateMachine;

        private void Awake()
        {
            SetupStateMachine();
        }

        private void Update()
        {
            _stateMachine?.CurrentState?.StateUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine?.CurrentState?.StateFixedUpdate();
        }

        private void LateUpdate()
        {
            _stateMachine?.CurrentState?.StateLateUpdate();
        }

        private void SetupStateMachine()
        {
            _stateMachine = new StateMachine();

            SetupStateDependenies(_stateMachine);

            if (_bootState != null)
            {
                _stateMachine.Initialize(_bootState);
            }
            else
            {
                Debug.LogWarning("Boot state is not referenced in the inspector. Drag StateBoot reference to the inspector");
            }
        }

        private void SetupStateDependenies(StateMachine stateMachine)
        {
            if(_states.Length > 0)
            {
                foreach (var state in _states)
                {
                    state.SetEventStateManager(this);
                    state.SetStateMachine(stateMachine);
                }
            }
        }
    }
}