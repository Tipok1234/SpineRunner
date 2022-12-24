using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.UI
{
    public class MainWindow : MonoBehaviour
    {
        public event Action StartGameAction;

        [SerializeField] private Button _startButton;
        [SerializeField] private Canvas _mainCanvas;

        private void Awake()
        {
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _mainCanvas.enabled = !_mainCanvas.enabled;
            StartGameAction?.Invoke();
        }
    }
}
