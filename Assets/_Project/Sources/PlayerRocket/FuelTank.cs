namespace Sources.PlayerRocket
{
    public class FuelTank : Value
    {
        public bool HasFuel(float value) => 
            Current >= value;

        public bool TrySpendFuel(float value)
        {
            if (HasFuel(value))
            {
                Current -= value;
                return true;
            }

            return false;
        }

        public void Fill(float fuel) => 
            Current += fuel;
    }
}