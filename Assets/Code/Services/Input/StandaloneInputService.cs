using System;
using Code.Services.Ticks;
using UnityEngine;

namespace Code.Services.Input
{
    public class StandaloneInputService : IInputService, ITick
    {
        private readonly KeyCode[] MovementButtons = new[]
        {
            KeyCode.W,
            KeyCode.S,
            KeyCode.A,
            KeyCode.D
        };

        public event Action OnMovingStarted;
        public event Action OnMovingEnded;
        
        public event Action OnShootingStarted;
        public event Action OnShootingEnded;

        public Vector2 Axis
        {
            get
            {
                if (UnityEngine.Input.GetKey(KeyCode.W))
                    return new Vector2(0, 1);
                
                if (UnityEngine.Input.GetKey(KeyCode.S))
                    return new Vector2(0, -1);
                
                if (UnityEngine.Input.GetKey(KeyCode.A))
                    return new Vector2(-1, 0);
                
                if (UnityEngine.Input.GetKey(KeyCode.D))
                    return new Vector2(1, 0);
                
                return Vector2.zero;
            }
        }

        public void Tick()
        {
            CheckMoving();
            CheckShooting();
        }

        private void CheckShooting()
        {
           if(UnityEngine.Input.GetMouseButtonDown(0))
               OnShootingStarted?.Invoke();
           
           if(UnityEngine.Input.GetMouseButtonUp(0))
               OnShootingEnded?.Invoke();
        }

        private void CheckMoving()
        {
            CheckStartingMoving();
            CheckEndingMoving();
        }

        private void CheckStartingMoving()
        {
            for (int i = 0; i < MovementButtons.Length; i++)
            {
                if (UnityEngine.Input.GetKeyDown(MovementButtons[i]))
                    OnMovingStarted?.Invoke();
            }
        }

        private void CheckEndingMoving()
        {
            for (int i = 0; i < MovementButtons.Length; i++)
            {
                if (UnityEngine.Input.GetKeyUp(MovementButtons[i]))
                    OnMovingEnded?.Invoke();
            }
        }
    }
}