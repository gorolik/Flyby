using UnityEngine;

namespace Sources
{
    public class SmoothTargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _followHorizontal = true;

        private void LateUpdate()
        {
            if (!_target)
            {
                Debug.LogWarning("Please set target for target follower");
                return;
            }

            Vector3 desiredPosition = _target.position + _offset;

            if (!_followHorizontal)
                desiredPosition.x = transform.position.x;
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }

        public void SetTarget(Transform target) => 
            _target = target;
    }
}
