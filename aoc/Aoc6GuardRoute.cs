namespace aoc;

public class Aoc6GuardRoute
{
    private const string Test1 = """
                                 ....#.....
                                 .........#
                                 ..........
                                 ..#.......
                                 .......#..
                                 ..........
                                 .#..^.....
                                 ........#.
                                 #.........
                                 ......#...
                                 """;
    [Test]
    public void SimpleTest1()
    {
        var guardMap = GuardMap.FromString(Test1);
        var guardRoute = guardMap.GuardRoute();
        Assert.That(guardRoute.Distinct().Count(), Is.EqualTo(41));
    }
    
    [Test]
    public void SimpleTest2()
    {
        var guardMap = GuardMap.FromString(Test1);
        var loopRoute = guardMap.CausesLoop();
        Assert.That(loopRoute.Length, Is.EqualTo(6));
    }
    [Test]
    public void Solution1()
    {
        var guardMap = GuardMap.FromString(Input1);
        var guardRoute = guardMap.GuardRoute();
        TestContext.Out.WriteLine(guardRoute.Distinct().Count());
        Assert.That(guardRoute.Distinct().Count(), Is.EqualTo(4789));
    }
    
    [Test]
    public void Solution2()
    {
        var guardMap = GuardMap.FromString(Input1);
        var loopRoute = guardMap.CausesLoop();
        TestContext.Out.WriteLine(loopRoute.Length);
        // Assert.That(loopRoute.Length, Is.EqualTo(6));    
    }

    private const string Input1 = """
                                  ..........##.....................................#............#........................#.....#........#...........#...............
                                  ...........#.............#.....#....................#...........#.#..............#.#......................................#.......
                                  .#..............#...............................#.......#.#...................#...............#...............#..#...........#....
                                  .#............................#.............................................................................#.#...................
                                  ...............#..........#............#...........................................#....#...#..........................#..........
                                  ..##.#..#......#.....................#..#......#................#..........................................#................#.....
                                  .......#.....#...........................................#........#...............................#.#.............................
                                  .........#...............#......#............#...................#...........#.........#..#...#...................................
                                  #.....#.#....................................#.......................................................##..#...##..#..#.............
                                  .............................#...#.......#...............................#.#...............#......................................
                                  .....#................................#..........................#....................#...........................................
                                  .......#............#..#................................................................................#..........#...#..........
                                  ...........#.............................................................#...............#................................#.....#.
                                  .....................................................#.........#.....#..#.....#..................#.......#.....#...........#......
                                  .#..........#................#..................#........#..............................................#....#..................#.
                                  .....................#......#..........#...........#................#..#..#............................#...##.........#...........
                                  .................#.....................................................................................#..........................
                                  ..........................#.....................................#.#..................................................#.#..........
                                  ............#....#........#...................................#...................................................#...............
                                  ............#........................#........##..............#....#.............#............#......#........#...................
                                  ....................#.#........#..........................#...........#.............#...............#.............##.......#......
                                  ...............................................#..................................#...................................#....##.....
                                  ...#.....#.......................................#..........#......................#.............#.............#.##.......#.......
                                  ........#......##...................................................................................#.............................
                                  ...#.................................#.....................................#......................................#.........#.....
                                  ....#.................#......#.........#.........................................................................#........#....#..
                                  ..........................#..#.......#............................##.............................................#.........##..#..
                                  ......................#......................................#......................#................#.........#..#...............
                                  ....#.....................................#...................#..............#..........................#...........#...#.........
                                  ...............#........#...............#..........#.....#..............................#....................................#.#..
                                  ......#......................#.......#.#...................#.............#...#.........#.....#....................................
                                  .....#..#...............##....................................................#..#...#........................#..................#
                                  ......#.#..........#...#.................#...............#..........................................#...#.#.......................
                                  ..........#.......................................................................................................##..............
                                  ......................#..#...#......#.....................................................#.........#.........#...................
                                  ...................................................#...#.........#.....#......................#...............................#...
                                  ........................#...................................^..............................#.............#..........#...#.........
                                  ........#............................#.....................#......#...........##...........#......................................
                                  ..........#..................#........#...........................................................................................
                                  .....#......................#.....#.............#....................#...............#...........##.......#..................##...
                                  ........#......................................#................................................#.....................#...........
                                  ......#.........#..............#.................................................................#.......##..#.#..................
                                  ........#......................................#...................#......................#.......................................
                                  ..#...............#....##.....#........................#.#.........#........#....#...................#.............#...#.........#
                                  .............#..............#....#....#................#.....................................#...............#..................#.
                                  ..............#...........................................................................#..##..#...#.......#..........#.........
                                  #...........#........................#..#......#..#.........#........#...#..............#............#.....#.................#...#
                                  .....................#........................................#.................#.#..................#.............#.........#....
                                  .............#.....................................................#.#....................................#.......................
                                  .............#....#.............#.........................................................................#...........#...........
                                  #.................#...#...#...............#..........#.........................##......#.....#..#.............................#...
                                  #................#........#.......#.....#...............#..................................#.#.............................#......
                                  .........#.......#.............#...................................................................................#..........#...
                                  ......#..............................................................................##............................#..........#...
                                  ..............#..................................................#...................................#..........................#.
                                  .................................................................#.#...........#................#..........#..........#.......#.#.
                                  ...................................#.....................#..#...........................................................#.........
                                  ......................................................................................#.............#.............................
                                  .....#......................................................................#......#....#.........#....#..#.......................
                                  ..................#.............................................................#.........................#.......................
                                  ......................#......#..........#..#............................#....#.........#.........#................................
                                  ..#...........#.......................#....#....................................#.......#.................................#.......
                                  ...................#.......................................................................................#..............#.......
                                  .....#....................................#......#............#...##........#...............#......................#...........#..
                                  ......................................#.......................#.........#.#.........................................#.............
                                  ...#..............................................#................................................##...........................#.
                                  .......................#.................................................................#.......................................#
                                  .#...........#..#...................#.#......#................#......................................................#............
                                  .......................................................................##..........#......#................#.......#.......#......
                                  #..#...#...........................................#......#...............#.......................................................
                                  ....#.....#...........................#...........#...............##..............................................................
                                  ...#.......#.......................................................................................#............#.................
                                  .............................................................................#...#.....................#...#......................
                                  ...................#.................................#.......#...........................#.....#.................................#
                                  .........................................#........#....#.............#.............#...........................#..................
                                  ....#.....................................................................................#.#.#.......................#.#.........
                                  ..............................................................#..........#............................................#...........
                                  .........#.#.............................#...#..........................#....................#....................................
                                  ......................................#.#......#..................................................................................
                                  .................................................................................................................#................
                                  ..............#...................................................................................................................
                                  ...................................................#....................................................................##........
                                  ................#........................................#..............................................#...............#.........
                                  .........#....#...#......#....................#.#.......................................#.............#.....#..............#....#.
                                  .............................................................................................................##.....#..#..........
                                  ....#.............................#......#.....................................................#......................#.......#...
                                  ..#.................#........................#....#...##...................................#...............#......................
                                  .........#..................................#.................#...#..#..........##................................................
                                  ......##.......................................................#...........#......................................................
                                  ......#..............................#...................##....#..................................................................
                                  ..................#.........#.................................................#.......#..................#........................
                                  .........................#...........................................#.......#...........................................#........
                                  ............#.#...................#.#....#.................................#......##...........................................#..
                                  ..#....................#.....................#.........................#..............#.....#.........#...........................
                                  ..#............................................#.........................#....................#..................................#
                                  ...........................#......#...............................................................#......#..........#..........#..
                                  .......................#.....#..................#...................................#.............#....#.....................#....
                                  ....................................................................#.....#....#..................................................
                                  ..#................#...#..........................................................................................................
                                  .........................##.....#.................#.............#....................#...............#..............#......#.#....
                                  .......................#...................##......................................#....#...............#........#.........#......
                                  ......#..#.........#............................................................#................................#......#.........
                                  #........................#..................#...............................................#.#........#..........................
                                  ..........#................#...#.....................................................#............#...............................
                                  ............#................................................#.#...............#............#................................#....
                                  ..#............................................#....#....#.#.#................................#....................#..............
                                  .........#...........................##.............#..#.................#........................#............................#..
                                  ..........................##......................#..............................#..................#.............................
                                  .........#........#.......#..........#...........#.............................#...........................#.......#..............
                                  ..........................#................#......................................................................................
                                  ..........................#...............#..................#....................................#.........#....#..........#.....
                                  ..................#..#..................................................................#........#................................
                                  ##..#.......#..............#..#..............##.............#...#..#.........##.......................................#......#....
                                  .............#.........#........#....................................................#................#.....#.....................
                                  ......#...................................#.....#................#..........................#.....................................
                                  ..#.......................#...#.#...#...........#..........#...................................#.............#.....#..............
                                  ..........#...#......................##...........................................................................................
                                  ....#............................#.#...................#....................#................#...........#..................#.....
                                  .......#......#................#......................#......#........##..#....................#..................................
                                  .......#..................#....#.....................................................................................#............
                                  ..................#......#................................#.........................#....#.............................#...#......
                                  .................#.............#..........#....#.........................#..................................#.....##...........##.
                                  ............#..#............................................................................##...#.#....#....#.......##.#.......#.
                                  ......................#............................#.........#.....#.#.......##........................#..........................
                                  ...........#........................#..##........#....#.......#....#.#.....##.....................#.......#......#...............#
                                  .................#...........#.......#..........#................................................#......................#.........
                                  ................#.......#.#.....................................................................................#.................
                                  ........................................#...#......#.......................................#...........#..........................
                                  ....#........##...............#...........#..................................................................#....................
                                  #....................#...................#.........#....................................................................#.........
                                  """;

}