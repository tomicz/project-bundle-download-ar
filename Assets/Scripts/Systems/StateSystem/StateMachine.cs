namespace Immersed.Systems.StateSystem
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State state)
        {
            CurrentState = state;
            state.OnEnter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.OnExit();

            CurrentState = newState;
            newState.OnEnter();
        }
    }
}