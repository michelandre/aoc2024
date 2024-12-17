namespace aoc;

public class Maze
{
    private readonly char [,] _map;
    private readonly Position _start;
    private readonly Position _end;

    private const char Empty = '.';
    private const char Wall = '#';
    private const char End = 'E';
    private const char Start = 'S';
    
    public Maze(char[,] input)
    {
        _map = input;
        _start = FindFirst(Start);
        _end = FindFirst(End);
    }
    
    public static Maze FromString(string input)
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
        return new Maze(map);
    }
    
    public enum ReturnType { Cost,TileCount };
    public int Dijkstra2(ReturnType costOrTiles = ReturnType.Cost)
    { 
        var queue = new PriorityQueue<(Position P, Position D, int Cost, HashSet<Position> Visited), int>();
        queue.Enqueue((_start, Position.East, 0, []),0); 

        var seen = new Dictionary<(Position P, Position D), int>
        {
            [(_start, Position.East)] = 0
        };
        var positionsAlongShortestPaths = new HashSet<Position> { _start };
        var lowestCost = int.MaxValue;
        
        while (queue.Count > 0)
        {
            var (p, d, cost, visited) = queue.Dequeue();
            if (cost > lowestCost) break;
            if (p == _end)
            {
                lowestCost = cost;
                positionsAlongShortestPaths.UnionWith(visited);
            }
            if (seen.GetValueOrDefault((p, d), int.MaxValue) < cost) continue;
            seen[(p, d)] = cost;
            
            var states = 
                new (Position P, Position D, int Cost)[]
                {
                    (p + d, d, cost + 1), // Straight 
                    (p + d.ToLeft(), d.ToLeft(), cost + 1001), // Turn L,
                    (p + d.ToRight(), d.ToRight(), cost + 1001) , // Turn R
                };
            foreach (var s in states)
            {
                var visited2 = new HashSet<Position>(visited) { s.P };
                if (_map[s.P.Row, s.P.Col] == Wall) continue;
                queue.Enqueue((s.P, s.D, s.Cost, visited2), s.Cost);
            }
        }
        return costOrTiles switch
        {
            ReturnType.Cost => lowestCost,
            ReturnType.TileCount => positionsAlongShortestPaths.Count,
            _ => throw new ArgumentOutOfRangeException(nameof(costOrTiles))
        };
    }
    
    private Position FindFirst(char c)
    {
        for (var row = 0; row < _map.GetLength(0); row++)
        for (var col = 0; col < _map.GetLength(1); col++) 
            if (_map[row, col] == c)
                return new Position(row, col);
        return Position.None;
    }
}