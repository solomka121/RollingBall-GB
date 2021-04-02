using UnityEngine;
using System.Collections;

namespace RollingBall
{
    public class CameraController : IExecute
    {
        private Transform _followTarget;
        private Transform _mainCamera;
        [SerializeField] private float rotationSpeed = 5;
        [SerializeField] private float _speed = 0.08f;
        [SerializeField] private bool shake;
        private Vector3 _smoothedPlayerPosition;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _followTarget = player;
            _mainCamera = mainCamera;
            _offset = mainCamera.transform.position - _followTarget.position;
            _mainCamera.LookAt(_followTarget);

            _offset = _mainCamera.position - _followTarget.position;
        }

        public void Execute()
        {
            _smoothedPlayerPosition = Vector3.Slerp(_smoothedPlayerPosition, _followTarget.position, _speed);
            _mainCamera.transform.position = _smoothedPlayerPosition + _offset;
        }

        public IEnumerator CameraShake(float duration, float magnitude)
        {
            Vector3 startPosition = _mainCamera.position;

            float timeByPass = 0.0f;

            while (timeByPass < duration)
            {
                float x = Random.Range(-1, 1) * magnitude;
                float y = Random.Range(-1, 1) * magnitude;

                _mainCamera.position = new Vector3(startPosition.x + x, startPosition.y + y, startPosition.z);

                timeByPass += Time.deltaTime;

                yield return null;
            }

            _mainCamera.localPosition = startPosition;
        }

        public void ChangeFollowTarget(Transform target)
        {
            _followTarget = target;
        }

    }
}