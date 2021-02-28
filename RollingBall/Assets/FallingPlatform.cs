using UnityEngine;
using System.Collections;


namespace RollingBall
{
    internal class FallingPlatform : MonoBehaviour
    {
        [SerializeField] private float _timeToFall;
        [SerializeField] private Vector3 _shrinkSize;
        [SerializeField] private GameObject _timerCube;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Fall());
                LeanTween.scale(_timerCube, _timerCube.transform.localScale - _shrinkSize, _timeToFall).setEaseLinear();
            }
        }

        private IEnumerator Fall()
        {
            yield return new WaitForSeconds(_timeToFall);
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.down, ForceMode.Impulse);
            Destroy(gameObject, 5f);
        }

    }
}
