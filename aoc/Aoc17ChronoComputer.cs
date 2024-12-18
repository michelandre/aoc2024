namespace aoc;

[TestFixture]
public class Aoc17ChronoComputer
{
    [Test]
    public void TestSample1()
    {
        var c = new ChronoSpatialComputer(0, int.MaxValue, 9, [2, 6]);
        Assert.That(c.RegC, Is.EqualTo(9));
        Assert.That(c.RegB, Is.EqualTo(int.MaxValue));
        c.Execute();
        Assert.That(c.RegB, Is.EqualTo(1));
    }
    
    [Test]
    public void TestSample2()
    {
        var c = new ChronoSpatialComputer(10, int.MaxValue, int.MaxValue, [5,0,5,1,5,4]);
        Assert.That(c.Execute(), Is.EqualTo(true));
        Assert.That(c.Execute(), Is.EqualTo(true));
        Assert.That(c.Execute(), Is.EqualTo(false));
        var output = c.Output;
        Assert.That(output, Is.EqualTo((int[]) [0,1,2]));
    }
    
    [Test]
    public void TestSample3()
    {
        var c = new ChronoSpatialComputer(2024, int.MaxValue, int.MaxValue, [0,1,5,4,3,0]);
        var steps = 0;
        while (c.Execute()) 
            ++steps;
        var output = c.Output;
        Assert.Multiple(() =>
        {
            Assert.That(output, Is.EqualTo((int[])[4, 2, 5, 6, 7, 7, 7, 7, 3, 1, 0]));
            Assert.That(c.RegA, Is.EqualTo(0));
        });

    }
    
    [Test]
    public void TestSample4()
    {
        var c = new ChronoSpatialComputer(
            int.MaxValue, 
            29, 
            int.MaxValue, 
            [1,7]);
        Assert.That(c.Execute(), Is.EqualTo(false));
        var output = c.Output;
        Assert.Multiple(() =>
        {
            Assert.That(c.RegB, Is.EqualTo(26));
        });
    }
    
    [Test]
    public void TestSample5()
    {
        var c = new ChronoSpatialComputer(
            int.MaxValue, 
            2024, 
            43690, 
            [4,0]);
        Assert.That(c.Execute(), Is.EqualTo(false));
        var output = c.Output;
        Assert.Multiple(() =>
        {
            Assert.That(c.RegB, Is.EqualTo(44354));
        });
    }


    private const string Test1 = """
                                 Register A: 729
                                 Register B: 0
                                 Register C: 0

                                 Program: 0,1,5,4,3,0
                                 """;
    [Test]
    public void TestProgram1()
    {
        var c = ChronoSpatialComputer.FromString(Test1);
        var steps = 0;
        while (c.Execute()) 
            ++steps;
        var output = c.Output; 
        TestContext.Out.WriteLine($"{steps} -> [ {string.Join(",", output)} ]");
        Assert.That(output, Is.EqualTo((int[])[4,6,3,5,6,3,5,2,1,0]));
    }

    private const string Input1 = """
                                  Register A: 37293246
                                  Register B: 0
                                  Register C: 0

                                  Program: 2,4,1,6,7,5,4,4,1,7,0,3,5,5,3,0
                                  """;
    [Test]
    public void Solution1()
    {
        var c = ChronoSpatialComputer.FromString(Input1);
        var steps = 0;
        while (c.Execute()) 
            ++steps;
        var output = c.Output; 
        TestContext.Out.WriteLine($"{steps} -> [ {string.Join(",", output)} ]");
        Assert.That(output, Is.EqualTo((int[])[1,5,0,1,7,4,1,0,3]));
    }
    
    [Test]
    public void Solution2()
    {
        var c = ChronoSpatialComputer.FromString(Input1);        
        var maxA=  (long)Math.Pow(8,c.Program.Length); // N digits,A will be at most 8^N.
        var regA = (long)0;

        while (regA < maxA)
        {
            c.ExecuteWith(regA, 0, 0);
            // When the last digits match for a certain A value,
            // digits will occur again if A is set to A * 8 (adding a digit).
            var outputMatch = c.Program[^c.Output.Length..].SequenceEqual(c.Output);
            if (outputMatch)
            {
                if (c.Program.Length == c.Output.Length) break;
                regA *= 8;
            }
            else
            {
                ++regA;
            }
        }
        TestContext.Out.WriteLine(regA);
        Assert.That(regA, Is.EqualTo(47910079998866));
    }
}