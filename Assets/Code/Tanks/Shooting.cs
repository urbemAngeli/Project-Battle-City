using System;
using Code.Projectiles.Bullet;
using Code.Services.Input;
using UnityEngine;

namespace Code.Tanks
{
    [Serializable]
    public class Shooting
    {
        private Settings _settings;
        
        private bool _isShooting;
        private float _timer;

        private IInputService _inputService;
        private BulletFactory _bulletFactory;
        
        
        public Shooting(Settings settings, IInputService inputService, BulletFactory bulletFactory)
        {
            _settings = settings;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }

        public void Initialize()
        {
            _inputService.OnShootingStarted += StartShooting;
            _inputService.OnShootingEnded += StopShooting;
        }

        public void Tick()
        {
            if (_isShooting) 
                CalculateShooting();
        }

        private void StartShooting()
        {
            _isShooting = true;
            _timer = _settings.Delay;
            
            Shoot(_inputService.Axis);
        }

        private void StopShooting() => 
            _isShooting = false;

        private void CalculateShooting()
        {
            if (_timer <= 0)
            {
                Shoot(_inputService.Axis);
                _timer = _settings.Delay;
                
                return;
            }
            
            _timer -= Time.deltaTime;
        }
        
        private void Shoot(in Vector2 direction)
        {
            Bullet firedBullet = _bulletFactory.Spawn();
            firedBullet.Fire(_settings.Damage, _settings.Speed, direction);
        }
        
        [Serializable]
        public class Settings
        {
            public int Damage;
            public float Speed;
            public float Delay;
        }
    }
}