using System;
using System.Collections.Generic;
using Code.Infrastructure.Services;
using Code.Projectiles.Bullet;
using UnityEngine;

namespace Code.Services.Ticks
{
    public class TickProcessor : MonoBehaviour, IService
    {
        private List<ITick> _ticks = new List<ITick>();
        private List<IFixedTick> _fixedTicks = new List<IFixedTick>();
        

        public void Add(ITick tick)
        {
            if (!_ticks.Contains(tick))
                _ticks.Add(tick);
        }

        public void Remove(ITick tick)
        {
            if (_ticks.Contains(tick))
                _ticks.Remove(tick);
        }
        
        public void Add(IFixedTick fixedTick)
        {
            if (!_fixedTicks.Contains(fixedTick))
                _fixedTicks.Add(fixedTick);
        }

        public void Remove(IFixedTick fixedTick)
        {
            if (_fixedTicks.Contains(fixedTick))
                _fixedTicks.Remove(fixedTick);
        }

        private void Update()
        {
            for (int i = 0; i < _ticks.Count; i++) 
                _ticks[i].Tick();
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedTicks.Count; i++) 
                _fixedTicks[i].FixedTick();
        }
    }
}