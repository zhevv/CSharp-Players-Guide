namespace TheCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (Card.Color color in Enum.GetValues(typeof(Card.Color)))
            {
                foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
                {
                    Card card = new Card(color, rank);
                    Console.WriteLine(card);
                }
            }
        }

        public class Card
        {
            // Enum for card colors
            public enum Color
            {
                Red,
                Green,
                Blue,
                Yellow
            }

            // Enum for card ranks
            public enum Rank
            {
                One = 1,
                Two = 2,
                Three = 3,
                Four = 4,
                Five = 5,
                Six = 6,
                Seven = 7,
                Eight = 8,
                Nine = 9,
                Ten = 10,
                Dollar = '$',
                Percent = '%',
                Caret = '^',
                Ampersand = '&'
            }

            private readonly Color color;
            private readonly Rank rank;

            public Card(Color color, Rank rank)
            {
                this.color = color;
                this.rank = rank;
            }

            public Color GetColor()
            {
                return color;
            }

            public Rank GetRank()
            {
                return rank;
            }

            public bool IsNumberCard()
            {
                return (int)rank >= 1 && (int)rank <= 10; 
            }

            public bool IsSymbolCard()
            {
                return !IsNumberCard();
            }

            public override string ToString()
            {
                return $"The {color} {rank}"; 
            }
        }
    }
}
