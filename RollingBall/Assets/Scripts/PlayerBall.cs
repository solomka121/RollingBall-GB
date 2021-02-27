using UnityEngine;

namespace RollingBall
{
    internal class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Void")
            {
                StartRespawn();
            }
        }
    }
}