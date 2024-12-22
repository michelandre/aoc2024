namespace aoc;

[TestFixture]
public class Aoc20RaceTrack
{
    private const string Test1 = """
                                 ###############
                                 #...#...#.....#
                                 #.#.#.#.#.###.#
                                 #S#...#.#.#...#
                                 #######.#.#.###
                                 #######.#.#...#
                                 #######.#.###.#
                                 ###..E#...#...#
                                 ###.#######.###
                                 #...###...#...#
                                 #.#####.#.###.#
                                 #.#...#.#.#...#
                                 #.#.#.#.#.#.###
                                 #...#...#...###
                                 ###############
                                 """;
    [Test]
    public void SimpleTest1()
    {
        var track = RaceTrack.FromString(Test1);
        var cost = track.Dijkstra2();
        TestContext.Out.WriteLine(cost);    
        //Assert.That(cost, Is.EqualTo(7036));
    }

}