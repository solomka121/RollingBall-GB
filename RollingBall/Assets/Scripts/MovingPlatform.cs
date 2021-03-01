using UnityEngine;

namespace RollingBall
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Vector3 _moveAmount;
        [SerializeField] private float _moveTime;
        [SerializeField] private LeanTweenType _moveCurve;
        private Rigidbody _rigidbody;
        private float movement = 0;
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Move();
        }

        private void Move()
        {
            LeanTween.move(gameObject, transform.position + _moveAmount , _moveTime).setLoopType(_moveCurve);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                other.transform.parent = transform;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                other.transform.parent = null;
            }
        }
    }
}
