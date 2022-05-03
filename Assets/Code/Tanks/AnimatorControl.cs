using System;
using UnityEngine;

namespace Code.Tanks
{
    [Serializable]
    public class AnimatorControl
    {
        private readonly int _inputX_hash = Animator.StringToHash("Input_x");
        private readonly int _inputY_hash = Animator.StringToHash("Input_y");
        private readonly int _isMoving_hash = Animator.StringToHash("IsMoving");
        
        [SerializeField, HideInInspector]
        private readonly Animator _animator;

        public AnimatorControl(Animator animator) => 
            _animator = animator;

        public void PlayIdle(in Vector2 input)
        {
            _animator.SetBool(_isMoving_hash, false);
            
            _animator.SetFloat(_inputX_hash, input.x);
            _animator.SetFloat(_inputY_hash, input.y);
        }

        public void PlayMoving(in Vector2 input)
        {
            _animator.SetBool(_isMoving_hash, true);
            
            _animator.SetFloat(_inputX_hash, input.x);
            _animator.SetFloat(_inputY_hash, input.y);
        }
    }
}