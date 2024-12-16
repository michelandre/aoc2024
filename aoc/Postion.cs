using System.Drawing;

namespace aoc;

public readonly record struct Position(int Row, int Col)
{
    public static Position operator-(Position p1) => new Position(-p1.Col, -p1.Row);
    public static Position operator+(Position p1, Position p2) 
        => new(p1.Row + p2.Row,p1.Col + p2.Col);
    public static Position operator-(Position p1, Position p2) 
        => new(p1.Row - p2.Row,p1.Col - p2.Col);

    public static readonly Position North = new Position(-1, 0);    // -1, +1
    public static readonly Position West = new Position(0, 1);     // +1,+1
    public static readonly Position South = new Position(1, 0);     // +1, -1
    public static readonly Position East = new Position(0, -1);      // -1, -1
    
    public static readonly Position None = new Position(int.MinValue, int.MinValue);
    
    public static Position TurnRight(Position d)
    {
        if (d == North) return West;
        if (d == West) return South;
        if (d == South) return East;
        if (d == East) return North;
        throw new ArgumentOutOfRangeException(nameof(d), d, "Direction not recognized");
    }
    
    public static char DirChar(Position d)
    {
        if (d == North) return 'N';
        if (d == West) return 'W';
        if (d == South) return 'S';
        if (d == East) return 'E';
        return '?';
    }
    
    public override string ToString() => $"({Row},{Col})";
    
}