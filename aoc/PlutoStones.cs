using System.Reflection.Metadata.Ecma335;

namespace aoc;

public class PlutoStones(IEnumerable<ulong> stones)
{
    private List<ulong> _stones = stones.ToList();
    public int Length => _stones.Count;

    public static PlutoStones FromString(string stoneString)
    {
        var stones = stoneString.Split([" "], StringSplitOptions.None);
        return new PlutoStones(stones.Select(ulong.Parse));
    }

    public override string ToString()
    {
        return string.Join(" ", _stones);
    }

    public void Blink()
    {
        var stones = new List<ulong>(_stones.Count * 2);
        foreach (var stone in _stones)
        {
            // Rule 1
            if (stone == 0)
            {
                stones.Add(1);
                continue;
            }
            
            // Rule 2
            var stoneStr = stone.ToString();
            if (stoneStr.Length % 2 == 0)
            {
                stones.Add(ulong.Parse(stoneStr[..(stoneStr.Length / 2)]));
                stones.Add(ulong.Parse(stoneStr[(stoneStr.Length / 2)..]));
                continue;
            }
            
            // Rule 3
            stones.Add(stone * 2024);
        }
        _stones = stones;
    }
    
    public ulong Blink2(int times)
    {
        var stones = new Dictionary<ulong,ulong>();
        foreach (var stone in _stones)
        {
            stones.TryAdd(stone, 0);
            stones[stone]++;
        }

        for (var i = 0; i < times; i++)
        {
            var stones2 = new Dictionary<ulong, ulong>();
            foreach (var stone in stones)
            {
                // Rule 1
                if (stone.Key == 0)
                {
                    stones2.TryAdd(1, 0);
                    stones2[1] += stone.Value;
                    continue;
                }

                // Rule 2
                var stoneStr = stone.Key.ToString();
                if (stoneStr.Length % 2 == 0)
                {
                    var s1 = ulong.Parse(stoneStr[..(stoneStr.Length / 2)]);
                    var s2 = ulong.Parse(stoneStr[(stoneStr.Length / 2)..]);
                    stones2.TryAdd(s1, 0);
                    stones2[s1] += stone.Value;
                    stones2.TryAdd(s2, 0);
                    stones2[s2] += stone.Value;
                    continue;
                }

                // Rule 3
                var s = stone.Key * 2024;
                stones2.TryAdd(s, 0);
                stones2[s] += stone.Value;
            }
            stones = stones2;
        }

        return stones.Values.Aggregate<ulong, ulong>(0, (current, stone) => current + stone);
    }
}