using UnityEngine;
using Spine.Unity;
using System;

namespace Assets.Scripts.Model
{
    public class PlayerModel : MonoBehaviour
    {
        public event Action<bool> ChangeHoverboardStateAction;

        [SerializeField] private float _speedMove;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _runAnimation;
        [SerializeField] private AnimationReferenceAsset _idleAnimation;
        [SerializeField] private AnimationReferenceAsset _hoverBoardAnimation;
        [SerializeField] private AnimationReferenceAsset _portalAnimation;

        private Spine.Animation nextAnimation;

        private bool _isHoverboard = false;
        private bool _isIdle = false;
        private void Awake()
        {
            nextAnimation = _portalAnimation;
            _skeletonAnimation.state.SetEmptyAnimations(1.8f);
            _skeletonAnimation.state.AddAnimation(0, nextAnimation, false, 0.1f);
        }

        private void Update()
        {

            Spine.Animation nextAnim = null;

            if (_isHoverboard)
            {
                gameObject.transform.position += _speedMove * Time.deltaTime * Vector3.right;
                nextAnim = _hoverBoardAnimation;
            }

            if (Input.GetKey(KeyCode.D) && !_isHoverboard)
            {
                gameObject.transform.position += _speedMove * Time.deltaTime * Vector3.right;
                nextAnim = _runAnimation;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A) && !_isHoverboard)
            {
                gameObject.transform.position += _speedMove * Time.deltaTime * -Vector3.right;
                nextAnim = _runAnimation;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(_isIdle)
            {
                nextAnim = _idleAnimation;
            }

            if (nextAnim != null && nextAnim != nextAnimation)
            {
                nextAnimation = nextAnim;
                _skeletonAnimation.state.SetEmptyAnimations(0.1f);
                _skeletonAnimation.state.AddAnimation(0, nextAnimation, true, 0.1f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Hoverboard")
            {
                _isIdle = false;
                _isHoverboard = true;
                ChangeHoverboardStateAction?.Invoke(_isHoverboard);
            }
            else
            {
                _isIdle = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Hoverboard")
            {
                _isHoverboard = false;
                _isIdle = true;
                ChangeHoverboardStateAction?.Invoke(_isHoverboard);
                other.enabled = false;
            }
        }
    }
}
