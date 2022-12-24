using UnityEngine;

namespace Assets.Scripts.Model
{
    public class EnemyModel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _myMaterial;
        [SerializeField] private float _moveSpeed;

        private Transform _target;

        private void Start()
        {
            SetupColorMaterial();
        }

        public void MoveEnemy(Transform target)
        {
            _target = target;
        }
        private void Update()
        {
            if (_target == null)
                return;

            if (Vector2.Distance(transform.position, _target.position) > 10)
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
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
