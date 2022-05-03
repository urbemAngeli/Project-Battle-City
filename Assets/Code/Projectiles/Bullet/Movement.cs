using Code.Tanks;
using UnityEngine;

namespace Code.Projectiles.Bullet
{
    public class Movement
    {
        private Rigidbody2DControl _rigidbody2DControl;
        
        private float _speed;
        private Vector2 _direction;
        private bool _isMoving;

        public Movement(Rigidbody2DControl rigidbody2DControl)
        {
            _rigidbody2DControl = rigidbody2DControl;
        }

        public void StartMoving(in float speed, in Vector2 direction)
        {
            _speed = speed;
            _direction = direction;

            _isMoving = true;
        }

        public void StopMoving() => 
            _isMoving = false;

        public void FixedTick()
        {
            if(_isMoving)
                Move();
        }

        private void Move()
        {
            Vector2 movement = _direction * _speed * Time.fixedDeltaTime;
            _rigidbody2DControl.MovePosition(movement);
        }
    }
}