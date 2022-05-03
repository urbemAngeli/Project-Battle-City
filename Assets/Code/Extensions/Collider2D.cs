using UnityEngine;

namespace Code.Extensions
{
    public static class Collider2DExtensions
    {
        public static bool TryGetAttachedGameObject(this Collider2D collider2D, out GameObject foundRoot)
        {
            foundRoot = collider2D.attachedRigidbody?.gameObject;
            return foundRoot != null;
        }
    }
}