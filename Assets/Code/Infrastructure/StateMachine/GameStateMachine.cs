using Code.Infrastructure.Services;

namespace Code.Infrastructure.StateMachine
{
    public class GameStateMachine : IService
    {
        private readonly StatesFactory _factory;

        private IState _currentState;
        
        public GameStateMachine(StatesFactory factory) => 
            _factory = factory;

        public void ChangeState<TState>() where TState : class, IState 
        {
            if(_currentState != null)
                _currentState.Exit();
            
            _currentState = _factory.Create<TState>();
            _currentState.Enter();
        }
    }
}