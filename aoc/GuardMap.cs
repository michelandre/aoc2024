using System.IO.Enumeration;
using System.Runtime.CompilerServices;

namespace aoc;

public class GuardMap(char[,] input)
{ 
    private readonly char [,] _map = input;
    private const char Empty = '.';
    private const char Obstacle = '#';
    private const char Guard = '^';

    
    public static GuardMap FromString(string input)
    {
        var reader = new StringReader(input);
        var lines = input.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.None
        );
        var map = new char[lines.Length, lines[0].Length];
        for (var row = 0; row < lines.Length; row++)
            for (var col = 0; col < lines.Length; col++)
                map[row, col] = lines[row][col];
        return new GuardMap(map);
    }

    public Position[] GuardRoute()
    {
        var guard = FindFirst(Guard);
        var current = guard;
        var direction = Position.North;
        var result = new List<Position>();
        result.Add(current);
        while (IsOnMap(current) && result.Count < TileCount)
        {
            var next = current + direction;
            if (IsOnMap(next) && this[next] == Obstacle)
            {
                direction = Position.TurnRight(direction);
                next = current + direction;
            }
            if (IsOnMap(next)) result.Add(next);
            current = next;
        }
        return result.ToArray();
    }
    
    public bool HasLoop()
    {
        var current = FindFirst(Guard);
        var direction = Position.North;
        var visited = new HashSet<(Position, Position)>();
        while (true)
        {
            visited.Add((current, direction));
            var next = current + direction;
            if (!IsOnMap(next))
                break;
            if (this[next] == Obstacle)
                direction = Position.TurnRight(direction);
            else
                current = next;
            
            if (visited.Contains((next, direction)))
                return true;
            
        }
        return false;
    }

    private int TileCount => _map.GetLength(0) * _map.GetLength(1);

    public Position[] CausesLoop()
    {
        var guard = FindFirst(Guard);
        var result = new List<Position>();
        var route = GuardRoute().Distinct();
        foreach (var pos in route)
        {
            if (_map[pos.Row, pos.Col] != Empty)
                continue;
            _map[pos.Row, pos.Col] = Obstacle;
            if (HasLoop())
                result.Add(pos);
            _map[pos.Row, pos.Col] = Empty;

        }

        return result.ToArray();
    }
    
    private char this[Position next]=> _map[next.Row, next.Col];
 

    private bool IsOnMap(Position pos)
    {
        return pos.Row >= 0 && pos.Row < _map.GetLength(0) &&
               pos.Col >= 0 && pos.Col < _map.GetLength(1);
    }

    private Position FindFirst(char guard)
    {
        for (var row = 0; row < _map.GetLength(0); row++)
            for (var col = 0; col < _map.GetLength(1); col++) 
                if (_map[row, col] == guard)
                    return new Position(row, col);
        return Position.None;
    }
}