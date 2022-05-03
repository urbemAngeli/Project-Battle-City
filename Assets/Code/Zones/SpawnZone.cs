using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Zones
{
    [Serializable]
    public class SpawnZone : Zone
    {
        public Vector2 GetPosition()
        {
            Vector2 saveSize = new Vector2(_size.x - 2, _size.y - 2);
            Vector2 center = transform.position;
            Vector2 halfSaveSize = saveSize / 2;

            float x = Random.Range(center.x - halfSaveSize.x, center.x + halfSaveSize.x);
            float y = Random.Range(center.y - halfSaveSize.y, center.y + halfSaveSize.y);
        
            return new Vector2(x, y);
        }
    }
}