namespace VinFletchersArrows
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("(E)lite, (B)eginner, (M)arksman, (C)ustom arrow?");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "E":
                    Arrow.CreateEliteArrow();
                    break;
                case "B":
                    Arrow.CreateBeginnerArrow();
                    break;
                case "M":
                    Arrow.CreateMarksmanArrow();
                    break;
                case "C":
                    CreateCustomArrow();
                    break;

            }

        }

        static void CreateCustomArrow()
        {
            Console.WriteLine("Arrowhead types: ");
            Array arrowheadTypes = Enum.GetValues(typeof(ArrowheadType));
            foreach (int i in arrowheadTypes)
            {
                Console.Write(i + "-");
                Console.WriteLine((ArrowheadType)i);
            }

            ArrowheadType arrowhead = (ArrowheadType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Fletching types: ");
            Array fletchingTypes = Enum.GetValues(typeof(FletchingType));
            foreach (int i in fletchingTypes)
            {
                Console.Write(i + "-");
                Console.WriteLine((FletchingType)i);
            }

            FletchingType fletching = (FletchingType)Convert.ToInt32(Console.ReadLine());

            Console.Write("Length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            Arrow arrow = new Arrow { Arrowhead = arrowhead, Fletching = fletching, Length = length };
            float arrowCost = arrow.GetCost();
            Console.WriteLine($"The cost is {arrowCost}");
        }

        enum ArrowheadType
        {
            Steel,
            Wood,
            Obsidian,
        }

        enum FletchingType
        {
            Plastic,
            TurkeyFeathers,
            GooseFeathers,
        }

        class Arrow
        {


            public ArrowheadType Arrowhead { get; set; }
            public FletchingType Fletching { get; set; }
            public int Length { get; set; }

            public static Arrow CreateEliteArrow()
            {
                Arrow arrow = new Arrow();
                arrow.Arrowhead = ArrowheadType.Steel;
                arrow.Fletching = FletchingType.Plastic;
                arrow.Length = 95;
                Console.WriteLine(arrow.GetCost());
                return arrow;
            }
            public static Arrow CreateBeginnerArrow()
            {
                Arrow arrow = new Arrow();
                arrow.Arrowhead = ArrowheadType.Wood;
                arrow.Fletching = FletchingType.GooseFeathers;
                arrow.Length = 75;
                Console.WriteLine(arrow.GetCost());
                return arrow;
            }
            public static Arrow CreateMarksmanArrow()
            {
                Arrow arrow = new Arrow();
                arrow.Arrowhead = ArrowheadType.Steel;
                arrow.Fletching = FletchingType.GooseFeathers;
                arrow.Length = 65;
                Console.WriteLine(arrow.GetCost());
                return arrow;
            }


            public float GetCost()
            {
                float cost = 0f;

                switch (Arrowhead)
                {
                    case ArrowheadType.Steel:
                        cost += 10;
                        break;
                    case ArrowheadType.Wood:
                        cost += 3;
                        break;
                    case ArrowheadType.Obsidian:
                        cost += 5;
                        break;
                }

                switch (Fletching)
                {
                    case FletchingType.Plastic:
                        cost += 10;
                        break;
                    case FletchingType.TurkeyFeathers:
                        cost += 5;
                        break;
                    case FletchingType.GooseFeathers:
                        cost += 3;
                        break;
                }

                cost += Length * 0.05f;

                return cost;
            }
        }
    }
}
