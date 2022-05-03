using System;
using Code.Extensions;
using UnityEngine;

namespace Code.Projectiles.Bullet
{
    [Serializable]
    public class Hitting
    {
        public event Action<object> OnHited;
        
        private readonly TriggerChecker2D _checker2D;
        private readonly Movement _movement;

        private Bullet _bullet;
        private int _damage;

        public Hitting(TriggerChecker2D checker2D, Movement movement, Bullet bullet)
        {
            _checker2D = checker2D;
            _movement = movement;
            _bullet = bullet;
        }

        public void Initialize()
        {
            _checker2D.OnEntered += Hit;
        }

        public void Deinitialize()
        {
            _checker2D.OnEntered -= Hit;
        }

        public void SetDamage(int damage) => 
            _damage = damage;

        private void Hit(Collider2D other)
        {
            if (other.TryGetAttachedGameObject(out GameObject foundTarget))
            {
                if (foundTarget.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damage);

                    _movement.StopMoving();
                    
                    OnHited?.Invoke(_bullet);
                }
            }
        }
    }
}