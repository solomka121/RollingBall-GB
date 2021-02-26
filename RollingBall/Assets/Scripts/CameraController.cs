using UnityEngine;

namespace RollingBall
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Player Player;
        [SerializeField] private float speed;
        private Vector3 _smoothedPlayerPosition;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        private void FixedUpdate()
        {
            _smoothedPlayerPosition = Vector3.Lerp(_smoothedPlayerPosition, Player.transform.position, speed);
            transform.position = _smoothedPlayerPosition + _offset;
        }
    }
}