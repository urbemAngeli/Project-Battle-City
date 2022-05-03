using System.Collections.Generic;
using Code.Barriers.Brick;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services;
using Code.Infrastructure.StateMachine;
using Code.Projectiles.Bullet;
using Code.Services.Input;
using Code.Services.Map;
using Code.Services.Ticks;
using Code.StaticData;
using Code.Zones;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly SceneData _sceneData;
        private readonly AllServices _services;
        private readonly Transform _gameRoot;
        private readonly GameConfig _config;
        
        private IMapProvider _mapProvider;

        public BootstrapState(
            SceneData sceneData,
            AllServices services,
            Transform gameRoot,
            GameConfig config)
        {
            _sceneData = sceneData;
            _services = services;
            _gameRoot = gameRoot;
            _config = config;
        }
        
        public void Enter()
        {
            RegisterServices();
            InitializeWorld();
        }

        public void Exit()
        {
            
        }

        private void InitializeWorld()
        {
            _mapProvider.CreateMap();
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            
            RegisterTickProcessor();
            
            _services.RegisterSingle<IInputService>(InputService(
                _services.Single<TickProcessor>()));
            
            RegisterMapProvider(_services.Single<IAssetProvider>());

            _services.RegisterSingle<BulletFactory>(new BulletFactory(
                _services.Single<IAssetProvider>(),
                _services.Single<TickProcessor>()));
            
            _services.RegisterSingle<Tanks.Factory>(new Tanks.Factory(
                _services.Single<IAssetProvider>(), 
                _services.Single<IInputService>(),
                _sceneData.PlayerSpawnZones,
                _services.Single<BulletFactory>()));
        }

        private void RegisterMapProvider(IAssetProvider assetProvider)
        {
            IMapProvider mapProvider = new RandomGenerationMap(
                _config.MapGenerationData,
                GetOccupiedZones(), 
                new ChunckFactory(assetProvider.Load<BrickChunk>(AssetPath.BRICK_CHUNK_PATH)));
            
            _mapProvider = _services.RegisterSingle<IMapProvider>(mapProvider);
        }

        private void RegisterTickProcessor()
        {
            GameObject processor = new GameObject("TickProcessor");
            processor.transform.parent = _gameRoot;
            _services.RegisterSingle<TickProcessor>(processor.AddComponent<TickProcessor>());
        }

        private IInputService InputService(TickProcessor _tickProcessor)
        {
            StandaloneInputService service = new StandaloneInputService();
            _tickProcessor.Add(service);
            
            return service;
        }

        private List<Zone> GetOccupiedZones()
        {
            List<Zone> occupiedZones = new List<Zone>();
        
            for (int i = 0; i < _sceneData.PlayerSpawnZones.Count; i++) 
                occupiedZones.Add(_sceneData.PlayerSpawnZones[i]);
            
            for (int i = 0; i < _sceneData.EnemySpawnZones.Count; i++) 
                occupiedZones.Add(_sceneData.EnemySpawnZones[i]);
        
            occupiedZones.Add(_sceneData.BaseZone);
        
            return occupiedZones;
        }
    }
}