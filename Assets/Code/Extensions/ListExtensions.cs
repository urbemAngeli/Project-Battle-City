using System;
using System.Collections.Generic;
using Code.Zones;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.Extensions
{
    public static class ListExtensions
    {
        public static bool TryRemove<T>(this List<T> list, T target)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(target))
                {
                    list.RemoveAt(i);
                    return true;
                }
            }
            
            return false;
        }
        
        public static T TakeAndRemoveLast<T>(this List<T> list) where T : class
        {
            if (list.Count > 0)
            {
                int lastIndex = list.Count - 1;

                T target = list[lastIndex];
                list.RemoveAt(lastIndex);

                return target;
            }

            throw new IndexOutOfRangeException("Count of list == 0!");
        }

        public static Vector2 GetSpawnPosition(this List<SpawnZone> _spawnZones)
        {
            int indexZone = Random.Range(0, _spawnZones.Count);
            
            return _spawnZones[indexZone].GetPosition();
        }
    }
}