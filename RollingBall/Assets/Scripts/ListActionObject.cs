using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace RollingBall
{
    public sealed class ListActionObject
    {
        private IAction[] _actionObjects;
        private int _index = -1;

        public ListActionObject()
        {
           
        }

        public void AddActionObject(IAction action)
        {
            if (_actionObjects == null)
            {
                _actionObjects = new[] { action };
                return;
            }
            Array.Resize(ref _actionObjects, Length + 1);
            _actionObjects[Length - 1] = action;
        }

        public IAction this[int index]
        {
            get => _actionObjects[index];
            private set => _actionObjects[index] = value;
        }

        public int Length => _actionObjects.Length;

    }

}