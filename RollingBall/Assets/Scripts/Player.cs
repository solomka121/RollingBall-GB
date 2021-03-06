﻿using UnityEngine;
using System.Collections;

namespace RollingBall
{
    internal class Player : MonoBehaviour
    {
        public Transform camera;
        private CameraController _cameraController;

        public float Speed = 3.0f;
        private Rigidbody _rigidbody;
        private Transform _lastCheckPoint { get; set; }

        private Vector3 startScale;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _cameraController = camera.GetComponent<CameraController>();
            startScale = transform.localScale;
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

            if (movement.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y;

                Vector3 movementDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //_rigidbody.velocity = new Vector3(Mathf.Clamp(_rigidbody.velocity.x, -1, 1) , 0 , Mathf.Infinity), 0 , Mathf.Clamp(_rigidbody.velocity.z, -1, 1));
                _rigidbody.AddForce(movementDirection * Speed);
            }

        }

        public void ChangeCheckPoint(Transform checkPoint)
        {
            _lastCheckPoint = checkPoint;
        }

        protected void StartRespawn()
        {
            _cameraController.ChangeFollowTarget(_lastCheckPoint);
            StartCoroutine(Respawn());
            
        }
        private IEnumerator Respawn()
        {
            while (transform.localScale != Vector3.zero)
            {
                float step = 0.05f;
                transform.localScale -= new Vector3(step , step , step);
                step *= 1.4f;
                yield return new WaitForFixedUpdate();
            }

            transform.position = _lastCheckPoint.position;
            _rigidbody.velocity = Vector3.zero;
            _cameraController.ChangeFollowTarget(transform);

            while (transform.localScale != startScale)
            {
                float step = 0.05f;
                transform.localScale += new Vector3(step, step, step);
                step *= 1.4f;
                yield return new WaitForFixedUpdate();
            }
            transform.localScale = startScale;
            StopCoroutine(Respawn());
        }

        public void StartTeleport()
        {
            _cameraController.ChangeFollowTarget(_lastCheckPoint);
            StartCoroutine(Teleport());

        }
        private IEnumerator Teleport()
        {
            while (transform.localScale != Vector3.zero)
            {
                float step = 0.05f;
                transform.localScale -= new Vector3(step, step, step);
                step *= 1.4f;
                yield return new WaitForFixedUpdate();
            }

            transform.position = _lastCheckPoint.position;
            _rigidbody.velocity = Vector3.zero;
            _cameraController.ChangeFollowTarget(transform);

            while (transform.localScale != startScale)
            {
                float step = 0.05f;
                transform.localScale += new Vector3(step, step, step);
                step *= 1.4f;
                yield return new WaitForFixedUpdate();
            }
            transform.localScale = startScale;
            StopCoroutine(Teleport());
        }
    }

    

}
