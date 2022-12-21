using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Model;

namespace Assets.Scripts.Controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private float _offset;
        [SerializeField] private float _offsetSmoothing;

        private Vector3 _playerPos;
        void Update()
        {
            _playerPos = new Vector3(_playerModel.transform.position.x, _playerModel.transform.position.y, transform.position.z);

            if(_playerModel.transform.localScale.x > 0f)
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
