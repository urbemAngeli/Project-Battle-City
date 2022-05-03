using Code.Infrastructure.Services;
using Code.Infrastructure.States;
using Code.Services.Ticks;
using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure.StateMachine
{
    public class StatesFactory
    {
        private readonly SceneData _sceneData;
        private readonly AllServices _services;
        private readonly Transform _gameRoot;
        private readonly GameConfig _config;


        public StatesFactory(
            SceneData sceneData,
            AllServices services,
            Transform gameRoot,
            GameConfig config)
        {
            _services = services;
            _gameRoot = gameRoot;
            _config = config;
            _sceneData = sceneData;
        }

        public TState Create<TState>() where TState : class, IState
        {
            if (typeof(TState) == typeof(BootstrapState))
                return new BootstrapState(_sceneData, _services, _gameRoot, _config) as TState;

            if (typeof(TState) == typeof(GameLoopState))
                return new GameLoopState(
                    _services.Single<Tanks.Factory>(),
                    _services.Single<TickProcessor>()) as TState;

            if (typeof(TState) == typeof(RestartState))
                return new RestartState(_services.Single<GameStateMachine>()) as TState;

            return default;
        }
    }
}