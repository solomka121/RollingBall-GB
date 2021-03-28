using UnityEngine;
using System.Collections;

namespace RollingBall
{
    internal class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private float rotationSpeed = 5;
        [SerializeField] private float _speed = 0.08f;
        [SerializeField] private bool shake;
        private Vector3 _smoothedPlayerPosition;
        private Vector3 _offset;

    /*    //      WALL RUN
        public bool isWallRunning;
        public float cameraTiltZ;
        
        private float cameraTilt; 
        //*/

        private void Start()
        {
            Cursor.visible = false;

            _offset = transform.position - _followTarget.position;
        }

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

        private void FixedUpdate()
        {

            if (shake)
            {
                shake = false;
                StartCoroutine(CameraShake(0.3f, 0.06f));
            }

            /*if (isWallRunning)
            {
                cameraTilt = Mathf.Lerp(cameraTilt, cameraTiltZ , 0.1f);
                transform.rotation = Quaternion.Euler(new Vector3(cameraRotation.x, cameraRotation.y, cameraRotation.z + cameraTilt));
            }
            else
            {
                cameraTilt = Mathf.Lerp(cameraTilt, cameraRotation.z, 0.1f);
                transform.rotation = Quaternion.Euler(new Vector3(cameraRotation.x, cameraRotation.y, cameraRotation.z + cameraTilt));
            }*/
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
        }

        public void ChangeFollowTarget(Transform target)
        {
            _followTarget = target;
        }
    }
}