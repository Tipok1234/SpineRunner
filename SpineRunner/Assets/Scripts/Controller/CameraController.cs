using UnityEngine;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private float _offset;
        [SerializeField] private float _offsetSmoothing;
        [SerializeField] private float _offsetY;
        [SerializeField] private float _angleX;

        private Vector3 _playerPos;
        private Transform _target;
        private void Awake()
        {
            _gameManager.GameStartedAction += OnGameStarted;
        }

        private void OnDestroy()
        {
            _gameManager.GameStartedAction -= OnGameStarted;
        }
        private void OnGameStarted(Transform target)
        {
            _target = target;
            transform.rotation = Quaternion.Euler(_angleX, 0, 0);
        }
        private void LateUpdate()
        {
            if (_target == null)
                return;

            _playerPos = new Vector3(_target.transform.position.x, _target.transform.position.y + _offsetY, transform.position.z);

            if (_target.transform.localScale.x > 0f)
            {
                _playerPos = new Vector3(_playerPos.x + _offset, _playerPos.y, _playerPos.z);
            }
            else
            {
                _playerPos = new Vector3(_playerPos.x - _offset, _playerPos.y, _playerPos.z);
            }

            transform.position = Vector3.Lerp(transform.position, _playerPos, _offsetSmoothing * Time.deltaTime);
        }
    }
}
