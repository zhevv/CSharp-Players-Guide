
Sword sword = new Sword();
ColoredItem<Sword> blueSword = new ColoredItem<Sword>(sword, ConsoleColor.Blue);

Bow bow = new Bow();
ColoredItem<Bow> redBow = new ColoredItem<Bow>(bow, ConsoleColor.Red);

Axe axe = new Axe();
ColoredItem<Axe> greenAxe  = new ColoredItem<Axe>(axe, ConsoleColor.Green);

blueSword.Display();
redBow.Display();
greenAxe.Display();


public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>
{
    T Item;
    ConsoleColor Color;

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);

        Console.ForegroundColor = ConsoleColor.White;
    }

}