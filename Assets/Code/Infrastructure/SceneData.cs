using System;
using System.Collections.Generic;
using Code.Zones;

namespace Code.Infrastructure
{
    [Serializable]
    public class SceneData
    {
        public List<SpawnZone> PlayerSpawnZones;
        public List<SpawnZone> EnemySpawnZones;
        public Zone BaseZone;
    }
}