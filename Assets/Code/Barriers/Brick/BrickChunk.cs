using System;
using UnityEngine;

namespace Code.Barriers.Brick
{
    public class BrickChunk : MonoBehaviour
    {
        [SerializeField]
        private Brick[] _bricks;

        private void OnValidate()
        {
            if (_bricks == null || _bricks.Length != 4)
                _bricks = new Brick[4];
        }
    }
}