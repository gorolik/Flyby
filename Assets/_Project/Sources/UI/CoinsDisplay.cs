using Sources.PlayerRocket;
using TMPro;
using UnityEngine;

namespace Sources.UI
{
    public class CoinsDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coins;
        
        private Wallet _wallet;

        public void Init(Wallet wallet)
        {
            _wallet = wallet;

            OnCoinsCountChanged(_wallet.Coins);
            _wallet.CoinsCountChanged += OnCoinsCountChanged;
        }

        private void OnDestroy() => 
            _wallet.CoinsCountChanged -= OnCoinsCountChanged;

        private void OnCoinsCountChanged(int value) => 
            _coins.text = value.ToString();
    }
}