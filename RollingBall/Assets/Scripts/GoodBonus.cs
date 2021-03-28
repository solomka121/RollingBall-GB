using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private Material _material;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;

        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();

            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(0.5f, 1.0f);
        }

        protected override void Interaction()
        {
            _displayBonuses.Display(5);
            // Add bonus
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

