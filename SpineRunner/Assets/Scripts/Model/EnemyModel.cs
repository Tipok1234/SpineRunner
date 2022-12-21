using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class EnemyModel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _myMaterial;
        [SerializeField] private float _moveSpeed;

        private void Start()
        {
            SetupColorMaterial();
        }
        private void FixedUpdate()
        {
            gameObject.transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
        }
        public void SetupColorMaterial()
        {
            _myMaterial.color = Color.blue;
        }

        public void ChangeColorMaterial()
        {
            _myMaterial.color = Color.yellow;
        }
    }
}
