using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingBall
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform _teleportPoint;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                player.ChangeCheckPoint(_teleportPoint);
                player.StartTeleport();
            }
        }
    }
}