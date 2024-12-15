using Is = NUnit.Framework.Is;

namespace aoc;

[TestFixture]
public class Aoc10TopoMap
{
    private const string TopoMap1 = """
                                    ...0...
                                    ...1...
                                    ...2...
                                    6543456
                                    7.....7
                                    8.....8
                                    9.....9
                                    """;

    [Test]
    public void TrailHeadCountSimple()
    {
        var t = TopoMap.FromString(TopoMap1);
        var count = t.CalcTrailCount();
        Assert.That(count.Length, Is.EqualTo(1));
        Assert.That(count[0], Is.EqualTo(2));
    }

    private const string TopoMap2 = """
                                    ..90..9
                                    ...1.98
                                    ...2..7
                                    6543456
                                    765.987
                                    876....
                                    987....
                                    """;
    [Test]
    public void TrailHeadCountSimple2()
    {
        var t = TopoMap.FromString(TopoMap2);
        var count = t.CalcTrailCount();
        Assert.That(count.Length, Is.EqualTo(1));
        Assert.That(count[0], Is.EqualTo(4));
    }

    private const string TopoMap3 = """
                                    89010123
                                    78121874
                                    87430965
                                    96549874
                                    45678903
                                    32019012
                                    01329801
                                    10456732
                                    """;
    [Test]
    public void TrailHeadCountSimple3()
    {
        var t = TopoMap.FromString(TopoMap3);
        var count = t.CalcTrailCount();
        Assert.That(count.Length, Is.EqualTo(9));
        Assert.That(count[0], Is.EqualTo(5));
        Assert.That(count[1], Is.EqualTo(6));
        Assert.That(count[2], Is.EqualTo(5));
        Assert.That(count[3], Is.EqualTo(3));
        Assert.That(count[4], Is.EqualTo(1));
        Assert.That(count[5], Is.EqualTo(3));
        Assert.That(count[6], Is.EqualTo(5));
        Assert.That(count[7], Is.EqualTo(3));
        Assert.That(count[8], Is.EqualTo(5));
        Assert.That(count.Sum(), Is.EqualTo(36));
    }
    
    [Test]
    public void TrailHeadCountSimple4()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(0,2), Is.EqualTo(5));
    }
    
    [Test]
    public void TrailHeadCountSimple5()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(0,4), Is.EqualTo(6));
    }
    
    [Test]
    public void TrailHeadCountSimple6()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(2,4), Is.EqualTo(5));
    }
    
    [Test]
    public void TrailHeadCountSimple7()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(4,6), Is.EqualTo(3));
    }
    
    [Test]
    public void TrailHeadCountSimple8()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(5, 2), Is.EqualTo(1));
    }
    
    [Test]
    public void TrailHeadCountSimple9()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(5, 5), Is.EqualTo(3));
    }
    
    [Test]
    public void TrailHeadCountSimple10()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(6, 0), Is.EqualTo(5));
    }
    
    [Test]
    public void TrailHeadCountSimple11()
    {
        var t = TopoMap.FromString(TopoMap3);
        Assert.That(t.CalcTrailCount(7, 1), Is.EqualTo(5));
    }

    private const string TopoMap4 = """
                                    670107898789217654342123456782345678011256767898765465432101
                                    789234567654308210256034105891089019100349897767874376569101
                                    658341234530989300107845234521078323270110588758901287478272
                                    345450347621895418916976367652569454589223679643210896564383
                                    430569678934786917014989898743458765678334534554034787665898
                                    521678432825677806323876321212345107895450128765125693456721
                                    437876501910543215214985400303434234784966549834296502107610
                                    108978967865676784305673212345125105672877838126787411098523
                                    232169054654985895676894501876056216781236923035498321015432
                                    147054103023984104389087662943237645890321015676325677896761
                                    058943212110873201243179879850198732765430234588714986234890
                                    167687601101164012652234568766784321887342101899603215105659
                                    678996511231054873701221978955693870996456701234514504378778
                                    982123490543123964823400876554212987345980896785603673069867
                                    765010587650123455916512345443403456287671015498512982154956
                                    876523018567656996507845678932212310196542564321027854323241
                                    985452109898743887765930987821054321203433473452567761018130
                                    784343216789212701894321076543065010012128982867658956789021
                                    891238345323105611256232565332170321234089801998943441034330
                                    760189653410134320347183423469981236985178767870832332125545
                                    654308754589823412398094012578876547876589454561221089076556
                                    569210345676210503480189017665014566981074305432012670988987
                                    778123216784345676503276328984323475212565213456587521267981
                                    898014505891256985214965410810012984303456432347895430345670
                                    785210676540787694345898325723678778984234541056498741234321
                                    654321987034896001256763676554569560128105650110345657876434
                                    321039654126789123347854985438765430439876763431233054965235
                                    490318743256770104098923821129654321540569892343212123452196
                                    581401232149863265121012530034341013691456701456504567861087
                                    672310345038054396432343448101231012782347650987623438932387
                                    965498786521178987503453559874342103452878943298510129873498
                                    878945697810265089612354567565213478501987801123456018784567
                                    969034398924354108743543658106904569612016772010567105695436
                                    450123454589443298874632109237876548743125983400198234306721
                                    343210545476554581965549434312361039654334876510256543217810
                                    012654556321055670123678323403456128761242108981347789878934
                                    101763217898765432252101410589567545650543567432098236712125
                                    249890106789854501343234521673498432787694656548123145601016
                                    432187678768763312854145636762876501098781067439054006432567
                                    243014569659643210965098745891985411239872358928765419647898
                                    156103012346501349876787876740694320540965443210474328756787
                                    067612101236432358565678945056543217601453456754389845643896
                                    198787656345678967632365432127680108912322589863265434512387
                                    234594565676589874541050121218998012301011267770172123001989
                                    109683410789490163698210930300107321694120178089085012123476
                                    658762125610301252784327845451256430783243569172196781018565
                                    567891034521212341075456786965344567654652410234505492109410
                                    656900347234301056789845697874498698676701322343012343478326
                                    543211298165692345698926543289567789589887011452321034567567
                                    432104347076780434767810432101125654434996320961478933003498
                                    218765456987101229896321101911036763221745467870567122112567
                                    309894365896234310785410110876545894100876786987651033678985
                                    456789223345985401656789212567030345210965495698776544543234
                                    787650110276576564565094303498121236321234324308989434350198
                                    896343023183465433004185478767870387123456710217375621060167
                                    125432134092174332113276769365968791001249854567434789871256
                                    034334547894089211223498853478959601098345983098723348964343
                                    301227656323456200124567942562344512367896572129810254328321
                                    212018965214387103438901231001123201456087561234722167219450
                                    323127656103898234567872102121010126545123450165621098308761
                                    """;
    [Test]
    public void SolveStep1()
    {
        var t = TopoMap.FromString(TopoMap4);
        var count = t.CalcTrailCount();
        TestContext.Out.WriteLine($"{count.Sum()}");
    }

    private const string TopoMap21 = """
                                     .....0.
                                     ..4321.
                                     ..5..2.
                                     ..6543.
                                     ..7..4.
                                     ..8765.
                                     ..9....
                                     """;
    [Test]
    public void Step2Test1()
    {
        var t = TopoMap.FromString(TopoMap21);
        var count = t.CalcTrailRatings();
        Assert.That(count, Has.Length.EqualTo(1));
        Assert.That(count[0], Is.EqualTo(3));
    }

    private const string TopoMap22 = """
                                     ..90..9
                                     ...1.98
                                     ...2..7
                                     6543456
                                     765.987
                                     876....
                                     987....
                                     """;
    [Test]
    public void Step2Test2()
    {
        var t = TopoMap.FromString(TopoMap22);
        var count = t.CalcTrailRatings();
        Assert.That(count, Has.Length.EqualTo(1));
        Assert.That(count[0], Is.EqualTo(13));
    }
    
    private const string TopoMap23 = """
                                     012345
                                     123456
                                     234567
                                     345678
                                     4.6789
                                     56789.
                                     """;
    [Test]
    public void Step2Test3()
    {
        var t = TopoMap.FromString(TopoMap23);
        var count = t.CalcTrailRatings();
        Assert.That(count, Has.Length.EqualTo(1));
        Assert.That(count[0], Is.EqualTo(227));
    }
    
    [Test]
    public void Step2Test4()
    {
        var t = TopoMap.FromString(TopoMap3);
        var count = t.CalcTrailRatings();
        Assert.That(count.Length, Is.EqualTo(9));
        Assert.That(count[0], Is.EqualTo(20));
        Assert.That(count[1], Is.EqualTo(24));
        Assert.That(count[2], Is.EqualTo(10));
        Assert.That(count[3], Is.EqualTo(4));
        Assert.That(count[4], Is.EqualTo(1));
        Assert.That(count[5], Is.EqualTo(4));
        Assert.That(count[6], Is.EqualTo(5));
        Assert.That(count[7], Is.EqualTo(8));
        Assert.That(count[8], Is.EqualTo(5));
        Assert.That(count.Sum(), Is.EqualTo(81));
    }
    
    [Test]
    public void SolveStep2()
    {
        var t = TopoMap.FromString(TopoMap4);
        var count = t.CalcTrailRatings();
        TestContext.Out.WriteLine($"{count.Sum()}");
    }

}