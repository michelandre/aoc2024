namespace aoc;

public class PageOrdering
{
    private List<(int Page, int MustBeBefore)> _rules = new List<(int Page, int MustBeBefore)>();
    List<int[]> _updates = [];

    private enum ParseState
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
            if (InvalidIndexes(i).Length == 0)
                result.Add(i);
        return result.ToArray();
    }

    public int MiddlePage(int updateIndex)
    {
        return _updates[updateIndex][ _updates[updateIndex].Length / 2];
    }

    public int[] RepairInvalidUpdates()
    {
        var u = InvalidIndexes();
        foreach (var i in u)
        {
            var invalid = i.Item2;
            do
            {
                Swap(i.Update, invalid[0].I1, invalid[0].I2);
                invalid = InvalidIndexes(i.Update);
            } while (invalid.Length > 0);
        }
        return u.Select(i => i.Update).ToArray();
    }

    private int[] Swap(int updateIndex, int i1, int i2)
    {
        var update = _updates[updateIndex];
        (update[i1], update[i2]) = (update[i2], update[i1]);
        return update;
    }
        
    public (int Update, (int I1, int I2)[])[] InvalidIndexes()
    {
        var result = new List<(int Update, (int I1, int I2)[])>();
        for (var i = 0; i < _updates.Count; i++)
        {
            var invalid = InvalidIndexes(i);
            if (invalid.Length > 0)
                result.Add((Update: i, invalid));
        } 
        
        return result.ToArray();
    }

    private (int I1, int I2)[] InvalidIndexes(int index)
    {
        var update = _updates[index];
        var rm = _rules.Select(r => (
                I1: Array.IndexOf(update, r.Page), 
                I2: Array.IndexOf(update, r.MustBeBefore)))
            .Where(t => t.I1 != -1 && t.I2 != -1 && t.I1 > t.I2);
        var result = rm.ToArray();
        Array.Sort(result, (a, b) => (a.I2 - a.I1) - (b.I2 - b.I1));
        return result;
    }
   
}