using HuntingTheManticore;

Game game;

Console.WriteLine("Do you want the computer to randomly determine how far the Manticore is? (y/n)");

if (Console.ReadLine() == "y")
{
    Console.WriteLine("Choose difficulty: ");
    Console.WriteLine("1. Easy (range is 0 until 100)");
    Console.WriteLine("2. Medium (range is 0 until 1,000");
    Console.WriteLine("3. Hard (range is 0 until 10,000");
    Console.WriteLine("4. Insane (range is 0 until 100,000");

    while (true)
    {
        var input = Console.ReadLine();
        if (input == "1") { game = new Game(new EasyComputerManticoreSpawner()); break; }
        else if (input == "2") { game = new Game(new MediumComputerManticoreSpawner()); break; }
        else if (input == "3") { game = new Game(new HardComputerManticoreSpawner()); break; }
        else if (input == "4") { game = new Game(new InsaneComputerManticoreSpawner()); break; }
        else Console.WriteLine(input + " is not a valid choice.");
    }
}
else game = new Game(new PlayerManticoreSpawner());
game.Play();
