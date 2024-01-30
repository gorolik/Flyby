using System;
using UnityEngine;

namespace Sources.PlayerRocket
{
    public abstract class Value : MonoBehaviour
    {
        [SerializeField] private float _defaultValue = 100;
        [SerializeField] private float _minValue = 0;
        [SerializeField] private float _maxValue = 100;

        private float _currentValue;
        
        public float MaxValue => _maxValue;
        
        public float Current
        {
            get => _currentValue;
            set
            {
                float validatedValue = Mathf.Clamp(value, _minValue, _maxValue);
                _currentValue = validatedValue;
                
                ValueChanged?.Invoke(_currentValue);
            }
        }
        
        public event Action<float> ValueChanged;

        public void Init() => 
            Current = _defaultValue;
    }
}