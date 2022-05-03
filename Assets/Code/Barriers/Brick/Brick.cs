using UnityEngine;

namespace Code.Barriers.Brick
{
    [RequireComponent(typeof(Animator))]
    public class Brick : MonoBehaviour
    {

        [SerializeField, HideInInspector]
        private Animator _animator;

        private AnimatorControl _animatorControl;


        private void OnValidate() => 
            _animator = GetComponent<Animator>();

        private void Awake()
        {
            _animatorControl = new AnimatorControl(_animator);
        }
    }
}