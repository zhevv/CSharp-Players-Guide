namespace PlayersGuide
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Watchtower();
        }
        enum FoodType
        {
            Soup,
            Stew,
            Gumbo,
        }
        enum FoodIngredients
        {
            Mushrooms,
            Chicken,
            Carrots,
            Potatoes,
        }
        enum FoodSeasoning
        {
            Spicy,
            Salty,
            Sweet
        }
        public static void SimulasSoup()
        {
            (FoodType type, FoodIngredients ingredients, FoodSeasoning seasoning) food;

            //better way to list names would be to use loops and iterate through enum values
            Console.WriteLine("What type?\n0-Soup\n1-Stew\n2-Gumbo");
            food.type = (FoodType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What ingredient?\n0-Mushrooms\n1-Chicken\n2-Carrots\n3-Potatoes");
            food.ingredients = (FoodIngredients)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What seasoning?\n0-Spicy\n1-Salty\n2-Sweet\n");
            food.seasoning = (FoodSeasoning)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{food.seasoning} {food.ingredients} {food.type}");

        }

        public static void Watchtower()
        {
            Console.Write("Provide x: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Provide y: ");
            int y = Convert.ToInt32(Console.ReadLine());

            string message = "The enemy is to the ";


            if (y > 0)
            {
                message += "north";
            }
            else if (y < 0)
            {
                message += "south";

            }

            if (x > 0)
            {
                message += "east";
            }
            else if (x < 0)
            {
                message += "west";
            }

            if (x == 0 &&  y == 0)
            {
                message = "The enemy is here";
            }
            message += "!";
            Console.WriteLine(message);
        }

        public static void RepairingClockTower()
        {
            Console.Write("Insert number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            bool numberIsEven = number % 2 == 0;
            if (numberIsEven)
            {
                Console.WriteLine("Tick");
            }
            else
            {
                Console.WriteLine("Tock");
            }
        }

        public static void DefenseOfConsolas()
        {
            Console.Title = "Defense of Consolas";

            int targetRow;
            int targetColumn;

            Console.Write("Target row? ");
            targetRow = Convert.ToInt32(Console.ReadLine());

            Console.Write("Target column? ");
            targetColumn = Convert.ToInt32(Console.ReadLine());

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Deploy to:");
            Console.WriteLine($"({targetRow - 1}, {targetColumn})");
            Console.WriteLine($"({targetRow + 1}, {targetColumn})");
            Console.WriteLine($"({targetRow}, {targetColumn - 1})");
            Console.WriteLine($"({targetRow}, {targetColumn + 1})");

            // play diminished arp
            Console.Beep(622, 100);
            Console.Beep(523, 100);
            Console.Beep(440, 100);
        }

        public static void DominionOfKings()
        {
            int score = 0;

            Console.WriteLine("How many estates do you have?");
            int estateAmount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many duchies do you have?");
            int duchyAmount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many provinces do you have?");
            int provinceAmount = Convert.ToInt32(Console.ReadLine());

            score += estateAmount;
            score += duchyAmount * 3;
            score += provinceAmount * 6;

            Console.WriteLine($"Your score is {score}");
        }

        public static void VariableShop()
        {
            string name = "Bob";
            char grade = 'A';
            int cash = 100;
            short cars = 32767;
            byte age = 40;
            long aura = 7_000_000_000;
            sbyte cookies = -10;
            uint money = 2_500_000;
            ushort cakes = 13;
            ulong balls = 800_000_000_000;
            float angle = -81.2f;
            double humans = 1.4;
            decimal friction = 0.1314m;
            bool isAttacked = false;

            Console.WriteLine(name);
            Console.WriteLine(grade);
            Console.WriteLine(cash);
            Console.WriteLine(cars);
            Console.WriteLine(age);
            Console.WriteLine(aura);
            Console.WriteLine(cookies);
            Console.WriteLine(money);
            Console.WriteLine(cakes);
            Console.WriteLine(angle);
            Console.WriteLine(balls);
            Console.WriteLine(humans);
            Console.WriteLine(friction);
            Console.WriteLine(isAttacked);
        }

        public static void TriangleFarmer()
        {
            double triangleHeight;
            double triangleBase;

            Console.WriteLine("Triangle height: ");
            triangleHeight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Triangle base: ");
            triangleBase = Convert.ToDouble(Console.ReadLine());

            double area = (triangleHeight * triangleBase) / 2;
            Console.WriteLine(area);


        }

        public static void FourSistersAndDuckbear()
        {

            int eggs;

            Console.WriteLine("How many eggs do we have today?");
            eggs = Convert.ToInt32(Console.ReadLine());

            int eachSisterGets = eggs / 4;
            int duckbearGets = eggs % 4;

            Console.WriteLine($"Each sister gets {eachSisterGets} egg(s)");
            Console.WriteLine($"Duckbear gets {duckbearGets} egg(s)");
        }

    }

    
}
