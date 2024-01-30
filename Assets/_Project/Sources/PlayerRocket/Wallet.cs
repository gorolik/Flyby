using System;
using UnityEngine;

namespace Sources.PlayerRocket
{
    public class Wallet : MonoBehaviour
    {
        private int _coins;

        public int Coins => _coins;
        
        public event Action<int> CoinsCountChanged;

        public void AddCoins(int coinValue)
        {
            _coins += coinValue;
            
            CoinsCountChanged?.Invoke(_coins);
        }
    }
}