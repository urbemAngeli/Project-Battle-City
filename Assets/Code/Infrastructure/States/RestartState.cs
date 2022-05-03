using Code.Infrastructure.StateMachine;

namespace Code.Infrastructure.States
{
    public class RestartState : IState
    {

        private readonly GameStateMachine _stateMachine;

        public RestartState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }


        public void Enter() => 
            _stateMachine.ChangeState<GameLoopState>();

        public void Exit()
        {
            
        }
    }
}