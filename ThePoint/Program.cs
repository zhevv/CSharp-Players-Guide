namespace ThePoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(2, 3);
            Point point2 = new Point(-4, 0);
            Point point3 = new Point();

            point1.DisplayCoordinates();
            point2.DisplayCoordinates();
            point3.DisplayCoordinates();
        }

        class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public Point(int x = 0, int y = 0) {
                this.x = x;
                this.y = y;
            }

            public void DisplayCoordinates()
            {
                Console.WriteLine($"({x},{y})");
            }
        }

        
    }

    
}
