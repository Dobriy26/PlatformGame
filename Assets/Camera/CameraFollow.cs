using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform CameraTarget;
        public float CameraSpeed = 2.5f;

        private void FixedUpdate()
        {
            var _newPosition = Vector2.Lerp(transform.position, 
                CameraTarget.position, Time.deltaTime * CameraSpeed);
            var CameraPosition = new Vector3(_newPosition.x, _newPosition.y, -10);
            transform.position = CameraPosition;
        }
        
    }
}