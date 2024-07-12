using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Levels
{
    [Serializable]
    public sealed class Pool<T> where T : Object
    {
        [ShowInInspector]
        private readonly Dictionary<string, List<T>> _objects;

        private readonly int _reservationAmount;
        private readonly T[] _prefabs;
        private readonly Vector3 _spawnPosition;
        private readonly Quaternion _spawnRotation;
        private readonly Transform _parent;

        public Pool(int reservationAmount, T[] prefabs, Transform parent)
        {
            _objects = new Dictionary<string, List<T>>();

            _reservationAmount = reservationAmount;
            _prefabs = prefabs;
            _spawnPosition = Vector3.zero;
            _spawnRotation = Quaternion.identity;
            _parent = parent;

            Reserve();
        }

        private void Reserve()
        {
            foreach (var prefab in _prefabs)
            {
                if (!_objects.ContainsKey(prefab.name))
                {
                    _objects[prefab.name] = new List<T>();
                }

                for (int i = 0; i < _reservationAmount; i++)
                {
                    T obj = Object.Instantiate(prefab, _spawnPosition, _spawnRotation, _parent);

                    obj.name = obj.name.Replace("(Clone)", "");

                    _objects[prefab.name].Add(obj);
                    SetActive(obj, false);
                }
            }
        }

        public T Get(T prefab)
        {
            if (!_objects.ContainsKey(prefab.name))
            {
                _objects[prefab.name] = new List<T>();
            }

            T obj = _objects[prefab.name].Count > 0
                ? _objects[prefab.name][^1]
                : Object.Instantiate(prefab, _spawnPosition, _spawnRotation, _parent);

            SetActive(obj, true);
            _objects[prefab.name].Remove(obj);

            return obj;
        }

        public void Put(T obj)
        {
            obj.name = obj.name.Replace("(Clone)", "");

            if (!_objects.ContainsKey(obj.name))
            {
                _objects[obj.name] = new List<T>();
            }

            SetActive(obj, false);
            _objects[obj.name].Add(obj);

            if (_parent != null)
                SetParent(obj);
        }

        private void SetActive(T obj, bool value)
        {
            if (obj is MonoBehaviour monoBehaviour)
                monoBehaviour.gameObject.SetActive(value);

            else if (obj is GameObject gameObject)
                gameObject.SetActive(value);
        }

        private void SetParent(T obj)
        {
            if (obj is MonoBehaviour monoBehaviour)
            {
                Transform transform = monoBehaviour.transform;

                InstallParent(transform);
            }


            else if (obj is GameObject gameObject)
            {
                Transform transform = gameObject.transform;

                InstallParent(transform);
            }

            else if (obj is Transform transform)
            {
                InstallParent(transform);
            }

            return;

            void InstallParent(Transform transform)
            {
                if (transform.parent != _parent)
                    transform.SetParent(_parent);
            }
        }
    }
}