using Sources.PlayerRocket;
using UnityEngine;

namespace Sources.Planets
{
    public class Surface : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private bool _destruction = true;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out Durability durability))
            {
                if(_destruction)
                    durability.Destruction();
                else
                    durability.Damage(_damage);
            }
        }
    }
}