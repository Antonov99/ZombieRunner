using UnityEngine;

namespace GameEngine.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        
        [SerializeField] 
        private float smoothSpeed;

        [SerializeField]
        private Vector3 offset;

        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}