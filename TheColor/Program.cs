namespace TheColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Color color1 = new Color(50,50,50);
            Color color2 = Color.Orange;

            Console.WriteLine($"{color1.r},{color1.g},{color1.b}");
            Console.WriteLine($"{color2.r},{color2.g},{color2.b}");

        }

        class Color
        {
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
            public Color(int red = 0 , int green = 0, int blue = 0)
            {
                r = red;
                g = green;
                b = blue;
            }

            public static Color White { get; } = new Color(255, 255, 255);
            public static Color Black { get; } = new Color(0, 0, 0);
            public static Color Red {  get; } = new Color(255,0,0);
            public static Color Orange { get; } = new Color(255, 165, 0);
            public static Color Yellow { get; } = new Color(255, 255, 0);
            public static Color Green { get; } = new Color(0, 128, 0);
            public static Color Blue { get; } = new Color(0, 0, 255);
            public static Color Purple { get; } = new Color(128, 0, 128);


        }
    }
}
