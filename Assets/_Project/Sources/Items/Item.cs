using UnityEngine;

namespace Sources.Items
{
    public abstract class Item : MonoBehaviour
    {
        private static readonly int CollectedAnimatorBool = Animator.StringToHash("Collected");

        private const float _destroyDelay = 5;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        
        private bool _collectable = true;

        public bool Collect()
        {
            if (_collectable)
            {
                _animator.SetBool(CollectedAnimatorBool, true);
                _audioSource.Play();
                Destroy(gameObject, _destroyDelay);
                
                _collectable = false;
            
                return true;
            }
            else
                return false;
        }
    }
}
