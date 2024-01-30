using Sources.PlayerRocket;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.UI
{
    public class SliderValueDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _valueBar;
        
        private Value _value;

        public void Init(Value value)
        {
            _value = value;

            _valueBar.maxValue = value.MaxValue;
            _valueBar.value = value.Current;
            
            _value.ValueChanged += OnValueChanged;
        }

        private void OnDestroy() => 
            _value.ValueChanged -= OnValueChanged;

        private void OnValueChanged(float value) => 
            _valueBar.value = value;
    }
}