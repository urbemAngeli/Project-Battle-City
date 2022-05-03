using Code.Services.Map;
using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "StaticData/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public RandomGenerationMap.Settings MapGenerationData;
    }
}