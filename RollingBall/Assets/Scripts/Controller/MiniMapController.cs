using System;
using UnityEngine;

namespace RollingBall {
    public class MiniMapController : IExecute , IAction
    {
        private MiniMapView _miniMap;
        private Transform _player;

        private Vector3 _offset;

        public MiniMapController(MiniMapView miniMap, Transform player)
        {
            _miniMap = miniMap;
            _player = player;
        }

        public void Action()
        {
            Vector3 rot = _miniMap.transform.rotation.eulerAngles;
            _miniMap.transform.rotation = Quaternion.Euler(new Vector3(rot.x, Camera.main.transform.rotation.eulerAngles.y , rot.z));

            _offset = _miniMap.transform.position;
        }

        public void Execute()
        {
            _miniMap.transform.position = _player.position + _offset;
        }

    }
}
