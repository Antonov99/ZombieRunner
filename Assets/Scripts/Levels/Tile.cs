using System;
using UnityEngine;

namespace Levels
{

    public class Tile : MonoBehaviour
    {
        [SerializeField]
        private float unspawnDistance;

        private Transform _playerTransform;

        public event Action<GameObject> OnDestroy;

        private void Awake()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            var distance = _playerTransform.position.z - transform.position.z;
            if (distance > unspawnDistance)
                OnDestroy?.Invoke(gameObject);
        }
    }
}