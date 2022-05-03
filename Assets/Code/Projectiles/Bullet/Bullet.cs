using Code.Tanks;
using UnityEngine;

namespace Code.Projectiles.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(TriggerChecker2D))]
    public class Bullet : MonoBehaviour, IFixedTick
    {
        public Hitting Hitting => _hitting;
        
        private Rigidbody2D _rigidbody2D;
        private Rigidbody2DControl _rigidbody2DControl;
        private TriggerChecker2D _triggerChecker2D;
        private Movement _movement;
        private Hitting _hitting;


        public void Construct()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _triggerChecker2D = GetComponent<TriggerChecker2D>();
            
            _rigidbody2DControl = new Rigidbody2DControl(_rigidbody2D);
            _movement = new Movement(_rigidbody2DControl);
            _hitting = new Hitting(_triggerChecker2D, _movement, this);
        }

        public void Fire(in int damage, in float speed, in Vector2 direction)
        {
            _hitting.SetDamage(damage);
            _movement.StartMoving(speed, direction);
        }

        void IFixedTick.FixedTick() => 
            _movement.FixedTick();
    }
}