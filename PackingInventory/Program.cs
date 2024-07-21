
using System.Reflection.Metadata.Ecma335;

Pack pack = new Pack(5, 10, 10);

while (true)
{
    Console.WriteLine(pack);
    Console.WriteLine("Add (1)Arrow, (2)Bow, (3)Rope, (4)Water, (5)Food, (6)Sword");
    string input = Console.ReadLine();

    bool result = input switch
    {
        "1" => pack.Add(new Arrow()),
        "2" => pack.Add(new Bow()),
        "3" => pack.Add(new Rope()),
        "4" => pack.Add(new Water()),
        "5" => pack.Add(new Food()),
        "6" => pack.Add(new Sword()),
        _ => false,
    }; 

    if (result) Console.WriteLine("Item successfully added!");
    else Console.WriteLine("Unable to add item");

}
class Pack
{
    int MaxTotalItems { get; }

    float MaxWeight { get; }
    float MaxVolume { get; }

    InventoryItem[] items;
    public int ItemCount { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }   


    public Pack(int totalItems, float maxWeight, float maxVolume)
    {
        items = new InventoryItem[totalItems];
        MaxTotalItems = totalItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public bool Add(InventoryItem item)
    {
        if (ItemCount >= MaxTotalItems) return false;
        if (item.Weight + CurrentWeight > MaxWeight) return false;
        if (item.Volume + CurrentVolume > MaxVolume) return false;

        items[ItemCount] = item;
        ItemCount++;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;
        return true;

    }


    public override string ToString()
    {
        string message = "";
        for (int i = 0; i < items.Length; i++) message += $"{items[i]} ";
        return $"Pack contains: {message}";
    }

}
public abstract class InventoryItem
{
    public float Volume { get; set; }
    public float Weight { get; set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString()
    {
        return "Arrow";
    }
}

class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
    public override string ToString()
    {
        return "Bow";
    }
}

class Rope : InventoryItem
{
    public Rope() : base(1, 1.5f) { }
    public override string ToString()
    {
        return "Rope";
    }
}

class Water : InventoryItem
{
    public Water() : base(2, 3) { }
    public override string ToString()
    {
        return "Water";
    }
}

class Food : InventoryItem
{
    public Food() : base(1, 0.5f) { }
    public override string ToString()
    {
        return "Food";
    }

}

class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
    public override string ToString()
    {
        return "Sword";
    }
}