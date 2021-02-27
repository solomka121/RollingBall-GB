using UnityEngine;

namespace RollingBall
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private float speed;
        private Vector3 _smoothedPlayerPosition;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - _followTarget.position;
        }

        private void FixedUpdate()
        {
            _smoothedPlayerPosition = Vector3.Lerp(_smoothedPlayerPosition, _followTarget.position, speed);
            transform.position = _smoothedPlayerPosition + _offset;
        }

        public void ChangeFollowTarget(Transform target)
        {
            _followTarget = target;
        }
    }
}