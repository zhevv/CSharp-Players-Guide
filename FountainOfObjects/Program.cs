

while (true)
{
    Console.Clear();
    Game game = new Game();

    Console.WriteLine("Play again? (y/n) ");

    Console.ForegroundColor = ConsoleColor.Cyan;
    string restartInput = Console.ReadLine();

    if (restartInput == "y") continue;
    else {
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine("Thank you for playing...");
        break;
    } 
}



public class Game
{
    Room[,] rooms;
    Room currentRoom;
    Entrance entrance;
    FountainOfObjects fountainOfObjects;
    Amarok amarok;
    Player player;

    enum GameState
    {
        Ongoing,
        Win,
        Lose,
    }

    GameState state;

    int roomSize = 4;
    (int row, int column) entranceCoords = (0, 0);
    (int row, int column) fountainOfObjectsCoords = (0, 2);
    (int row, int column) amarokCoords = (3, 1);

    public Game()
    {
        CreateRooms();
        player = new Player(entranceCoords.row, entranceCoords.column, this);
        currentRoom = entrance;

        state = GameState.Ongoing;
        Play();
    }

    void Play()
    {
        Intro();
        while (state == GameState.Ongoing)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------");
            player.DisplayCoords();
            player.DisplayArrowCount();
            currentRoom.DisplayMessage();
            if (PlayerIsAmarokAdjacent()) amarok.DisplayAdjacentMessage();

            if (CheckWin()) break;
            if (CheckLose()) break;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What do you want to do? ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string command = Console.ReadLine();

            if (!PerformCommand(command))
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Can't do that!");
                continue;
            }   
        }
    }

    void Intro()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You enter the Cavern of Objects, " +
            "a maze of rooms filled with dangerous pits in search of the Fountain of Objects. " +
            "Light is visible only in the entrance, and no other light is seen anywhere in the caverns. " +
            "You must navigate the Caverns with your other senses. ");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Amaroks roam the caverns. " +
            "Encountering one is certain death, " +
            "but you can smell their rotten stench in nearby rooms.");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("“You carry with you a bow and a quiver of arrows. " +
            "You can use them to shoot monsters in the caverns but be warned: " +
            "you have a limited supply.");

    }

    public static bool Help()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("All possible commands: ");

        Console.Write("move north       "); Console.WriteLine("Player goes north of current room");
        Console.Write("move south       "); Console.WriteLine("Player goes south of current room");
        Console.Write("move east        "); Console.WriteLine("Player goes east of current room");
        Console.Write("move west        "); Console.WriteLine("Player goes west of current room");
        Console.Write("enable fountain  "); Console.WriteLine("Enables the fountain only if player is in the fountain room");
        Console.Write("shoot north      "); Console.WriteLine("Shoot towards north of current room");
        Console.Write("shoot south      "); Console.WriteLine("Shoot towards south of current room");
        Console.Write("shoot east       "); Console.WriteLine("Shoot towards east of current room");
        Console.Write("shoot west       "); Console.WriteLine("Shoot towards west of current room");
        Console.Write("help             "); Console.WriteLine("This wall of text");

        return true;
    }

    bool PerformCommand(string command)
    {
        ICommands? commandAction = command switch
        {
            "move north" => new MoveNorth(player, rooms),
            "move south" => new MoveSouth(player, rooms),
            "move east" => new MoveEast(player, rooms),
            "move west" => new MoveWest(player, rooms),
            "enable fountain" => new EnableFountain(fountainOfObjects),
            "shoot north" => new ShootNorth(player, rooms),
            "shoot south" => new ShootSouth(player, rooms),
            "shoot east" => new ShootEast(player, rooms),
            "shoot west" => new ShootWest(player, rooms),
            "help" => new Help(),
            _ => null,
        };

        // FIXME Player cant shoot if not shooting at target
        if (commandAction == null) return false;

        bool actionIsSuccessfull = commandAction.Execute();

        UpdateCurrentRoom();
        return actionIsSuccessfull;
    }

    public void KillRoom(Room target)
    {
        for (int row = 0; row < rooms.GetLength(0); row++)
        {
            for (int column = 0; column < rooms.GetLength(1); column++)
            {
                if (rooms[row, column] == target) rooms[row, column] = new EmptyRoom();
            }
        }
    }

    bool CheckWin()
    {
        if (currentRoom == entrance && fountainOfObjects.IsEnabled) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Fountain of Objects is reactivated and you escaped with your life!");

            Console.ForegroundColor = ConsoleColor.White;
            state = GameState.Win;
            return true;
        }
        return false;
    }

    bool CheckLose()
    {
        if (currentRoom == amarok)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You lost.");
            state = GameState.Lose;
            
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
        return false;
    }

    void UpdateCurrentRoom()
    {
        currentRoom.PlayerLeftRoom();
        currentRoom = rooms[player.Row, player.Column];
        currentRoom.PlayerEnteredRoom();
    }


    void CreateRooms()
    {
        rooms = new Room[roomSize, roomSize];

        for (int row = 0; row < rooms.GetLength(0); row++ )
        {
            for (int column = 0; column < rooms.GetLength(1); column++ )
            {
                EmptyRoom room = new EmptyRoom();
                rooms[row, column] = room;
            }
        }

        entrance = new Entrance();
        rooms[entranceCoords.row, entranceCoords.column] = entrance;

        fountainOfObjects = new FountainOfObjects();
        rooms[fountainOfObjectsCoords.row, fountainOfObjectsCoords.column] = fountainOfObjects;

        amarok = new Amarok();
        rooms[amarokCoords.row, amarokCoords.column] = amarok;

    }

    bool PlayerIsAmarokAdjacent()
    {
        int numRows = rooms.GetLength(0);
        int numColumns = rooms.GetLength(1);

        // Define the relative positions to check around the player
        int[,] directions = new int[,]
        {
        { -1, -1 }, { -1, 0 }, { -1, 1 }, // Above
        { 0, -1 },           { 0, 1 }, // Left and Right
        { 1, -1 }, { 1, 0 }, { 1, 1 }  // Below
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int newRow = player.Row + directions[i, 0];
            int newColumn = player.Column + directions[i, 1];

            // Check if the new position is within the bounds of the array
            if (newRow >= 0 && newRow < numRows && newColumn >= 0 && newColumn < numColumns)
            {
                if (rooms[newRow, newColumn] == amarok)
                {
                    return true;
                }
            }
        }
        return false;
    }
}


public class Player
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    public int Arrows { get; private set; } = _maxArrows;

    private static readonly int _maxArrows = 5;
    Game game;

    public Player(int row, int column, Game game)
    {
        Row = row;
        Column = column;
        this.game = game;
    }

    public bool Shoot(Room room)
    {
        if (Arrows > 0 && room is IKillable target)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You shot an arrow");

            game.KillRoom(room);

            Arrows--;
            return target.Kill();
        } 
        return false;
    }

    public void DisplayCoords()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"You are at Row: {Row}, Column: {Column}");
    }

    public void DisplayArrowCount()
    {
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine($"Arrows: {Arrows}/{_maxArrows}");
    }

    public bool MoveNorth(Room[,] rooms)
    {
        if (Row - 1 < 0) return false;

        Row -= 1;
        return true;
    }

    public bool MoveSouth(Room[,] rooms)
    {
        if (Row + 1 >= rooms.GetLength(0)) return false;

        Row += 1; 
        return true; 
    }
    public bool MoveEast(Room[,] rooms)
    {
        if (Column + 1 >= rooms.GetLength(1)) return false;

        Column += 1;
        return true;  
    }
    public bool MoveWest(Room[,] rooms)
    {
        if (Column - 1 < 0) return false;

        Column -= 1;
        return true;
    }
}

public interface ICommands
{
    bool Execute();
}

public abstract class ShootCommands : ICommands
{
    protected Player player;
    protected Room[,] rooms;
    protected Room room;

    public ShootCommands(Player player, Room[,] rooms)
    {
        this.player = player;
        this.rooms = rooms;
    }
    public bool Execute() { return player.Shoot(room); }
}

public class ShootNorth : ShootCommands
{
    public ShootNorth(Player player, Room[,] rooms) : base(player, rooms)
    {
        if (player.Row - 1 >= 0)
        {
            room = rooms[player.Row - 1,player.Column];
        }
    }
}
public class ShootSouth : ShootCommands
{
    public ShootSouth(Player player, Room[,] rooms) : base(player, rooms)
    {
        if (player.Row + 1 < rooms.GetLength(0))
        {
            room = rooms[player.Row + 1, player.Column];
        }
    }
}
public class ShootEast : ShootCommands
{
    public ShootEast(Player player, Room[,] rooms) : base(player, rooms)
    {
        if (player.Column - 1 >= 0)
        {
            room = rooms[player.Row, player.Column - 1];
        }
    }
}
public class ShootWest : ShootCommands
{
    public ShootWest(Player player, Room[,] rooms) : base(player, rooms)
    {
        if (player.Row + 1 < rooms.GetLength(1))
        {
            room = rooms[player.Row, player.Column + 1];
        }
    }
}


public abstract class MoveCommands 
{
    protected Player player;
    protected Room[,] rooms;

    public MoveCommands(Player player, Room[,] rooms)
    {
        this.player = player;
        this.rooms = rooms;
    }
}

public class MoveNorth : MoveCommands, ICommands
{
    public MoveNorth(Player player, Room[,] rooms) : base(player, rooms) { }

    public bool Execute()
    {
        return player.MoveNorth(rooms);
    }
}
public class MoveSouth : MoveCommands, ICommands
{
    public MoveSouth(Player player, Room[,] rooms) : base(player, rooms) { }
    public bool Execute()
    {
        return player.MoveSouth(rooms);
    }
}
public class MoveEast : MoveCommands, ICommands
{
    public MoveEast(Player player, Room[,] rooms) : base(player, rooms) { }
    public bool Execute()
    {
        return player.MoveEast(rooms);
    }
}
public class MoveWest : MoveCommands, ICommands
{
    public MoveWest(Player player, Room[,] rooms) : base (player, rooms) { }
    public bool Execute()
    {
        return player.MoveWest(rooms);
    }
}


public class EnableFountain : ICommands
{
    private FountainOfObjects fountainOfObjects;
    public EnableFountain(FountainOfObjects fountainOfObjects)
    {
        this.fountainOfObjects = fountainOfObjects;
    }
    public bool Execute()
    {
        if(fountainOfObjects.Enable()) return true;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You tried to enable the fountain but you failed...");
        return false;
    }
}

public class Help : ICommands
{

    public Help()
    {
    }

    public bool Execute()
    {
        return Game.Help();
    }

}


public abstract class Room
{
    public bool PlayerIsInRoom = false;
    public virtual string Message { get; protected set; } = "Nothing in this room.";
    public virtual ConsoleColor TextColor { get;  protected set; } = ConsoleColor.White;
    public void DisplayMessage()
    {
        Console.ForegroundColor = TextColor;
        Console.WriteLine(Message);
    }

    public void PlayerEnteredRoom()
    {
        PlayerIsInRoom = true;
    }

    public void PlayerLeftRoom()
    {
        PlayerIsInRoom = false;
    }
}

public class EmptyRoom : Room
{

}

public class Entrance : Room
{
    public override ConsoleColor TextColor { get; protected set; } = ConsoleColor.Yellow;
    public override string Message { get; protected set; } = "You see light in this room " +
        "coming from outside the cavern. This is the entrance.";
}

public class FountainOfObjects : Room
{
    public override ConsoleColor TextColor { get; protected set; } = ConsoleColor.Blue;
    public override string Message { get; protected set; } = "You hear water dripping " +
        "in this room. The fountain of Objects is here!";

    public bool IsEnabled { get; protected set; } = false;

    public bool Enable()
    {
        if (PlayerIsInRoom)
        {
            IsEnabled = true;
            Message = "You hear the rushing waters from the Fountain of Objects. " +
                "It has been reactivated!";

            return true;
        }
        return false;  
    }
}

public interface IKillable
{
    public bool Kill();
}

public abstract class AdjacentAlertableRoom : Room
{
    public virtual string AdjacentMessage { get; protected set; }
    public void DisplayAdjacentMessage()
    {
        Console.ForegroundColor = TextColor;
        Console.WriteLine(AdjacentMessage);
    }  
}

public class Amarok : AdjacentAlertableRoom, IKillable
{
    public override ConsoleColor TextColor { get; protected set; } = ConsoleColor.DarkRed;
    public override string Message { get; protected set; } = "In the suffocating darkness, " +
        "the looming shadow of the amarok heralds your inevitable demise.";
    public override string AdjacentMessage { get;  protected set; } = "You smell the rotten stench of an " +
        "amarok in a nearby room";

    public bool Kill()
    {
        return true;
    }
}