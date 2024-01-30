using UnityEngine;

namespace Sources.PlayerRocket
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SmoothTargetFollower _targetFollower;

        public Camera Camera => _camera;

        public void Init(Transform player) => 
            _targetFollower.SetTarget(player);
    }
}