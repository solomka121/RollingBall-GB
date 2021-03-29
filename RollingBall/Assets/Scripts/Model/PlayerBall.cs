using UnityEngine;

namespace RollingBall
{
    public class PlayerBall : PlayerBase , IInteractable
    {
        private Rigidbody _rigidbody;
        public bool IsInteractable { get; } = true;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }

        /* private void OnTriggerEnter(Collider other)
         {
             if (other.tag == "Void")
             {
                 StartRespawn();
             }
         }*/

        public void Action()
        {

        }
    }
}