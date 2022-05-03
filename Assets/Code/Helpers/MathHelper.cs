using UnityEngine;

namespace Code.Helpers
{
    public static class MathHelper
    {
        public static bool IsInsideRectangle(Vector2 center, Vector2 size, Vector2 point)
        {
            Vector3 halfSize = (size / 2) * 1.001f;
        
            bool isInsideX = point.x > (center.x - halfSize.x) && point.x < (center.x + halfSize.x);
            bool isInsideY = point.y > (center.y - halfSize.y) && point.y < (center.y + halfSize.y);

            return isInsideX && isInsideY;
        }
        
        public static int RandomByWeights(params float[] weights)
        {
            float totalWeight = 0;

            for (int i = 0; i < weights.Length; i++) 
                totalWeight += weights[i];

            float chance = Random.Range(0f, totalWeight);
            float accumWeight = 0;
            
            for (int i = 0; i < weights.Length; i++)
            {
                accumWeight += weights[i];

                if (chance <= accumWeight)
                    return i;
            }

            return -1;
        }

        public static bool IsValue(float successWeight, float failWeight)
        {
            return (RandomByWeights(successWeight, failWeight) == 0) 
                ? true 
                : false;
        }
    }
}