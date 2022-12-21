using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private CubeModel[] _cubePrefabs;

    [SerializeField] private CubeModel _firstCube;

    private List<CubeModel> _spawnedCubes = new List<CubeModel>();

    private void Start()
    {
        _spawnedCubes.Add(_firstCube);
    }
    private void Update()
    {
        if (_player.position.x > _spawnedCubes[_spawnedCubes.Count - 1].End.position.x - 35)
        {
            SpawnCube();
        }

        //if (_player.position.x > _spawnedCubes[_spawnedCubes.Count - 1].End.position.x + 35)
        //{
        //    Destroy(_spawnedCubes[0].gameObject);
        //}
    }
    private void SpawnCube()
    {
        CubeModel newCube = Instantiate(_cubePrefabs[Random.Range(0,_cubePrefabs.Length)]);
        var lastCube = _spawnedCubes[_spawnedCubes.Count - 1];

        var newPos = lastCube.End.position;
        newCube.transform.position = newPos;
        _spawnedCubes.Add(newCube);
    }
}
