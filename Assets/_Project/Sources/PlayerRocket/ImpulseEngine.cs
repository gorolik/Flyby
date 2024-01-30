using UnityEngine;

namespace Sources.PlayerRocket
{
    public class ImpulseEngine : RocketEngine
    {
        [SerializeField] private float _power = 50;
        [SerializeField] private float _cooldown = 2;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _impulseSound;
        [SerializeField] private ParticleSystem _particles;

        private float _cooldownTimer;
        
        private void Update()
        {
            if (_cooldownTimer > 0) 
                _cooldownTimer -= Time.deltaTime;
        }

        public override void TrySetEnabled(bool value)
        {
            if(value)
                TryImpulse();
        }

        private void TryImpulse()
        {
            if(_cooldownTimer > 0)
                return;
            else if(!FuelTank.TrySpendFuel(FuelConsumption))
                return;

            _cooldownTimer = _cooldown;
            
            Vector2 direction = transform.up.normalized;
            Vector2 impulse = direction * _power;
            RocketBody.AddForceAtPosition(impulse, transform.position, ForceMode2D.Impulse);
            
            _audioSource.PlayOneShot(_impulseSound);
            _particles.Play();
        }
    }
}