using Code.Infrastructure.StateMachine;
using Code.Projectiles.Bullet;
using Code.Services.Ticks;
using Code.Tanks;
using Code.Tanks.Player;

namespace Code.Infrastructure.States
{
    public class GameLoopState : IState
    {
        
        private Factory _playerFactory;
        private TickProcessor _tickProcessor;

        public GameLoopState(Factory playerFactory, TickProcessor tickProcessor)
        {
            _playerFactory = playerFactory;
            _tickProcessor = tickProcessor;
        }
        
        public void Enter()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            PlayerTank playerTank = _playerFactory.CreatePlayer();
            _tickProcessor.Add((ITick) playerTank);
            _tickProcessor.Add((IFixedTick) playerTank);
        }

        public void Exit()
        {

        }
    }
}