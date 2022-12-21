using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCube : MonoBehaviour
{
    public Transform StartPos => _startPos;

    [SerializeField] private Transform _startPos;

    public void InstantiateSmoothCube(SmoothCube smoothCube,Transform position)
    {
        Instantiate(smoothCube, position);
    }
}
