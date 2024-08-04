using System;
using UnityEngine;

namespace Character
{
    public sealed class CollisionHandler : MonoBehaviour
    {
        public event Action OnCollisionWithObstacle;
        public event Action<GameObject> OnCollisionWithCollectible;

        private void OnCollisionEnter(Collision collision)
        {
            var obj = collision.gameObject;
            
            if (obj.CompareTag("Obstacle"))
                OnCollisionWithObstacle?.Invoke();

            if (obj.CompareTag("Collectible"))
            {
                OnCollisionWithCollectible?.Invoke(obj);
            }
        }
    }
}