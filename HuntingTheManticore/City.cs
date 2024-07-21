namespace HuntingTheManticore
{
    public class City
    {
        public int TotalHealth { get; private set; } = 15;
        public int CurrentHealth { get; private set; }
        public City()
        {
            CurrentHealth = TotalHealth;
        }

        public int TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            return CurrentHealth;
        }

        public bool IsAlive()
        {
            return CurrentHealth > 0;
        }
    }
}
