using System;
using Code.Projectiles.Bullet;
using Code.Services.Input;
using Code.Services.Ticks;
using UnityEngine;

namespace Code.Tanks.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerTank : MonoBehaviour, ITick, IFixedTick
    {
        [SerializeField]
        private Movement.Settings _movementSettings;

        [SerializeField]
        private Shooting.Settings _shootingSettings;

        private AnimatorControl _animatorControl;
        private Rigidbody2DControl _rigidbody2DControl;
        private Movement _movement;
        private Shooting _shooting;

        
        public void Construct(IInputService inputService, BulletFactory bulletFactory)
        {
            Animator animator = GetComponent<Animator>();
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            
            _animatorControl = new AnimatorControl(animator);
            _rigidbody2DControl = new Rigidbody2DControl(rigidbody2D);
            _movement = new Movement(_movementSettings, inputService, _rigidbody2DControl, _animatorControl);
            _shooting = new Shooting(_shootingSettings, inputService, bulletFactory);
        }

        private void Start()
        {
            _movement.Initialize();
            _shooting.Initialize();
        }

        void ITick.Tick() => 
            _shooting.Tick();

        void IFixedTick.FixedTick() => 
            _movement.FixedTick();
    }
}