using UnityEngine;

namespace Sources.PlayerRocket
{
    public class DestructionEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _destroyParticles;
        [SerializeField] private AudioSource _destroyedSoundSource;
        [SerializeField] private GameObject _destroyedMask;
        
        public void Play()
        {
            _destroyedMask.SetActive(true);
            _destroyParticles.Play();
            _destroyedSoundSource.Play();
        }
    }
}