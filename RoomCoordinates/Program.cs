
Coordinate room1 = new Coordinate(0,0);
Coordinate room2 = new Coordinate(0,1);
Coordinate room3 = new Coordinate(0,2);

Console.WriteLine(room1.IsAdjacent(room2));
Console.WriteLine(room1.IsAdjacent(room3));

Console.WriteLine(room2.IsAdjacent(room1));
Console.WriteLine(room2.IsAdjacent(room3));

Console.WriteLine(room3.IsAdjacent(room1));
Console.WriteLine(room3.IsAdjacent(room2));
public struct Coordinate
{
    public readonly int Row, Column;

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacent(Coordinate other)
    {
        if (other.Row == Row + 1 || other.Row == Row - 1 || other.Row == Row)
        {
            if (other.Column == Column + 1 || other.Column == Column - 1 || other.Column == Column)
            {
                return true;
            }
        }

        return false;
    }
}