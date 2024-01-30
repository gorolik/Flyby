using Sources.Items;
using UnityEngine;

namespace Sources.PlayerRocket
{
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private FuelTank _fuelTank;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item) && item.Collect())
            {
                if(item is FuelCanister canister)
                    _fuelTank.Fill(canister.Fuel);
                else if (item is Coin coin)
                    _wallet.AddCoins(coin.Value);
            }
        }
    }
}