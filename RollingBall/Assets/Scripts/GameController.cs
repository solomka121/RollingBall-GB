using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace RollingBall
{
    public sealed class GameController : MonoBehaviour
    {
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObject;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private int _countBonuses;

        private Reference _reference;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(player);
            _interactiveObject.AddExecuteObject(_inputController);

            _displayBonuses = new DisplayBonuses(_reference.Bonus);
            foreach (var o in _interactiveObject)
            {
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                }
            }

            _reference.MainMenuButton.onClick.AddListener(LoadMainMenu);
            _reference.MainMenuButton.gameObject.SetActive(false);

        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                interactiveObject.Execute();

            }
        }
        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }
    }
}