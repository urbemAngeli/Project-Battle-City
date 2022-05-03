using System;
using System.Security;
using UnityEngine;

namespace Code.Tanks
{
    [Serializable]
    public class Rigidbody2DControl
    {
        public Vector2 Position => _rigidbody2D.position;
        
        [SerializeField, HideInInspector]
        private Rigidbody2D _rigidbody2D;


        public Rigidbody2DControl(Rigidbody2D rigidbody2D) => 
            _rigidbody2D = rigidbody2D;

        public void MovePosition(in Vector2 position) => 
            _rigidbody2D.MovePosition(position);
    }
}