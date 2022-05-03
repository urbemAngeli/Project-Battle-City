namespace Code.Infrastructure.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}