using System;
using System.Collections.Generic;
using Code.Extensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly bool _isActiveDefault;
        private readonly Transform _container;
        
        private List<T> _poolObjects;
        private List<T> _takenObjects;

        
        public PoolMono(T prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;

            CreatePool(count);
        }
        
        public PoolMono(T prefab, int count, string nameContainer, bool isActiveDefault = true)
        {
            _prefab = prefab;
            _isActiveDefault = isActiveDefault;
            _container = new GameObject(nameContainer).transform;

            CreatePool(count);
        }

        public T Take()
        {
            return HasFreeObject() 
                ? TakeFromPool() 
                : TakeFromNew();
        }

        public void Put(T target)
        {
            if (_takenObjects.TryRemove(target))
            {
                target.gameObject.SetActive(target);
                
                _poolObjects.Add(target);
                
                return;
            }
            
            throw new NullReferenceException("Don't found object in _takenObjects!");
        }

        private void CreatePool(int count)
        {
            _poolObjects = new List<T>();
            _takenObjects = new List<T>();

            T temporary;
            
            for (int i = 0; i < count; i++)
            {
                temporary = CreateObject();
                temporary.gameObject.SetActive(_isActiveDefault);
                
                _poolObjects.Add(temporary);
            }
        }

        private bool HasFreeObject() => 
            _poolObjects.Count > 0;

        private T TakeFromPool()
        {
            T takenObject = _poolObjects.TakeAndRemoveLast();
            _takenObjects.Add(takenObject);

            return takenObject;
        }

        private T TakeFromNew()
        {
            T target = CreateObject();
            _takenObjects.Add(target);

            return target;
        }

        private T CreateObject()
        {
            T createdObject = Object.Instantiate(_prefab, _container);
            createdObject.transform.parent = _container;
            
            return createdObject;
        }
    }
}