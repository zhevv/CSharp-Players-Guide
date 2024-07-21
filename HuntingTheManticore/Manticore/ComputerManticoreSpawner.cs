namespace HuntingTheManticore
{
    public class EasyComputerManticoreSpawner : IManticoreSpawner
    {
        public Manticore SpawnManticore()
        {
            Random random = new Random();

            int distance = random.Next(0, 100);
            return new Manticore(distance);
        }
    }

    public class MediumComputerManticoreSpawner : IManticoreSpawner
    {
        public Manticore SpawnManticore()
        {
            Random random = new Random();

            int distance = random.Next(0, 1000);
            return new Manticore(distance);
        }
    }
    public class HardComputerManticoreSpawner : IManticoreSpawner
    {
        public Manticore SpawnManticore()
        {
            Random random = new Random();

            int distance = random.Next(0, 10000);
            return new Manticore(distance);
        }
    }
    public class InsaneComputerManticoreSpawner : IManticoreSpawner
    {
        public Manticore SpawnManticore()
        {
            Random random = new Random();

            int distance = random.Next(0, 100000);
            return new Manticore(distance);
        }
    }
}
