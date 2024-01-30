using Sources.PlayerRocket;
using UnityEngine;

namespace Sources.Levels
{
    public class RadiationBounds : MonoBehaviour
    {
        [SerializeField] private float _damage = 10;
        
        private Rocket _playerRocket;
        private bool _playerInBounds;

        private float _maxPlayerHeight;

        public void Init(Rocket playerRocket)
        {
            _playerRocket = playerRocket;
            _maxPlayerHeight = _playerRocket.Position.y;
        }

        private void Update()
        {
            FollowPlayer();
            TryDamagePlayer();
        }

        private void TryDamagePlayer()
        {
            if (_playerInBounds)
                _playerRocket.Durability.Damage(_damage * Time.deltaTime);
        }

        private void FollowPlayer()
        {
            var playerHeight = _playerRocket.Position.y;
            if (playerHeight > _maxPlayerHeight)
            {
                _maxPlayerHeight = playerHeight;
                transform.position = new Vector2(transform.position.x, playerHeight);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Rocket playerRocket)) 
                _playerInBounds = false;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Rocket playerRocket)) 
                _playerInBounds = true;
        }
    }
}