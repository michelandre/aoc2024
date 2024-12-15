namespace aoc;


public class LevelReports
{
    private readonly List<List<int>> _levels = new List<List<int>>();
    
    public static LevelReports FromString(string input)
    {
        var lr = new LevelReports();
        var reader = new StringReader(input);
        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
            var levelReport = line.Split([" "], StringSplitOptions.None);
            lr._levels.Add(levelReport.Select(int.Parse).ToList());
        }
        return lr;
    }
    
    public bool[] SafeReports() 
        => _levels.Select((x) => IsSafe(x)).ToArray();
    
    public bool[] SafeReportsWithDampening() 
        => _levels.Select((x) => IsSafe(x, true)).ToArray();

    private static bool IsSafeDampened(List<int> level)
    {
        for (var k = 0; k < level.Count; k++)
        {    
            var filtered = level.ToList();
            filtered.RemoveAt(k);
            if (IsSafe(filtered, false))
                return true;
        }
        return false;

    }

    private static bool IsSafe(List<int> level, bool withDampening = false)
    {
        int i = 0, j = 1;
        var direction = int.Sign(level[j] - level[i]);
        for (; j < level.Count; j++, i++)
        {
            var diff = level[j] - level[i];
            if (direction != int.Sign(diff))
            {
                return withDampening && IsSafeDampened(level);
            }

            diff = Math.Abs(diff);
            if (diff < 1 || diff > 3)
            {
                return withDampening && IsSafeDampened(level);
            }
        }
        return true;
    }
}

