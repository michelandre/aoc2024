using System.Text;

namespace aoc;

public class TopoMap
{
    private int[,] _map;

    private TopoMap(int[,] map)
    {
        _map = map;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(_map.GetLength(0) * _map.GetLength(1));
        for (var row = 0; row < _map.GetLength(0); row++)
        {
            for (var col = 0; col < _map.GetLength(1); col++)
            {
                switch (_map[row, col])
                {
                    case int.MaxValue:
                        sb.Append('.');
                        break;
                    case int.MinValue:
                        sb.Append('*');
                        break;
                    default: 
                        sb.Append( _map[row, col].ToString());
                        break;
                }
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public static TopoMap FromString(string topoMap)
    {
        var lines = topoMap.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.None
        );
        var map = new int[lines.Length, lines[0].Length];
        for (var row = 0; row < lines.Length; row++)
        {
            for (var col = 0; col < lines.Length; col++)
            {
                var height = lines[row][col];
                map[row, col] = height != '.' ? height - '0' : int.MaxValue;
            }
        }

        return new TopoMap(map);
    }

    public int[] CalcTrailCount()
    {
        var counts = new List<int>();
        for (var row = 0; row < _map.GetLength(0); row++)
        {
            for (var col = 0; col < _map.GetLength(1); col++)
            {
                var count = CalcTrailCount(row, col);
                if (count > 0) 
                    counts.Add(count);
            }
        }
        return counts.ToArray();
    }
    
    public int[] CalcTrailRatings()
    {
        var counts = new List<int>();
        for (var row = 0; row < _map.GetLength(0); row++)
        {
            for (var col = 0; col < _map.GetLength(1); col++)
            {
                if (_map[row, col] != 0) continue;
                var count = ReachedTrailHead(row, col);
                if (count > 0) 
                    counts.Add(count);
            }
        }
        return counts.ToArray();
    }

    public int CalcTrailCount(int row, int col)
    {
        if (_map[row, col] != 0) return 0;
        //TestContext.Out.WriteLine($"{row}, {col}");
        var visited = new int[_map.GetLength(0), _map.GetLength(1)];
        var count = ReachedTrailHead(row, col, visited);
        return count;
    }

    private int ReachedTrailHead(int row, int col, int[,]? visited = null)
    {
            if (visited != null)
            {
                if (visited[row, col] > 0)
                    return 0;
                ++visited[row, col]; 
            }
            
            var count = 0;
            var m = _map[row, col];
            if (m == 9) 
                return 1;
            if (row - 1 >= 0 && _map[row - 1, col] - m == 1)
                count += ReachedTrailHead(row - 1, col, visited); // Up
            if (row + 1 < _map.GetLength(0) && _map[row + 1, col] - m == 1)
                count += ReachedTrailHead(row + 1, col, visited); // Down
            if (col - 1 >= 0 && _map[row, col - 1] - m == 1) 
                count += ReachedTrailHead(row, col - 1, visited); // Left
            if (col + 1 < _map.GetLength(1) && _map[row, col + 1] - m == 1) 
                count += ReachedTrailHead(row, col + 1, visited); // Right
            
            return count;
     
    }
}