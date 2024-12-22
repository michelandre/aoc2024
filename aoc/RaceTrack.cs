using System.Drawing;

namespace aoc;

public class RaceTrack
{
    private readonly char[,] _map;
    public Position StartPos { get; }
    public Position EndPos { get; }

    private const char Empty = '.';
    private const char Wall = '#';
    private const char End = 'E';
    private const char Start = 'S';

    public RaceTrack(char[,] input)
    {
        _map = input;
        StartPos = FindFirst(Start);
        EndPos = FindFirst(End);
    }

    public static RaceTrack FromString(string input)
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
        return new RaceTrack(map);
    }

    public Dictionary<Position, int> Dijkstra2() => Dijkstra2(StartPos, EndPos);
    public Dictionary<Position, int> Dijkstra2(Position start, Position end)
    {
        var queue = new PriorityQueue<Position, int>([(start, 0)]);
        var result = new DefaultDictionary<Position, int>(
            int.MaxValue, [(start, 0)]);
        var prev = new Dictionary<Position, Position>();
        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            if (p == end) break;

            Position[] neighbors = [p + Position.East, p + Position.West, p + Position.North, p + Position.South];
            foreach (var n in neighbors)
            {
                if (_map[n.Row,n.Col] != '#' && result[p] + 1 < result[n])
                {
                    result[n] = result[p] + 1;
                    queue.Enqueue(n, result[n]);
                }
            }
        }

        return result.ToDictionary(x => x.Key, x => x.Value);
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