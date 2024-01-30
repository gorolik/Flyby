using UnityEngine;

namespace Sources.Items
{
    public class FuelCanister : Item
    {
        [SerializeField] private float _fuel = 100;

        public float Fuel => _fuel;
    }
}