using System.Collections;
using UnityEngine;
using Assets.Scripts.Model;
using Assets.Scripts.UI;
using System;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public event Action<Transform> GameStartedAction;

        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private EnemyModel _enemyModel;
        [SerializeField] private MainWindow _mainWindow;

        [SerializeField] private Transform _playerPos;
        [SerializeField] private Transform _enemyPos;

        private EnemyModel _enemy;
        private void Start()
        {
            _mainWindow.StartGameAction += OnStartGame;
        }

        private void OnDestroy()
        {
            _mainWindow.StartGameAction -= OnStartGame;
            _playerModel.ChangeHoverboardStateAction -= OnChangeStateHoverboard;
        }

        private void OnStartGame()
        {
            var newPlayer = Instantiate(_playerModel, _playerPos);
            GameStartedAction?.Invoke(newPlayer.transform);

            newPlayer.ChangeHoverboardStateAction += OnChangeStateHoverboard;

            StartCoroutine(WaitEnemy(newPlayer));
        }

        private IEnumerator WaitEnemy(PlayerModel player)
        {
            yield return new WaitForSeconds(2f);

            var newEnemy = Instantiate(_enemyModel, _enemyPos);
            newEnemy.MoveEnemy(player.transform);

            _enemy = newEnemy;
        }

        private void OnChangeStateHoverboard(bool state)
        {
            if (state)
                _enemy.ChangeColorMaterial();
            else
                _enemy.SetupColorMaterial();
        }
    }
}
