using System;
using Code.Extensions;
using UnityEngine;

namespace Code.Projectiles.Bullet
{
    public class TriggerChecker2D : MonoBehaviour
    {
        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnExited;

        [SerializeField]
        private Color _color = Color.magenta;
        
        [SerializeField, HideInInspector]
        private Collider2D _collider2D;

        private void OnValidate() => 
            _collider2D = GetComponent<Collider2D>();

        private void OnTriggerEnter2D(Collider2D col) => 
            OnEntered?.Invoke(col);

        private void OnTriggerExit2D(Collider2D col) => 
            OnExited?.Invoke(col);

        private void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = _color.SetAlpha(0.5f);
            Gizmos.DrawCube(Vector2.zero, _collider2D.bounds.size);
        }
    }
}