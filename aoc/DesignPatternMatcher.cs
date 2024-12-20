using System.Buffers;
using System.Diagnostics;

namespace aoc;
[DebuggerDisplay("{ToString(),nq}")]
public record class MatchList {
    public List<string> Patterns { get; init; } = [];
    public int MatchedLength { get; set; }
    public string MatchedDesign => string.Join("", Patterns);
    public override string ToString() => $"'{string.Join("|", Patterns)}':{MatchedLength}";
};
public class DesignPatternMatcher(string[] patterns, string[] designs)
{
    private readonly string[] _patterns = patterns;
    private readonly string[] _designs = designs;
    
    public static DesignPatternMatcher FromString(string input)
    {
        var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        var patterns = lines[0].Split(',').Select(s => s.Trim()).ToArray();
        var designs = lines[2..].ToArray();
        return new DesignPatternMatcher(patterns, designs);
    }

    public long[] FindMatches()
    {
        var result = new long[_designs.Length];
        for (var i = 0; i < _designs.Length; i++)
            result[i] = MatchCountForDesign(_designs[i], new Dictionary<string, long>());
        return result;
    }

    private long MatchCountForDesign(string design, Dictionary<string, long> cache)
    {
        if (cache.TryGetValue(design, out var count)) return count;
        if (design.Length == 0) return 1;
        var result = (long)0;
        foreach (var pattern in _patterns)
            if (design.StartsWith(pattern))
                result += MatchCountForDesign(design.Substring(pattern.Length), cache);
        cache.Add(design, result);
        return result;
    }
    
}