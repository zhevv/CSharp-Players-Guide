namespace HuntingTheManticore
{
    public class Manticore
    {
        int distance;
        public int Distance
        {
            get
            {
                return distance;
            }
            private set
            {
                distance = Math.Clamp(value, 0, 100000);
            }
        }
        public int TotalHealth { get; private set; } = 10;
        public int CurrentHealth { get; private set; }

        public Manticore(int distance)
        {
            Distance = distance;
            CurrentHealth = TotalHealth;
        }

        public int TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            CurrentHealth = Math.Clamp(CurrentHealth, 0, TotalHealth);
            return CurrentHealth;
        }

        public bool IsAlive()
        {
            return CurrentHealth > 0;
        }
    }
}
