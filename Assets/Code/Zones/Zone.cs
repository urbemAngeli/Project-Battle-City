using Code.Extensions;
using Code.Helpers;
using UnityEngine;

namespace Code.Zones
{
    public abstract class Zone : MonoBehaviour
    {
        [SerializeField]
        protected Vector2 _size = Vector2.one;

        [SerializeField]
        private Color _color = Color.magenta;
    
    
        private void OnDrawGizmos()
        {
            Gizmos.color = _color.SetAlpha(0.5f);
            Gizmos.DrawCube(transform.position, _size);
        }
    
        public bool IsInsideZone(in Vector2 testPoint) => 
            MathHelper.IsInsideRectangle(transform.position, _size, testPoint);
    }
}