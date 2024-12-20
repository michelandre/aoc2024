using System.ComponentModel;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace aoc;

public class MemoryGrid(char[,] input, Position[] corrupted)
{
    private readonly char[,] _grid = input;
    private readonly Position[] _corrupted = corrupted;

    private const char Empty = '.';
    private const char Corrupt = '#';

    public static MemoryGrid FromString(int gridSize, string input)
    {
        var reader = new StringReader(input);
        var lines = input.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.None
        );
        var corrupted = new List<Position>(lines.Length);
        foreach (var t in lines)
        {
            var coord = t.Split(',').Select(int.Parse).ToArray();
            corrupted.Add(new Position(coord[1], coord[0]));
        }

        var grid = new char[gridSize, gridSize];
        for (var row = 0; row < grid.GetLength(0); row++)
        for (var col = 0; col < grid.GetLength(0); col++)
            grid[row, col] = Empty;
        return new MemoryGrid(grid, corrupted.ToArray());
    }

    public override string ToString()
    {
        var sb = new StringBuilder(_grid.GetLength(0) * _grid.GetLength(1));
        for (var row = 0; row < _grid.GetLength(0); row++)
        {
            for (var col = 0; col < _grid.GetLength(1); col++)
                sb.Append(_grid[col, row]);
            sb.AppendLine();
        }
        sb.Remove(sb.Length - 2, 2);
        return sb.ToString();
    }

    public Position CorruptGrid(int count)
    {
        for (var i = 0; i < count; i++)
        {
            var pos = _corrupted[i];
            _grid[pos.Col, pos.Row] = Corrupt;
        }
        return _corrupted[count - 1];
    }

    private char this[Position position]
    {
        get => _grid[position.Col, position.Row];
        set => _grid[position.Col, position.Row] = value;
    }
    
    private bool IsInGrid(Position pos)
    {
        return pos.Row >= 0 && pos.Row < _grid.GetLength(1) &&
               pos.Col >= 0 && pos.Col < _grid.GetLength(0);
    }

    /// Finds the shortest path in the grid from the given start position to the end position.
    /// The method uses a variation of the A* algorithm to calculate the shortest path,
    /// avoiding corrupted cells and navigating within grid boundaries.
    /// <param name="start">The starting position on the grid.</param>
    /// <param name="end">The target position on the grid.</param>
    /// <returns>An array of positions representing the shortest path from the start to the end position.
    /// If no path exists, returns an empty array.</returns>
    public Position[] ShortestPath(Position start, Position end)
    {
        var open = new PriorityQueue<(Position P, int G, int H), int>();
        var visited = new HashSet<Position>();
        var parent = new Dictionary<Position, Position>();
        var gScores = new Dictionary<Position, int>();
        var hs = ManhattanDistance(start, end);
        open.Enqueue((start, 0, hs), hs);
        while (open.Count > 0)
        {
            var current = open.Dequeue();
            if (current.P == end)
            {
                return BuildPath(parent, current.P);
            }

            visited.Add(current.P);
            var neighbours =
                new (Position P, int C)[]
                {
                    (current.P + Position.East, 1),
                    (current.P + Position.West, 1),
                    (current.P + Position.North, 1),
                    (current.P + Position.South, 1)
                };
            foreach (var n in neighbours)
            {
                if (!IsInGrid(n.P)) continue;
                if (visited.Contains(n.P)) continue;
                if (this[n.P] == Corrupt) continue;
                var g = current.G + 1;
                if (gScores.TryGetValue(n.P, out var value) && value <= g) continue;
                gScores[n.P] = g;
                parent[n.P] = current.P;
                var hn = ManhattanDistance(n.P, end);
                open.Enqueue((n.P, g, hn), g + hn);
            }
        }
        return [];
    }

    private static Position[] BuildPath(Dictionary<Position, Position> parent, Position current)
    {
        var path = new List<Position> { current };
    
        while (parent.ContainsKey(current))
        {
            current = parent[current];
            path.Add(current);
        }
        path.Reverse();
        return path.ToArray();
    }

    private int ManhattanDistance(Position current, Position goal)
    {
        return Math.Abs(current.Col - goal.Col) + Math.Abs(current.Row - goal.Row);
    }
    
}