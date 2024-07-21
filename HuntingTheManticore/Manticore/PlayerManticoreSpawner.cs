namespace HuntingTheManticore
{
    public class PlayerManticoreSpawner : IManticoreSpawner
    {
        public Manticore SpawnManticore()
        {
            Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
            int distance;

            // keep asking until input is valid integer
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                var input = Console.ReadLine();

                if (int.TryParse(input, out distance))
                {
                    distance = Convert.ToInt32(input);
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Input must be an integer!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            return new Manticore(distance);
        }
    }
}
