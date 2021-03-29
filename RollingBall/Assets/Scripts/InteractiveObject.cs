using UnityEngine;
using Random = UnityEngine.Random;

namespace RollingBall
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IExecute
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction(Collider other);

        private void Start()
        {
            Action();
        }

        public abstract void Execute();

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            print(other.name);
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                print("not int");
                return;
            }
            Interaction(other);
            Destroy(gameObject);
        }
    }
}