using System;
using UnityEngine;

namespace Character
{
    public sealed class CollisionHandler : MonoBehaviour
    {
        public event Action OnCollisionWithObstacle;
        public event Action OnCollisionWithCollectible;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                OnCollisionWithObstacle?.Invoke();

            if (collision.gameObject.CompareTag("Collectible"))
            {
                OnCollisionWithCollectible?.Invoke();
                Destroy(collision.gameObject);
            }
        }
    }
}