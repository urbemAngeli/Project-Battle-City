using System;
using Code.Services.Input;
using UnityEngine;

namespace Code.Tanks
{
    public class Movement
    {
        public Vector2 LookDirection => _input;
        
        private Settings _settings;

        private IInputService _inputService;
        private Rigidbody2DControl _rigidbody2DControl;

        private Vector2 _input;
        private bool _isMoving;

        private AnimatorControl _animatorControl;
        
        
        public Movement(
            Settings settings,
            IInputService inputService,
            Rigidbody2DControl rigidbody2DControl,
            AnimatorControl animatorControl)
        {
            _settings = settings;
            
            _inputService = inputService;
            _rigidbody2DControl = rigidbody2DControl;
            _animatorControl = animatorControl;
        }

        public void Initialize()
        {
            _inputService.OnMovingStarted += StartMoving;
            _inputService.OnMovingEnded += StopMoving;
        }

        public void FixedTick()
        {
            if (_isMoving)
                Move();
        }

        private void StartMoving()
        {
            _isMoving = true;
            Move();
        }

        private void StopMoving()
        {
            _isMoving = false;
            _animatorControl.PlayIdle(_input);
        }

        private void Move()
        {
            _input = _inputService.Axis;
            
            _rigidbody2DControl.MovePosition(_rigidbody2DControl.Position + _input * _settings.Speed * Time.fixedDeltaTime);
            
            _animatorControl.PlayMoving(_input);
        }
        

        [Serializable]
        public struct Settings
        {
            public float Speed;
        }
    }
}