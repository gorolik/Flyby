using Sources.PlayerRocket;
using UnityEngine;

namespace Sources.UI
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] private SliderValueDisplay _fuelDisplay;
        [SerializeField] private SliderValueDisplay _durabilityDisplay;
        [SerializeField] private CoinsDisplay _coinsDisplay;

        public void Init(Rocket playerRocket)
        {
            _fuelDisplay.Init(playerRocket.FuelTank);
            _durabilityDisplay.Init(playerRocket.Durability);
            _coinsDisplay.Init(playerRocket.Wallet);
        }
    }
}