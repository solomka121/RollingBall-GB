using UnityEngine;
using System.Collections;


namespace RollingBall
{
    internal class FallingPlatform : MonoBehaviour
    {
        [SerializeField] private float _timeToFall;
        [SerializeField] private Vector3 _shrinkSize;
        [SerializeField] private GameObject _timerCube;
        [SerializeField] private float _timeToRecover = 5;
        private Rigidbody _rigidbody;
        private Vector3 _timerScale;
        private Vector3 startPosition;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            startPosition = transform.position;
            _timerScale = _timerCube.transform.localScale;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Fall());
            }
        }

        private IEnumerator Fall()
        {
            LeanTween.scale(_timerCube, _timerCube.transform.localScale - _shrinkSize, _timeToFall).setEaseLinear();
            yield return new WaitForSeconds(_timeToFall);
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.down, ForceMode.Impulse);
            yield return new WaitForSeconds(_timeToRecover);
            _rigidbody.isKinematic = true;
            _timerCube.transform.localScale = _timerScale;
            transform.position = startPosition;
        }


    }
}
