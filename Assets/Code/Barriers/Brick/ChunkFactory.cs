using System.Collections.Generic;
using UnityEngine;

namespace Code.Barriers.Brick
{
    public class ChunckFactory
    {
        private readonly BrickChunk _brickChunkPrefab;
        
        private List<BrickChunk> _brickChunks = new List<BrickChunk>();

        
        public ChunckFactory(BrickChunk brickChunkPrefab) => 
            _brickChunkPrefab = brickChunkPrefab;

        public void Create(in Vector3 position)
        {
            BrickChunk createdBrickChunk = Object.Instantiate(_brickChunkPrefab);
            createdBrickChunk.transform.position = position;
            _brickChunks.Add(createdBrickChunk);
        }
    }
}