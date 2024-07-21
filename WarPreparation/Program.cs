Sword sword = new Sword(Material.Iron, Gemstone.None, 80, 10);
Sword sword2 = sword with { Material = Material.Binarium };
Sword sword3 = sword with { Gemstone = Gemstone.Sapphire };

Console.WriteLine(sword);
Console.WriteLine(sword2);
Console.WriteLine(sword3);

public enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium,
}

public enum Gemstone
{
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
    None,
}

public record Sword(Material Material, Gemstone Gemstone, float Length, float CrossguardWidth);