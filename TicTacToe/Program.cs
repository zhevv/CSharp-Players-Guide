namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This code is so bad, i got lazy on winner and draw checking xdddddddddddd
            bool hasWinner = false;
            string input;
            Board board = new Board();
            bool choseValidMove;

            while (!hasWinner)
            {

                // X's turn
                choseValidMove = false;
                while (!choseValidMove)
                {
                    Console.WriteLine("It is X's turn.");
                    board.DisplayBoard();
                    Console.WriteLine("Which square do you want to play in?");

                    input = Console.ReadLine();
                    choseValidMove = board.CrossMove(input);
                    hasWinner = board.CheckWin();
                }
                if (hasWinner)
                {
                    Console.WriteLine("X won!");
                    break;
                }
                if (board.CheckDraw())
                {
                    Console.WriteLine("It is a draw.");
                    break;
                }

                // O's turn
                choseValidMove = false;
                while (!choseValidMove)
                {
                    Console.WriteLine("It is O's turn.");
                    board.DisplayBoard();
                    Console.WriteLine("Which square do you want to play in?");

                    input = Console.ReadLine();
                    choseValidMove = board.CircleMove(input);
                    hasWinner = board.CheckWin();
                    
                }
                if (hasWinner)
                {
                    Console.WriteLine("O won!");
                    break;
                }
                if (board.CheckDraw())
                {
                    Console.WriteLine("It is a draw.");
                    break;
                }
                
            }

            board.DisplayBoard();


        }

        public class Board
        {
            enum Square
            {
                Empty = ' ',
                Cross = 'X',
                Circle = 'O',
            }

            Square[] squares;

            public Board()
            {
                squares = new Square[9];
                Array.Fill(squares, Square.Empty);
            }
            public bool CrossMove(string _choice)
            {
                int choice = int.Parse(_choice);

                if (squares[choice] == Square.Empty) {
                    squares[choice] = Square.Cross;
                    return true;
                }
                Console.WriteLine("Square is already occupied.");
                return false;
            }

            public bool CircleMove(string _choice)
            {
                int choice = int.Parse(_choice);

                if (squares[choice] == Square.Empty)
                {
                    squares[choice] = Square.Circle;
                    return true;
                }
                Console.WriteLine("Square is already occupied.");
                return false;
            }
            public void DisplayBoard()
            {
                Console.WriteLine($" {(char)squares[6]} | {(char)squares[7]} | {(char)squares[8]}");
                Console.WriteLine($"---+---+---");
                Console.WriteLine($" {(char)squares[3]} | {(char)squares[4]} | {(char)squares[5]}");
                Console.WriteLine($"---+---+---");
                Console.WriteLine($" {(char)squares[0]} | {(char)squares[1]} | {(char)squares[2]}");
            }

            public bool CheckWin()
            {
                if (checkHorizontal() || checkVertical() || checkDiagonal())
                {
                    return true;
                }
                return false;
            }

            public bool CheckDraw()
            {
                foreach (Square square in squares)
                {
                    if (square.Equals(Square.Empty))
                    {
                        return false;
                    }
                }
                return true;
            }

            private bool checkVertical()
            {
                for (int index = 0; index <= 2; index++)
                {
                    if (squares[index] != Square.Empty)
                    {
                        if (squares[index] == squares[index + 3] && squares[index] == squares[index + 6])
                            return true;
                    }
                }
                return false;
            }
            private bool checkHorizontal()
            {
                for (int index = 0; index <= 6; index += 3)
                {
                    if (squares[index] != Square.Empty)
                    {
                        if (squares[index] == squares[index + 1] && squares[index] == squares[index + 2])
                            return true;
                    }
                }
                return false;
            }
            private bool checkDiagonal()
            {
                if (squares[4] != Square.Empty)
                {
                    if (squares[0] == squares[4] && squares[8] == squares[4])
                    {
                        return true;
                    }
                    if (squares[2] == squares[4] && squares[6] == squares[4])
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
