namespace aoc;

public class RopeBridge(List<long[]> numbers)
{
    private List<long[]> _numbers = numbers;
    public static readonly char[] OpSet1 = ['*', '+'];
    public static readonly char[] OpSet2 = ['*', '+', '|'];

    public static RopeBridge FromString(string input)
    {
        var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
         
        var numbers = lines.Select(
            l => l.Replace(":", string.Empty)
                .Split(' ')
                .Select(long.Parse)
                .ToArray()).ToList();
        return new RopeBridge(numbers);
    }

    public long CalibrationResult(char[] opSet)
    {
        var calibration = _numbers.Select(n => Calibrate(n, opSet)).ToArray();
        return calibration.Sum();
    }

    private long Calibrate(long[] numbers, char[] opSet)
    {
        var operatorPermutations = new List<string>();
        GeneratePermutations(opSet, string.Empty, numbers.Length - 2, operatorPermutations);
        foreach (var perm in operatorPermutations)
        {
            var sum = numbers[1];
            for (var i = 2; i < numbers.Length; i++)
            {
                var op = perm[i - 2];
                switch (op)
                {
                    case '+': sum += numbers[i]; break;
                    case '*': sum *= numbers[i]; break;
                    case '|': sum =  long.Parse(sum.ToString() + numbers[i].ToString()); break;
                    default: throw new InvalidOperationException();
                }
                if (sum > numbers[0])
                    break;
            }
            if (sum == numbers[0])
                return sum;
        }
        return 0;
    }

    private static void GeneratePermutations(char[] characters, string current, int n, List<string> permutations)
    {
        if (current.Length == n)
        {
            permutations.Add(current);
            return;
        }

        foreach (var c in characters)
            GeneratePermutations(characters, current + c, n, permutations);
    }
}