using System;
using Code.Infrastructure.Services;
using UnityEngine;

namespace Code.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        
        event Action OnMovingStarted;
        event Action OnMovingEnded;
        event Action OnShootingStarted;
        event Action OnShootingEnded;
    }
}