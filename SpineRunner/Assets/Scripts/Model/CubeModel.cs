using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeModel : MonoBehaviour
{
    public Transform End => _end;
    public Transform Begin => _begin;

    [SerializeField] private Transform _end;
    [SerializeField] private Transform _begin;
}