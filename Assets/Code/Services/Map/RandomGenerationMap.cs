using System;
using System.Collections.Generic;
using Code.Barriers.Brick;
using Code.Helpers;
using Code.Zones;
using UnityEngine;

namespace Code.Services.Map
{
    public class RandomGenerationMap : IMapProvider
    {
        private readonly Settings _settings;
        private readonly List<Zone> _occupiedZones;
        private readonly ChunckFactory _brickChunckFactory;


        public RandomGenerationMap(Settings settings, List<Zone> occupiedZones, ChunckFactory brickChunckFactory)
        {
            _settings = settings;
            _occupiedZones = occupiedZones;
            _brickChunckFactory = brickChunckFactory;
        }

        public void CreateMap()
        {
            float x = -15;
            float y = -15;

            Vector2 position;

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    position = new Vector2(x, y);
                    
                    if (HasFreeTile(position))
                        GenerateTile(position);

                    x += 2;
                }

                x = -15;
                y += 2;
            }
        }

        // private void GenerateTile(in Vector3 position) => 
        //     _brickFactory.Create(position);

        private void GenerateTile(in Vector3 position)
        {
            bool isGeneration = MathHelper.IsValue(
                _settings.GenerationWeight, 
                _settings.NoGenerationWeight);
        
            if (isGeneration) 
                _brickChunckFactory.Create(position);
        }

        private bool HasFreeTile(in Vector2 position)
        {
            for (int i = 0; i < _occupiedZones.Count; i++)
            {
                if (_occupiedZones[i].IsInsideZone(position))
                    return false;
            }

            return true;
        }
        
        [Serializable]
        public class Settings
        {
            public float GenerationWeight = 0.5f;
            public float NoGenerationWeight = 1.2f;
        }
    }
}