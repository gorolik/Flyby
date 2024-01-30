using Sources.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Planets
{
    public class ItemsOrbit : MonoBehaviour
    {
        private const float _speedConst = 0.05f;
        
        [SerializeField] private float _distance = 5;

        private Planet _planet;
        private float _speed;
        private int _direction;

        public void Init()
        {
            _planet = GetComponentInParent<Planet>();
            _speed = _speedConst * _planet.GravitationField.GetAttractiveForce(_distance, 1);
            _direction = GetRandomDirection();
        }

        public void AddItem(Item item)
        {
            var itemTransform = item.transform;
            itemTransform.parent = transform;
            itemTransform.position = (Vector2)transform.position + Vector2.left * _distance;
                
            transform.Rotate(0, 0, Random.Range(-360, 360));
        }

        private void Update() => 
            transform.Rotate(0, 0, _speed * _direction * Time.deltaTime);

        private int GetRandomDirection()
        {
            if (Random.Range(0, 2) == 0)
                return -1;
            else
                return 1;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _distance);
        }
    }
}