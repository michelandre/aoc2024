namespace aoc;

[TestFixture]
public class Aoc11PlutoStones
{
    [Test]
    public void SimpleTest1()
    {
        var p = PlutoStones.FromString("0 1 10 99 999");
        Assert.That(p.Blink2(1), Is.EqualTo(7));
        p.Blink();
        TestContext.Out.WriteLine(p.ToString());
        Assert.That(p.ToString(), Is.EqualTo("1 2024 1 0 9 9 2021976"));
      
    }
    
    [Test]
    public void SimpleTest2()
    {
        var p = PlutoStones.FromString("125 17");
        p.Blink();
        Assert.That(p.ToString(), Is.EqualTo("253000 1 7"));
        
        p.Blink();
        Assert.That(p.ToString(), Is.EqualTo("253 0 2024 14168"));
        
        p.Blink();
        Assert.That(p.ToString(), Is.EqualTo("512072 1 20 24 28676032"));
        
        p.Blink();
        Assert.That(p.ToString(), Is.EqualTo("512 72 2024 2 0 2 4 2867 6032"));
        
        p.Blink();
        Assert.That(p.ToString(), Is.EqualTo("1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32"));
        
        p.Blink();
        Assert.That(p.ToString(), Is.EqualTo("2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2"));
    }
    
    [Test]
    public void SimpleTest2_2()
    {
        var p = PlutoStones.FromString("125 17");
        Assert.That(p.Blink2(1), Is.EqualTo(3));
        Assert.That(p.Blink2(2), Is.EqualTo(4));
        Assert.That(p.Blink2(3), Is.EqualTo(5));
        Assert.That(p.Blink2(4), Is.EqualTo(9));
        Assert.That(p.Blink2(5), Is.EqualTo(13));
        Assert.That(p.Blink2(6), Is.EqualTo(22));
        Assert.That(p.Blink2(25), Is.EqualTo(55312));

    }

    [Test]
    public void SolveStep1()
    {
        var p = PlutoStones.FromString("5 127 680267 39260 0 26 3553 5851995");
        TestContext.Out.WriteLine(p.Blink2(25));
        for (var i = 0; i < 25; i++)
        {
            //TestContext.Out.WriteLine(p.ToString());
            p.Blink();
        }
        TestContext.Out.WriteLine(p.Length);
    }
    
    [Test]
    public void SolveStep2()
    {
        var p = PlutoStones.FromString("5 127 680267 39260 0 26 3553 5851995");
        var o = p.Blink2(75);
        TestContext.Out.WriteLine(o);
    }
}