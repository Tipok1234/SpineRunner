using UnityEngine;
using Spine.Unity;

namespace Assets.Scripts.Model
{
    public class PlayerModel : MonoBehaviour
    {
        [SerializeField] private float _speedMove;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;

        [SerializeField] private AnimationReferenceAsset _runAnimation;
        [SerializeField] private AnimationReferenceAsset _idleAnimation;
        [SerializeField] private AnimationReferenceAsset _hoverBoardAnimation;
        [SerializeField] private AnimationReferenceAsset _portalAnimation;

        [SerializeField] private EnemyModel _enemyModel;

        [SerializeField] private LayerMask _smoothLayer;
        [SerializeField] private LayerMask _cornerLayer;

        private string XAxis = "Horizontal";

        private Vector2 input = Vector2.zero;

        private Spine.Animation nextAnimation;
        private void Awake()
        {
            nextAnimation = _portalAnimation;
            _skeletonAnimation.state.SetEmptyAnimations(1.8f);
            _skeletonAnimation.state.AddAnimation(0, nextAnimation, true, 0.1f);
        }

        private void Update()
        {
            input.x = Input.GetAxis(XAxis);

            _enemyModel.MoveEnemy(gameObject.transform);

            var isSmooth = Physics.CheckSphere(transform.position, 0.5f, _smoothLayer);
            var isCorner = Physics.CheckSphere(transform.position, 0.5f, _cornerLayer);

            Spine.Animation nextAnim = null;

            if(isSmooth && input.x == 0)
            {
                nextAnim = _idleAnimation;
            }
            else if(isSmooth && /*input.x != 0*/ Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += _speedMove * Time.deltaTime * Vector3.right;
                nextAnim = _runAnimation;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _enemyModel.SetupColorMaterial();
            }
            else if(isSmooth && Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position += _speedMove * Time.deltaTime * -Vector3.right;
                nextAnim = _runAnimation;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                _enemyModel.SetupColorMaterial();
            }
            else if(isCorner)
            {
                gameObject.transform.position += _speedMove * Time.deltaTime * Vector3.right;
                nextAnim = _hoverBoardAnimation;
                _enemyModel.ChangeColorMaterial();
            }

            if (nextAnim != null && nextAnim != nextAnimation)
            {
                nextAnimation = nextAnim;

                _skeletonAnimation.state.SetEmptyAnimations(0.1f);
                _skeletonAnimation.state.AddAnimation(0, nextAnimation, true, 0.1f);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }
}
