using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    public sealed class LocationManager : MonoBehaviour
    {
        [SerializeField]
        private ushort visibleTiles;

        [SerializeField]
        private int preloadAmount;

        [SerializeField]
        private GameObject[] tiles;

        [SerializeField]
        private Transform parent;

        [SerializeField]
        [ShowInInspector]
        private Pool<GameObject> pool;

        [ShowInInspector]
        private readonly HashSet<GameObject> _activeTiles = new();

        [SerializeField]
        private float tileLength;

        private Vector3 _position;

        private int _currentTile;

        private void Awake()
        {
            pool = new Pool<GameObject>(preloadAmount, tiles, parent);
        }

        private void Start()
        {
            for (int i = 0; i < visibleTiles; i++)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            if (_activeTiles.Count <= visibleTiles)
            {
                var random = Random.Range(0, tiles.Length);
                var obj = pool.Get(tiles[random]);

                if (obj == null)
                    return;

                if (_activeTiles.Add(obj))
                {
                    _position = new Vector3(0, 0, _currentTile * tileLength);
                    _currentTile++;
                    obj.transform.position = _position;
                    obj.GetComponent<Tile>().OnDestroy += Unspawn;
                }
            }
        }

        private void Unspawn(GameObject prefab)
        {
            if (_activeTiles.Remove(prefab))
            {
                prefab.GetComponent<Tile>().OnDestroy -= Unspawn;

                pool.Put(prefab);

                Spawn();
            }
        }
    }
}