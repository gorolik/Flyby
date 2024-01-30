using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Sources.PlayerRocket
{
    public class TractionEngine : RocketEngine
    {
        [SerializeField] private float _power = 15;
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Light2D _light;
        
        private bool _enabled;

        private void FixedUpdate()
        {
            if(!Inited)
                return;

            if (_enabled) 
                AddForce();
        }

        public override void TrySetEnabled(bool value)
        {
            if(!EnoughFuel() && value)
                return;

            if (value)
                EngineStart();
            else
                EngineStop();
        }

        private void AddForce()
        {
            if (!FuelTank.TrySpendFuel(FuelConsumptionPerTime()))
            {
                EngineStop();
                return;
            }
            
            Vector2 direction = transform.up.normalized;
            Vector2 force = direction * (_power * Time.fixedDeltaTime);
            
            RocketBody.AddForceAtPosition(force, transform.position, ForceMode2D.Force);
        }

        private void EngineStart()
        {
            _enabled = true;
            
            _light.enabled = true;
            _particles.Play();
            _audioSource.Play();
        }

        private void EngineStop()
        {
            _enabled = false;
            
            _light.enabled = false;
            _particles.Stop();
            _audioSource.Stop();
        }

        private bool EnoughFuel() => 
            FuelTank.HasFuel(FuelConsumptionPerTime());

        private float FuelConsumptionPerTime() =>
            FuelConsumption * Time.fixedDeltaTime;
    }
}