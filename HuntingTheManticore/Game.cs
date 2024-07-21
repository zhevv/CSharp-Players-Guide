using HuntingTheManticore;

public class Game {
    IManticoreSpawner manticoreSpawner;
    Manticore manticore;
    City city;

    enum GameState { Ongoing, Won, Lost}
    GameState gameState = GameState.Ongoing;

    int round = 1;

    public Game(IManticoreSpawner manticoreSpawner) {
        this.manticoreSpawner = manticoreSpawner;
        manticore = manticoreSpawner.SpawnManticore();

        city = new City();
    }

    public void Play()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Player 2, it is your turn.");

        while (gameState == GameState.Ongoing)
        {
            DisplayStatus();
            int currentRoundDamage = CalculateCannonDamage(round);
            DisplayCurrentRoundDamage(currentRoundDamage);

            int guess = Player2Guess();

            if (guess > manticore.Distance) GuessOvershot();
            else if (guess < manticore.Distance) GuessFellShort();
            else {
                bool manticoreDestroyed = GuessDirectHit(currentRoundDamage);
                if (manticoreDestroyed) break;
            }
            AttackCity();

            round++;
        }
    }

    void DisplayStatus()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"STATUS: Round: {round}  " +
            $"City: {city.CurrentHealth}/{city.TotalHealth}    " +
            $"Manticore: {manticore.CurrentHealth}/{manticore.TotalHealth}    ");
    }

    void DisplayCurrentRoundDamage(int damage)
    {
        Console.Write($"The cannon is expected to deal ");

        Console.ForegroundColor= ConsoleColor.DarkYellow;
        Console.Write($"{damage} ");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("damage this round.");
    }

    int CalculateCannonDamage(int round)
    {
        if (round % 3 == 0 && round % 5 == 0) return 10;
        if (round % 3 == 0) return 3;
        if (round % 5 == 0) return 3;
        return 1;
    }

    int Player2Guess()
    {
        int guess;

        // keep asking until input is valid integer
        while (true)
        {
            Console.Write("Enter desired cannon range: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var input = Console.ReadLine();
            
            if (int.TryParse(input, out guess))
            {
                guess = Convert.ToInt32(input);
                break; 
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid input. Input must be an integer!");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        Console.ForegroundColor = ConsoleColor.Gray;
        return guess;
    }

    void GuessOvershot()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("That round OVERSHOT the target.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    void GuessFellShort()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("That round FELL SHORT of the target.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    bool GuessDirectHit(int damage)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("That round was a DIRECT HIT.");
        Console.ForegroundColor = ConsoleColor.Gray;

        manticore.TakeDamage(damage);

        if (!manticore.IsAlive())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            Console.ForegroundColor = ConsoleColor.Gray;
            gameState = GameState.Won;
            return true;
        }

        return false;
    }
    void AttackCity()
    {
        city.TakeDamage(1);
        if (!city.IsAlive())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You lost. The city of Consolas has fallen... The distance of the Manticore was {manticore.Distance}");
            Console.ForegroundColor = ConsoleColor.Gray;
            gameState = GameState.Lost;
        }
    }
}