using System;

namespace Sources.PlayerRocket
{
    public class Durability : Value
    {
        private bool _destroyed;

        public bool IsDestroyed => _destroyed;
        
        public event Action Destroyed;

        public void Damage(float damage)
        {
            if(damage < 0 || _destroyed)
                return;

            Current -= damage;

            if (Current <= 0)
            {
                _destroyed = true;
                Destroyed?.Invoke();
            }
        }

        public void Destruction() => 
            Damage(Current);
    }
}