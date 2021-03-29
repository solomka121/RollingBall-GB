using UnityEngine;
using UnityEngine.UI;

namespace RollingBall
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Button _mainMenuButton;
        private GameObject _bonus;
        private Canvas _canvas;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public Button MainMenuButton
        {
            get
            {
                if (_mainMenuButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/MainMenuButton");
                    _mainMenuButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _mainMenuButton;
            }
        }

        public GameObject Bonus
        {
            get
            {
                if (_bonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonus");
                    _bonus = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _bonus;
            }
        }


        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }
                
                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }

}
