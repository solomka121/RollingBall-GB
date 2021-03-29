using UnityEngine;

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

/*
        private void LateUpdate()
        {
            #region Mouse Rotate

            Quaternion camTurnAnlge = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            Quaternion camTurnAnlgeX = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, Vector3.right);
            _offset = camTurnAnlge * camTurnAnlgeX * _offset;

            #endregion

            #region Position Change

            _smoothedPlayerPosition = Vector3.Slerp(_smoothedPlayerPosition, _followTarget.position, _speed);
            transform.position = _smoothedPlayerPosition + _offset;
            //transform.LookAt(_followTarget.position);

            #endregion
        }

       *//* private void FixedUpdate()
        {

            if (shake)
            {
                shake = false;
                StartCoroutine(CameraShake(0.3f, 0.06f));
            }

        }

        public IEnumerator CameraShake(float duration , float magnitude)
        {
            Vector3 startPosition = transform.position;

            float timeByPass = 0.0f;

            while(timeByPass < duration)
            {
                float x = Random.Range(-1, 1) * magnitude;
                float y = Random.Range(-1, 1) * magnitude;

                transform.position = new Vector3(startPosition.x + x, startPosition.y + y, startPosition.z);

                timeByPass += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = startPosition;
            StopCoroutine(CameraShake(0 , 0));
        }*/

        public void ChangeFollowTarget(Transform target)
        {
            _followTarget = target;
        }

    }
}