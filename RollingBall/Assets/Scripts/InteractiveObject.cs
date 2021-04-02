using UnityEngine;
using Random = UnityEngine.Random;

namespace RollingBall
{
    public abstract class InteractiveObject : MonoBehaviour , IExecute
    {
        protected Color _color;
        private bool _isInteractable;
        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }
        protected abstract void Interaction(Collider other);

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        public abstract void Execute();
        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            IsInteractable = false;
            Interaction(other);

        }
    }
}