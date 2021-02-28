using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingBall
{
    internal class CheckPoint : MonoBehaviour
    {
        [SerializeField] private bool _isActive = true;
        [SerializeField] private Material _disabled;
        [SerializeField] private Transform _plate;

        private void OnTriggerEnter(Collider other)
        {
            if (_isActive && other.tag == "Player")
            {
                _isActive = false;
                _plate.GetComponent<MeshRenderer>().material = _disabled;
                other.GetComponent<PlayerBall>().ChangeCheckPoint(transform);
                StartCoroutine(PlatePressDown());
            }
        }

        private IEnumerator PlatePressDown()
        {
            while (_plate.position.y > 0)
            {
                float step = 0.002f;
                _plate.position += new Vector3(0, -step, 0);
                step *= 1.15f;
                yield return new WaitForFixedUpdate();
            }
            this.enabled = false;
        }
    }
}
