using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerCube : MonoBehaviour
{
    public Transform StartPos => _startPos;

    [SerializeField] private Transform _startPos;
    public void InstantiateCornerCube(CornerCube cornerCube,Transform position)
    {
        Instantiate(cornerCube, position);
    }
}
