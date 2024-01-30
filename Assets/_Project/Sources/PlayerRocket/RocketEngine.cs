using UnityEngine;

namespace Sources.PlayerRocket
{
    public abstract class RocketEngine : MonoBehaviour
    {
        [SerializeField] protected float FuelConsumption;
        
        protected Rigidbody2D RocketBody;
        protected FuelTank FuelTank;
        protected bool Inited;

        public void Init(Rigidbody2D body, FuelTank fuelTank)
        {
            RocketBody = body;
            FuelTank = fuelTank;
            Inited = true;
        }
        
        public void SetThrustVector(Vector2 direction) => 
            transform.LookAt2D((Vector2)transform.position + direction);

        public abstract void TrySetEnabled(bool value);
    }
}