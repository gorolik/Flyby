using System.Collections.Generic;
using UnityEngine;

namespace Sources.Planets
{
    public class GravitationField : MonoBehaviour
    {
        private const float _gravitationConst = 1;
        private const float _rangeConst = 40;
        
        [SerializeField] private List<Attractive> _attractiveObjects = new List<Attractive>();
        [SerializeField] private float _power = 750;
        [SerializeField] private float _innerRange = 5;
        
        private float OuterRange => _power / _rangeConst + _innerRange;

        public void Init(Attractive player) =>
            AddAttractiveObject(player);

        private void FixedUpdate()
        {
            for (int i = 0; i < _attractiveObjects.Count; i++)
            {
                float distance = Vector2.Distance(transform.position, _attractiveObjects[i].Position);
                
                if (distance <= OuterRange)
                {
                    float forceMagnitude = GetAttractiveForce(distance, _attractiveObjects[i].Rigidbody.mass);
                    Vector2 direction = ((Vector2)transform.position - _attractiveObjects[i].Position).normalized;
                    var force = direction * (forceMagnitude * Time.fixedDeltaTime);
                    
                    _attractiveObjects[i].Rigidbody.AddForce(force, ForceMode2D.Force);
                }
            }
        }

        public void AddAttractiveObject(Attractive attractive) =>
            _attractiveObjects.Add(attractive);

        public float GetAttractiveForce(float distance, float mass)
        {
            float normalizedDistance = 1f - Mathf.Clamp01((distance - _innerRange) / (OuterRange - _innerRange));
            return _gravitationConst * _power * mass * Mathf.Pow(normalizedDistance, 2);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, OuterRange);
            Gizmos.DrawWireSphere(transform.position, _innerRange);
        }
    }
}