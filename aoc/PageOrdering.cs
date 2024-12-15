namespace aoc;

public class PageOrdering
{
    private List<(int Page, int MustBeBefore)> _rules = new List<(int Page, int MustBeBefore)>();
    List<int[]> _updates = new List<int[]>();

    enum ParseState
    {
        Rule,
        Update
    }
    
    public static PageOrdering FromString(string input)
    {
        var sr = new StringReader(input);
        var parseState = ParseState.Rule;   
        var result = new PageOrdering();
        while (sr.ReadLine() is { } line)
        {
            if (line.Trim().Length == 0)
            {
                parseState = ParseState.Update;
                continue;
            }
            string[] parts;
            switch (parseState)
            {
                case ParseState.Rule:
                    parts = line.Split("|");
                    var page = int.Parse(parts[0].Trim());
                    var mustBeBefore = int.Parse(parts[1].Trim());
                    result._rules.Add((page, mustBeBefore));
                    break;
                case ParseState.Update:
                    parts = line.Split(",");
                    result._updates.Add(parts.Select(int.Parse).ToArray());
                    break;
                default:
                    throw new FormatException();
            }
        }

        return result;
    }
    
    public int[] ValidUpdates()
    {
        var result = new List<int>();
        for(var i = 0; i < _updates.Count; i++)
            if (IsValidUpdate(i))
                result.Add(i);
        return result.ToArray();
    }

    public int MiddlePage(int updateIndex)
    {
        return _updates[updateIndex][ _updates[updateIndex].Length / 2];
    }
    
    bool IsValidUpdate(int index)
    {
        var update = _updates[index];
        var rm = _rules.Select(
            r =>
                Tuple.Create(
                    Array.IndexOf(update, r.Page),
                    Array.IndexOf(update, r.MustBeBefore)))
            .Where(t => t.Item1 != -1 && t.Item2 != -1);
        return rm.All(t => t.Item1 < t.Item2);
    }
}