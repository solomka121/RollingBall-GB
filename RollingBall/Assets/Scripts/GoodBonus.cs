using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        public event Action<int> OnPointChange = delegate (int i) { };

        [SerializeField] private float _speedMultiplayer;
        [SerializeField] private float _speedBoostDuration;
        private Material _material;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = UnityEngine.Random.Range(0.5f, 1.0f);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; };
            Fly();
            Flicker();
        }

        protected override void Interaction(Collider other)
        {
            print(other.name);
            _displayBonuses.Display(5);
            //other.GetComponent<PlayerBall>().BoostSpeed(_speedBoostDuration, _speedMultiplayer);
            
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}

