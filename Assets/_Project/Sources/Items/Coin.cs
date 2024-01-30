using UnityEngine;

namespace Sources.Items
{
    public class Coin : Item
    {
        [SerializeField] private int _value = 1;

        public int Value => _value;
    }
}