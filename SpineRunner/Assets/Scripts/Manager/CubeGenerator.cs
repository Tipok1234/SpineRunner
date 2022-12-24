using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class CubeGenerator : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private CubeModel[] _cubePrefabs;
        [SerializeField] private CubeModel _firstCube;

        private Transform _target;

        private List<CubeModel> _spawnedCubes = new List<CubeModel>();

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
            _spawnedCubes.Add(_firstCube);
            Instantiate(_firstCube);
        }
        private void LateUpdate()
        {
            if (_target == null)
                return;

            if (_target.position.x > _spawnedCubes[_spawnedCubes.Count - 1].End.position.x - 35)
            {
                SpawnCube();
            }

        }
        private void SpawnCube()
        {
            CubeModel newCube = Instantiate(_cubePrefabs[Random.Range(0, _cubePrefabs.Length)]);
            var lastCube = _spawnedCubes[_spawnedCubes.Count - 1];

            newCube.transform.position = lastCube.End.position - newCube.Begin.localPosition;
            _spawnedCubes.Add(newCube);


            if (_spawnedCubes.Count >= 5)
            {
                _spawnedCubes.Remove(_spawnedCubes[0]);
                Destroy(_spawnedCubes[0].gameObject);
            }
        }
    }
}
