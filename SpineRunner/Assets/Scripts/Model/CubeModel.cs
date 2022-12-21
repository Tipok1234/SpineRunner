using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeModel : MonoBehaviour
{
    public Transform End => _end;

    [SerializeField] private Transform _end;
}