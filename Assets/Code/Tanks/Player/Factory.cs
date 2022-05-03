using System.Collections.Generic;
using Code.Extensions;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services;
using Code.Projectiles.Bullet;
using Code.Services.Input;
using Code.Tanks.Player;
using Code.Zones;
using UnityEngine;

namespace Code.Tanks
{
    public class Factory : IService
    {
        
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;
        private readonly List<SpawnZone> _spawnZones;
        private readonly BulletFactory bulletFactory;

        public Factory(IAssetProvider assetProvider,
            IInputService inputService, 
            List<SpawnZone> spawnZones,
            BulletFactory bulletFactory)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
            _spawnZones = spawnZones;
            this.bulletFactory = bulletFactory;
        }

        public PlayerTank CreatePlayer()
        {
            PlayerTank player = _assetProvider.Instantiate<PlayerTank>(AssetPath.PLAYER_TANK_PATH);
            player.transform.position = _spawnZones.GetSpawnPosition();
            player.Construct(_inputService, bulletFactory);

            return player;
        }
    }
}