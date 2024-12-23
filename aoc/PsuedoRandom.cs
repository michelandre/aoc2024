namespace aoc;

public class PsuedoRandom(long[] init)
{
    private long[] _init = init;

    public static PsuedoRandom FromString(string input)
    {
        var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        return new PsuedoRandom(lines.Select(long.Parse).ToArray());
    }

    public long SecretSum(int n)
    {
        var random = _init.Select(i => GenerateSeries(i, n).Last()).ToArray();
        return random.Sum();
    }

    public long MostBananasSum(int n)
    {
        var cost = _init.Select(
            i => GenerateSeries(i, n)
                .ToArray())
            .ToArray();
        var diffSeq = cost.Select(DiffSequence);
        var diffs = new DefaultDictionary<string, long>(0);
        foreach (var diff in diffSeq)
            foreach (var d in diff)
                diffs[d.Key] += d.Value;
        return diffs.Values.Max();
    }

    public static DefaultDictionary<string, long> DiffSequence(long[] cost)
    {
        DefaultDictionary<string, long> diffs = new DefaultDictionary<string, long>(0);
        cost = cost.Select( c => c % 10).ToArray();
        var diff = cost.Zip(cost.Skip(1)).Select(p => p.Second - p.First).ToArray();
        for (var i = 0; i < cost.Length - 4; i++)
        {
            var key = string.Join(",",diff[i..(i + 4)]);
            // Monkeys only can take first sequence seen before moving to next
            if (!diffs.ContainsKey(key)) diffs[key] = cost[i + 4];
        }
        return diffs;
    }

    public static long[] GenerateSeries(long init, int n)
    {
        var res = new long[n];
        for (var i = 0; i < n; i++)
        {
            init = NextPsuedo(init);
            res[i] = init;
        }

        return res;
    }

    public static long NextPsuedo(long secret)
    {
        var res = secret;
        
        res *= 64;
        res = secret ^ res;
        res = res % 16777216;
        
        secret = res;
        res /= 32;
        res = secret ^ res;
        res %= 16777216;

        secret = res;
        res *= 2048;
        res = secret ^ res;
        res %= 16777216;

        return res;
        
    }
}