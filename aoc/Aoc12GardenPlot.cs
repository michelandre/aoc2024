using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace aoc;

[TestFixture]
public class Aoc12GardenPlot
{
    private const string Test1 = """
                                 AAAA
                                 BBCD
                                 BBCC
                                 EEEC
                                 """;

    [Test]
    public void SimpleInput1Test()
    {
        var gp = GardenPlot.FromString(Test1);
        Assert.That(gp.Price, Is.EqualTo(140));
    }

    [Test]
    public void SimpleInput1Test2()
    {
        var gp = GardenPlot.FromString(Test1);
        Assert.That(gp.DiscountedPrice, Is.EqualTo(80));
    }

    private const string Test2 = """
                                 OOOOO
                                 OXOXO
                                 OOOOO
                                 OXOXO
                                 OOOOO
                                 """;
    [Test]
    public void SimpleInput2Test()
    {
        var gp = GardenPlot.FromString(Test2);
        Assert.That(gp.Price, Is.EqualTo(772));
    }
    
    private const string Test3 = """
                                 RRRRIICCFF
                                 RRRRIICCCF
                                 VVRRRCCFFF
                                 VVRCCCJFFF
                                 VVVVCJJCFE
                                 VVIVCCJJEE
                                 VVIIICJJEE
                                 MIIIIIJJEE
                                 MIIISIJEEE
                                 MMMISSJEEE
                                 """;
    [Test]
    public void SimpleInput3Test()
    {
        var gp = GardenPlot.FromString(Test3);
        Assert.That(gp.Price, Is.EqualTo(1930));
    }
    
    [Test]
    public void SimpleInput3Test2()
    {
        var gp = GardenPlot.FromString(Test3);
        Assert.That(gp.DiscountedPrice, Is.EqualTo(1206));
    }

    private const string Test4 = """
                                 EEEEE
                                 EXXXX
                                 EEEEE
                                 EXXXX
                                 EEEEE
                                 """;
    [Test]
    public void SimpleInput4Test()
    {
        var gp = GardenPlot.FromString(Test4);
        Assert.That(gp.DiscountedPrice, Is.EqualTo(236));
    }

    private const string Test5 = """
                                 AAAAAA
                                 AAABBA
                                 AAABBA
                                 ABBAAA
                                 ABBAAA
                                 AAAAAA
                                 """;
    [Test]
    public void SimpleInput5Test()
    {
        var gp = GardenPlot.FromString(Test5);
        Assert.That(gp.DiscountedPrice, Is.EqualTo(368));
    }
    
    
    private const string Input1 = """
                                  YYYYYYYYRZIZYYYYYPGPPPPPGGGGGGGGGGGGGKKKKYYYYYYYYYYYFFFFFFFFFFFFFFSSSJOOOJJJJJJJYJJJJJCCCCCCCCCCCCCCFFFFKKKKKKKKKKKRRNNNNNDNNNNNNNNUUUSSSEEE
                                  YYYYYYYYYZZZYYYYYYGGGPPPGGPGGGGGGGGGKKKKKYYYYYYYYYYFFFFFFFFFFFFFFSSSPOOOOJJJJJJYYJJJJJJJJIICCCCCCCCCCKKKKKKKKKKKKKKKKNNNNNNNNNNNNNNUUUSSSSSE
                                  YYYYYYYYYYZZYYYYYYYGGPPPPPPPPPPVGGGKKKKKKYYYYYYYYYYYFFFFFFFFFFFSSSSSSOOOJJNJJJYYYJJJJJJJJIICCCCCCCCCCPKKKKKKKKKKKKKKKKNNNNNWNNNNNNNUUSSSSSSS
                                  YYYYYYYYYYZZYYFYYGGGGGGGPEEPEVVVVVVXKKKKKKYYYYYYYYYYFFFFFFFFFFFSSSSSSOOOONNJJJJYYJJJJJJJIIICCCCCCCCKKKKKKKKKKKKKKKKKKKKNNNWWNNNNNWNUUSSSSSSS
                                  YYYYYYYYYYYYYYYYGGGGGGGGPGEEEVVVVVVKKKKKKVYYYYYYWYFFFFFFSSSSSSSSSSSSSOOOUNNNNNJJJJJJJJJJIIIMMMCCCKKKKKKKKKKKKKKKKKKKKNNNWWWWWNNNNWNUUUSSSSSS
                                  YYYYYYYYYYYYYYYYGGGGGGGGGGVVVVVVVVVVKKKKKVYYYYYYYYYFFFFFSSSSSSSZSSSSSSOONNNNNNJNNJNNJJJQQIIMMMMCCCKKKKKKKKKKKKKKKKKKKYYNWWWWWWWWWWUUUUSSSSSS
                                  YYYYYYYYYYYYYYYGGGGGGGGVGGVVVVVVVVVVVVVKKBYYYYYFFFFFFFFSSSSSSSSSSSSSSSOOGNNNNNJNNNNNJJQQQQQMMMMCCCCCJKKKKKKKKKKKKKKKKYYYYWWWWWWWWWUUUUUSSSSS
                                  YXXXXXXYYYYYYYYGGGGGGGGVVVVVVVVEVVVVVVVKBBYYYYYFFFFFFFFFSSSSSSSSSSSSSSOOGNNNNNNNNNNNJBBQQQQMMMMMCCCJJJJKKKKKKKKKKKKKYYYYYYWWWWWWWUUUUUSSSSSS
                                  XXXXXXXXXYIIYYYGGGGGGGGVGVVUVVVEVVVVVVVBBBBBYYFFFFFFFFFFSSSSSSSSSSSYSSSOONNNNNNNNNNNJBBBQQQMMMMMCCCJJJJJKIKKKKKIIIIIIYYYYYWWWWWPPUUUUSSSISSS
                                  FXXXXXXIIIIIIYYGGGGGGGGGGGEUUUUEEVVVVVBBBBBBYFFFFFRRRFFSSTSSSSSSSSSYYYYOCNNNNNNNNNNBBBBBBBQMMMMMCCCJJJJJJIKIKKIIIIIIIIIIYYWWWWWPPPPUUUSIISSS
                                  FFFXXXIIIIIIGGGGGGGGGGGGGEEEUEEEEVVEERRRBBBBYYFFRFRRRRSSSSSSSSSSSSSSYYYYNNNNNNNNNNNBBBBBBQQQMMMMCCCRJJJJJIKIIKIIIIIIILIIIYWWWWVPPPPPPUUZZSSS
                                  FFFXXXWWWIIIIWWGGGGGGGGGGGEEEEEEEVEEEEEBBBBBBBFRRFFFRRVVSSYYSSSSSSSSYYYYYNNNNNNNNNNBBBBBBQQQMMMMCSCCSJSJJIIIIIIIIIIIIIIIIIBBWPPPPPPPPUZZZZSS
                                  FFFFFWWWWWWIWWWGWGGGGGGGGEEEEEEEEEEEEEEEBBBBBBBBRRRFRRRRYSYYSSSSSSYYYYYYTNNNHNNNNNNNBBBBQQQQMMMSSSSSSSSJJIIIIIIIIIIIIIIBBBBBBBBBPPPPPZZZZISS
                                  FFFFFWWWWWWWWWWWWWGGGGGGGEEEEEEEEEEEBBBBBBBBBBBBRRRFRRRYYYYSSSSYSYYYYYYYTNWNHNNNNNTTBBBQQQQQMMMSSSSSSSSSIIIIIIIIIIIIIIBBBBBBBBBPPPPPPPZZSSSS
                                  FFFFFWWWWWWWWWWWWWWGGGGGEEEEEEEEEEEEVVVBBVBBBBBBRRRRRRRYYYYYYYYYYYYYTTTTTTNNNNTTTTTTTBBBQQQQQMMSSSSSSSSSIIIIIIIIPIIBBBBBBBBBBBBPPPPPPPMZZZZT
                                  AAFFFFWWWWWWWWWWWJJJGNGGGEEEEEEEEEEEVVVVBVVBBBBBBRRRRRRYYYYYYYYYYYYTRTTTTTTTTTTTTTTTTTTBTQQQQQQQQSSSSSSSIIIIIIIPPNIBBBBBBBBBBBBBPPPBPPZZZZZZ
                                  AAFFFFAGWWWWWWWWWJJWWWGGGWEEEEEEEEEEVVVVVVMBBBRRRRRRRRYYYYYYYYYYYYYTTTTTTTTTTTTTTTTTTTTTTQQQQQQQSSSSSSSSIIIIIIIPPNBBBBBBBBBBBBBBBBBBBZZZZZZZ
                                  AAAAAAAGWWWWWWWWJJWFWWGGWWEEEEEEEEEEVVVVBVVBBBRRRRRRRRYYYYYYYYYYYYYTYYTTTTTTTTTTTTTTTTTTTTQQQQQQSSSSSSSSIIIIIIPPPPPBBBPBBBBBBBBBBBBBBZZZZZZZ
                                  AAAAAAAAAWWWWWWWJWWWWWWWWWWWEEEEEEEEEVVVVVVVBBRRRRRRRRYYYYYYYYYYYYYYYYTTTTTTTTTTTTTTTTTTTTTQQQQSSSSSSSSSIIIIIIPPPPPPPPPBWWBBBBBBBBBBKZZZZZZZ
                                  AAAAAAAAAAWWWWJJJWWWWWWWWWWWEEEEEEEEEVVVVVVVVVRRRRRRRRYWWYYYYYEYYYAYYYYTTTTTTTTTTTTTTTTTTTTQQQSSSSSSSSIIIIIIIIPPPPPPPPPBBWWWWBBBBBBBBZZZZZZZ
                                  AAAAAAAAAAWWWGJWWWWWWWWWWWWWEEEEEEEEEEEVVVVVVVRRRRRRRRWWWYYYYEEYAAAAAYTTTTTTTTTTTTTTTTTTTTTQTCCSSSSSSIIIIIISSSPPPPPPPPPBBWWWWBBBBBBBBKZKZZZK
                                  AAAAAAAARYWWWGJJGGWWWWWWWWWWWERRWWEEEGVVVVVVVVVRRRRRRRRWWWEEEEEEEAAAAAAAATTTTTTTTTTTTTTTTTTTTCCCSSSSSSIISSSSSSSPPPPPPPPBBWWWWBFWBBBBBKKKZZZK
                                  AAAAAAAAAYYYWGGGGGWWWWWWWWWWWWWWWWWYWVVVVFLKKVRRRRRRRRRWWFEEEEEEEAAAAAAATTRRRRRRRRTTTTTTTTTTTCCCSSSSSSSSSSSSSSSSPPPPPPPWWWWWWWWWWWBBBBKKKKKK
                                  AAAAAAAAYYYTGGGGGGGGWWWWWWWWWWWWWWWWWWJJLLLKKRRRRRRRRRWWWWWEEEEEEEEEEAAATTRRRRRRRRTTTTTTTTTTTTCCXSSSSSSSSSSSSSFFFPFFPSSSSSWWWWWWWBBBBBKKKKKK
                                  AAAAAAAYYTTTTTGGGGGGGWWJJWWWWWWWWWWWWJJJLLLLLLLLRRRRRWWWDWWWWEEEEAAAAAATTTRRRRRRRRTTTTTTTTQQQQXXXXRRSSSESSSSSSFFFFFFHFSWWWWWWWWBBBBBMMMKKKKK
                                  AAAAAASYYYYTTVGGGGGGWWWWJJJJYYWWWWWWWJJJLLLLLLLLLRRRRRDDDWWWWWWWWAAAAAAATTRRRRRRRRTTSTTTTTTQQQXXXXRRSSSEEESESSEEFFFFFFFWWWWWWWWBBBBBMKKKKJJJ
                                  JAAAASSYYYYYTVGGGGGGGWWWWJJYYYWWWJJJJJJLLLLLLLLLLLLLLDDDDWWWWWWAAAAAAAAAAARRRRRRRRFFSTTTTTTQXXXXXXXREEEEEEEEEEEEFFFFFFFFWWWWWWWWWHBKMKKKJJJJ
                                  JASSSSVVVVVVVVGGGGGWWWWWWJJGYGWWWNNUJJJLLLLLLLLLLLLLLLDDDDDWWWAAAAAAAAAAAARRRRRRRRFFFFPTTTTXXXXXXXXEEEEEEEEEEEEEJFFFFFFWWWWWWWWWZZBZZKKKJJJJ
                                  JJVVSSVVVVVVVGGGGGGWWWWYDJGGGGWWLNNUJJJLLLLLLLLLLLLDDDDDDDDDDWAAARRRRRRRAFRRRRRRRRFFFFPTTPPXXXXXXXXEEEEEEEEEEEEEFFFFFFFFFWWWWWWWWZZZZKZZJJJJ
                                  JJVVVVVVVVVVVVVVVVGWWYYYDDDGGGDLLNUUJJJLLLLLLLLLLLLDDDDDDDDDDWAAARRRRRRRRRRRRRRRRRFFFPPPPPPXXXXXXXEEEEEEEEEEEEEEFFFFFFFFFFFWWWWWZZZZZZZZJJJJ
                                  JJJVVVVVVIIIVVVVVVWWYYYDDDGGDDDDUUUUUUUUILLLLLLLLDDDDDDDDDDDDWWAARRRRRRRRRRRRRRRRRFPFPPPPXXXXXXXXXEEEEEEEEEEEEEEFFFFFFFFFFFWWWWWZZZZZZZLJJJJ
                                  JJJVVVVVIIIIVVVVVVVWYYYDDDDDEDDDDUUUUUULLLLLLLLLLDDDDDDDDDDWWWWWARRRRRRRRRRRRRRRRRFPPPPPPXXXXXXXXXXEEEEEEEEEEEEEFFFFFFFFFOFWWWZZZZZZZZZZZZJJ
                                  JJJVVVDDDIIVVVVVVVVDHDDDDDDDDDDFUIUUUUUULLLLLLLLLLDDDDDAIIDAWWWWARRRRRRRRRRRRRRRRRNNNNPPXXXXXXXXXXEEEEEEEEEEEEEEEEFFFFFFFFFFWWZZZZZZZZZZZVJJ
                                  JJJKKKDDDIIVVVVVVVDDDDDDDDDDFFFFUUUUUUUULLLLLLLLLLDDDDDAAIDAAAAKARRRRRRRRRRRRRRRRRNNPPPPXWXXXXXXXXXEEEEEEEEEEEGGGGFFFFFFFFFFWZZZZZZZZZZZZVZZ
                                  JJKKKDDDDDIVVVVVVVDDDDDDDDDDFFFUUUUEUUUUULLLLLLPLLDDDAAAAAIAAAAKMRRRRRRRRRAAAAANNNNNNNNXXXXXXXXXXXXXEEEEEEEEEFGGGGFFFFFFFFFFWZZZZZZZZZZZVVZZ
                                  KJKKKKKKDDDVVVVVVVDDDDDDDDDDFFFFFUUEEUUUUULLLPPPLQDDDAAAAAIAAAAKMRRRRRRRRRAAAAAANNNNNXXXXXXXXXXXXXXXXEEEEEESFFGGGGFFNNNNFRRRWZZZZZZZZZZZZVZZ
                                  KKKKKKKKDDDVRUSVVVDDDDDDDDDDFFFFFEEEEUUUUULLNNNNQQDDDPAAAAAAAAXMMRRRRRRRRRAAAAANNNNNNNXXXXXXXXXXXXXXNEEEEEEFFFGGGGNNNNNNNRRRRRZZZZZZZZZZZZZZ
                                  KKKKKKDDDDDDUUUVVVDDDDDDDDDDDFFFFEEEEUUNLLLLNNNNNQDDPPAAAAAAAAMMMRRRRRRRRRMMAAAANANNNNNXXXXXXXXXXNNNNNEEEEEFFFGGGGNNNNNNNNNNNNZZZZZZZZZZZZZZ
                                  YKKKKKKKDDDDUUUVVDDDDDDDDDDDDAFFFEEEEUNNNNNNNNNNNNRDPPAAAAAAAAHHMMMMMMMMMMMMAAAAAAMNNNNNXXXXXXNXNNJJJEEEEEEFFFGGGGNNNNNNNNNNNZZZZZZZZZZZZZZZ
                                  KKKKKKKDDDUUUUUUUUUDDQDDDMDDDAAAEEEEEUNFFNFFNNNNRRRRFPPAAAAAAHHHHHMMMMMMMMMMMMAAAAMNNNNXXXNNNNNXNNNJJJJPPJUJFFGGGGGGNNNNNNNNNZZZZZZZZZZZZZZZ
                                  KKKKKKKKKDDDDUUUUUUUQQDDDDDDDAAAAEEEEUFFFFFFNNNNFFFRFAAAAAAAAAHHHMMMMMMMMMMMMMMMMAMMNNNNNNNNNNNNNNNNJJJJJJUGGGGGGGGGNNNNNNNNNZZZZZZZZZEZZZZZ
                                  KKKKKKKKKDDDDUUUUUUUUUUDADDAAAAAEEEEENBFFFFFFFFFFFFFFAAAAAAAAHHHHHHMMMMMMZZMMMMMMMMNNNNNNNHHHHNNNNJNNJJJJUUGGGGNNGGGNNNNNNNSNNVVZZZZZEEEZZZZ
                                  KKKKKKKKKDUUUUUUUUUUUUUUAAAAAAAAEEEEEEBFFFFFFFFFFFFFFFAAAAAAAAHHHHHMMMMMMMZZZMMMMMMJHHHHHHHHHHNNNNJJNJJJJJUGGGGLLLLLLNNNNNNNNVVZZZZZEEEEEZZZ
                                  KKKKKKKKKKKUUUUUUUUUUUUUAAAAAAABBEEEEBBBFFFFFFFFFFFFFFAAAAAAAAHHHHHHHHMMMMMMMMMMMMJJHHHHHHHHHHNNNJJJUJJJJJJGGGGLLLLLLNNNNNNNNVVVVZZZEEEEEEZZ
                                  KKKKKKKKKKKUUUUUUUUUUUUUAAAAAAABBBBBBBBBBFFFFFFFFFFEFAALAAAAAAHHHHHHHHMMMMMMMMMMMMMJHHHHHHHHHBBNNJJJJJJJJJJGGGGLLLLLLNNNNNNNVVVVVVZZZEEEEEEE
                                  KKKEEEKKKKKUUEUUUUUUUUUHHHAAAAABBBBKBBBBBBBFFFFFFFFFFVALAKAAAHHHHHHHHHHHCCCMMMMMMMMJHHHHHHHHHBBNNJVJJJJJJJJGGGGLLLLLLVNVVVVVVVVVVZZZEEEEEEEE
                                  KEEEEEKEEEEUUEEUUUUUUUUHHHHAAAABBBBBBBBBBBBFFFFFFFFFFVVXXKXHHHHHCHCCHHHHHHCMMMMMMMMJHHHHHHHHHBBNNFVJJJJJJJJGGGGLLLLLLVVVVVVVVVVVZZEEEEEEEEEE
                                  KEEEEEEEEEEEEEEEUUUUUUHHHHHHAABBBBBBBBBBBBBFFFFFFFFFFFFXXXXXHHHHCCCCCHHHHCCCMMMMMMMMHHHHHHHHHBBNFFFFJJJJJJJLLLLLLLLLLVVVVVVVVVVVVZEEEEEEEEEE
                                  KEKKEEEEEEEEEEEBUBBBBUJJHHHAAABBOBBBBBBBBBBBFFFFFFFFFFSXXXXXHHHCCCCCICCHHHCCMCCMMMMMMMQJBBBBBBFFFFFFFJJJJJJLLLLLLLLLLVVVVVVVVVVVVVEEEEEEEEEE
                                  KKKKEEEEEEEEEEBBBBBBNIIIHHAAAABBBBBBBBBBBBBFFFFFFFFFFFFXXXXCCCCCCCCCCCCCHCCCCCMMMMMMMMCCCCBBBBBBFFFFFJJJJJJLLLLLLLLLLLLLVVVVVVVVEEEEEEEEEEEE
                                  KKKEEEEEEEEEEEBBBBZZIIIIIIIAAABBBBBBBBBBBBHHHWFOOFFFFXXXXXCCCCCCCCCCCCCCCCCCCCCCCMMMMMCCCCBCBBBFFFFFFJJJUJJLLLLLLLLLLLLLLLLLLVEEEEEEEEEEEEEK
                                  KKKEEEEEEEEEEEBFBBIIIIIIIIAAIAABBBBBBBBBBBHHHHHHOOOOFXXXXXXXYYCCCCCCCCCCCCCCCCCCCMMMMCCCCCCCCBCUFFFUUUUJUUJLLLLLLLLLLLLLLLLLLNEENNEEEEEEEEEI
                                  KKEEEEEEEEEEEBBBBBIZIIIIIIIIIAAABBBBBBQBBBBHHHHHHHOOFXXXXXXXXXCCCCCCCCCCCCQQQQQCCCMMCCCCCCCCCCCUUUUUUUUUUUJLLLLLPLLLLLLLLLLLLNNNNNEEEEEEIIEI
                                  EEEEEEEEEEOEEEBBBBBIIIIIIIIIAAAABBBBBQQQMMMHHHHHHHHHHXXXXXXXXCCCCCCCCCCCCCCQQQQQCMMCCCCCCCCCCCCCCUUUUUUUUUULLLLLPLLLLLLLLLLLLNNNNNNENEIIIIII
                                  HEEEEEEEEEOBEBBBBIIIIIIIIIIAAAAAAABBQQQQMMYHHHHHHHHHHHHXXXXXXCCCCCCCCCCCCUQQQQQQCCCCCCCCCCCCCCCCCUUUUUUUUUULLLLLPLLLLLLLLLLLLNNNNNNNNNIIIIII
                                  EEEEEEEEEEEBBBBBIIXIIIIIIIIIXXXAAAABQQQQMMMHHHHHHHHHUUHXXXXXXXCCCCCCCCCCIIIIIQQQCCCCCCCCCCCCCCCUUUUUUUUUUUULLLLLUUPLLLLLLLLLLNNNNNNNNIIIIIII
                                  VEEEEEEVBBBBBBBBIBIIIIIIIIINXXXXXAAAMMMMMJMHHHHHHHHHUUXXXXXXXXXCCCCCCCCCIIIIIQQQCCCCCCCCCCCCCMMMMMUUUUUUUUULLLLLUUTLLLLLLLLLLNNNNNNNNIIIIIII
                                  EEEEVEEVBBBBBBBBIBBIIIIIIIIXXXAXAAAAMMMMMMMTTHHHHHHHHXXXXXXXXCXCCCCCCWZZIIIIIIIIIIICCCCCCCCCCCMMMMMUUUUUUUULLLLLFUPPUUUVVNNNNNNNNNNNNIIIIIII
                                  VVVVVVVVBBBBBBBBBBBBIIIMIIIXXXAAAAAAMMMMMMMMMHHHHXXXHCXXAXXXXCCIIIIIIIIIIIIIIIIIIIICCCCCCCCCCCMMMMMUUUUUUFFFFFFFFUPUUUUUNNNNNNNNNNNNNNNIIIII
                                  VVLVVVVVBBBBBBBBBBBIIIIMMMXXXXXXAAAMMMMMMMMMHHHHXXXXCCXCCXXXCCCIIIIIIIIIIIIIIIIIIIICCCCCCMCCMMMMMMMMUUUUFFFFFFFFFUUUUUUUNNNNNNNNNNNNNLNIIIII
                                  VVVVVVBBBBBBBBBBBBBBBIIIXXXXXXXXAAAMMMMMMMDDDHHXXXXXCCCCCCCCCCCIIIIIIIIIIIIIIIIIIIICCCCMMMMMMMMMMMMMUPUUFFFFFFFFFUUUUUUCNNNNNNNNNNNNNLNIIIII
                                  VVVVVVBBBBBBPPBBBBBBBBIIXXXXXXXXXAMMMMMMMMMDDDXXXXXXCCCCCCCCCCCIIIIIIIIIIIIIIIIIIIICCCSMAMMMMMMMMMMMUPPUFFFFFFFFFUUUUUUNNNJJNJNNUNNLLLNIINNI
                                  VVVVIIRBBBPPPPPBBBBBBBIAXXXXXXXIAAAMMMMMMMDDDDXXXXXXXXCCCCCCCCFIIIIIIIIIIIIIIIIKCCCPCMMMMMMMMMMMMMMMPPPPPFFFFFFFFFFFUUUUAJJJYJNNUNLLLLLLLNNI
                                  VVVVIRRBBPPPPPPPPBPPPPPAXXXXXXXIIIINMXDDDDDDDDXXXXXXXXXXCCCFFFFIIIIIIIIIIFZZZKKCCKKCCKMMMMMMMMMMMMMMPPIPPFFFFFFFFAFAAAUAAJJJJJJJJLLLLLLLLNNN
                                  VIIIIIIFFPPPPPPPPPPPPPPPXXXXXXXXXIIIIXXDDDDDDDXXXXXXXXXXXCFFFFFIIIIIIIIIIFZZZKKKKKKKOOOMMJMMMMMMMEEMPPIPPPPFFFFFFAAAAAAAAJJJJJJJJLLLLLLLLNNN
                                  IIIIIIIFFPPPPPPPPPPPPPHHMMMMXXXXIIIXXXDDDDDDXXXXXXXXXXXXXFFFFFFIIIIIIIIIIFYYZZKKKKOOOOOOOJMMMMMMMMMMIIIIPFFFFFFFFFAAAAJJJJJJJJJJJLLLLLLNNNNN
                                  IIIIIIIIFPPPPPPPPPPPPPPHMMMXXXXXIXXXXXDDDDDDXXXXXXXXXXXXFFFFFFFIIIIIIIIIIYYYYKKKKOOOOOOOOOQMMMMMMMMMMIIIIIIFFFFFFFAAAJJVVVVVVVVVJLLLLLLNNNNN
                                  IIIIIIIIFPPPPPPPPPPPPMHHMMMMMXXXXXXXXXXCCDDDDXXXXXXXXXXXXFFFEFFIIIIIIIIIIFYYYYYYYOOYOOOOOOOMMMMMMMMMIIIIIIIFFFFFFFAAJDJVVVVVVVVVJJJLLLYLLNNN
                                  IIIIIIFIFPPPPPPPPPPPPMMMMMMMMXXXXXXXQQCCCCDDDDDXXXXXXXXXXXEEEEFFFFFFFFUFFFYYYYYZZOOOOOOOOOOMCMMMMMMMMIIIIFFFFFFFFAAAJDJVVVVVVVVVJLLLLLLLLNNN
                                  IIIVVVFFFPPPPPPPPPPPMMMMMMMMMMXAAXXXXXXJCCDDDDDXXXXXXDXXXXEEEFFFWWWWFFYYYYYYYYYZZZOOOOOOOOOZCMMMMEEEZZIIIIFFFFSSFBBJJJJVVVVVVVVVJLLLLLLLNNNN
                                  VVVVVVVVVTTTPPPPPPMMMMMMMMMMMAAAAXXXXXXJCCCCDDDDXXXXXDXXXEEEEKWWWKKWWWYYYYYYYYZZZZOOOOOOOOZZZZMZMEZZZZIIIIFSSSSSPPBBLJJVVVVVVVVVJJLLLLLNNNNN
                                  VVVVVVVVVTYTPPYPPMMMMMMMMMMMMMMAAXXXXACCCCCCCDDDDDDDDDEEEEEKKKWWKKKKWWYYYYYYYYYYYZZZOOZOOOZZZZMZZZZZZZVVISSSSSCCPPBPJJJVVVVVVVVVJJLLNNNNFNNN
                                  VVVVVVVVVYYTYYYYPPMMMMMMMMMMMMAAAAXXCCCCCCCCCDDDDDDDDDEEEEEKKKWWWKKKWWWWWYYOOYYYZZZZZZZZOOZZZZZZZZZZZJVVIIVSSCCCCPPPPPJVVVVVVVVVVVVLNNNNFNNN
                                  VVVVVVVVVYYYYYYPPMMMMMMMMMMMMMMMAAAAACCCCCCCDDDDDDDDDDDEEEEEEKKKKKKKKKWWOOEOOYYZZZZZQQQZZZZZZZZZZZZZZZGVVVVVSCCCCPPPPPJVVVVVVVVVVVVFNFFFFNFF
                                  VVVVVVVVVEYYYYYMMMMMEMMMMMVAVAAAAAAAAACUCCCCCDDDDDDDDDEEEEEEKKIKKKKKKWWOROOOOOZZZZZZZQQQZQQZZZZZZZZZFFVVVVVVVVCCCCPPPPPJJVVVVVVVVVVFFFFFFFFF
                                  VVVVVVVVVVYYYAYYMMMEEMMMMMVAVVVVVAAAAACUCCCCCDDDDDDDDDEEEEEEPZPPKKKKKKOOROYOZZZZZQQQQQQQQQQQQZZZZZZZZVVVVVVVVCCCCCCPPRVVVVVVVVVVVVVFFFFFFFFF
                                  VVVVVVVVVVVYYAAAMMMEEEMVVVVVVVVVVVVAAOUUCCCCCCDDDDDDDREEEEPPPZZPPKKKKKOOOOOZZZZZZZQQQQQQQQQQQZZZZZYZMMMVVVVVVVCCCCCCCRVVVVVVVVVVVVVFFFFFFFFF
                                  VVVVVVVIIIIPPPPAMAAEEEMEVVVVVVVVVVAAOOOOCCCCODDDDDDDDREEEEPPPPPPPPPKKZZOOOOOOOOOZZQQQQQQQQNQQZZZZZZMMMMMMVVVVVCCCCCRRRVVVVVVVVVVVVVFFFFFFFFF
                                  VVVVVVVIPPIPPPAAAAAEEEEEOEVVVVVVVVVAAOOLCOCCOODDDDDDDRRREEPPPPPPPPPZZZOOOOOOOOOOZZZQQQQQQQQQQQGGZGMMMMMMVVVLVCCCRRRRRRVVVVVVVVVVVVVFFFFFFFFF
                                  VVVVVVVPPPPPPPAAAAEEEEEEEEEVVVVVVVAAAOOOOOOOOOODDDDRRRRRPPPPPPPPPPPZZZZOOOOOOOOOZZZZQQQQQQQQIIGGGGGGMMMVVVVVULPCRRRRCCVVVVVCVVVVVVVFFFFFFFFH
                                  VVVVVVKPPPPPPAAAAAEAEEEEEEEVVVVVVVAAAAOOOOOOOOODDDRRRRRPPPPPPPPPPPPPPOOOOOOOOOOOOZZZQQQQQQQGGGGGGGGGGMMMMCZCCLLRRRLLXCVVVVVCVVVVVVVFFFFFFFHH
                                  VVVVYYPPPPPPPPPAAAAAEEEEEEEEVVVVVVAAAAOOOOOOOODDDRRRRRRRRPPPPPPPPPPZZZZOOOOOOOOAOZZQQQQQQQGGGGGGGGGGGMMMMCCCHLLLLLLLCCTCCCCFVVVVVVVFFFFFFFKK
                                  UUUVYYPYYPPPPPAAAAAAAEEEEEEEVVVVVVVAAOOOOOOOOOODDORRRRRRRPPPPPPPPPZZZZZOOOOOOOOOOQQQQQQQQQQGGGGGGGGGGGMCCCLHHLLLLLLLVCCCCXXFFFFFFFFFFFFFFKKK
                                  UUUYYYYYYPPPPPPAAAAEEEEEEEAAVVVVVVVAAOAOOOOOOOOOOORRRRRRRRPPPFFPPZZZZZZZZOOOOOOOOQQQQQQQQQQQGGGGGGGGGGHAACLLLLLLLLLLLLCICXXFFFSFFFFFKKKKKKKK
                                  UUUUYYYYPPPPPPAAAAAAEEECEAAAAAAVVVVVAAAOOOOOOOOOORRRRRRRURVPPFFFPFFZZZZZZZOOOOOCCQQQQQQQQQQGGGGGGGGGGGHALLLLLLLLLLLLIIIICXXXXFSSFKKKKKKKKKKK
                                  UUUUUYYYDPAPPAAAAAAAAEEEAAAAAAAVVVVVAAAOOOOOOORROORRRRRAOPVVVFFFFFFZZZZZZOOOOOQQQQQQQQQQQQQQQGGGGGGGAAHALLLLLLLLLLLLIXXXXXXXFFSSFKKKKKKKKKKK
                                  UUUUUUUUDDDAAAAAUAAAAEEAAAAAAAAVVVVAAAAPOOOORORROOOORRROOOVVFFFFNNFZZZZZZZOOOOOQQQQQQQQQQQQQQQAGGYAAAHHAALLLLLLLLLLLILIXXXXXFFFSFFKKKKKKKKKK
                                  UUDUUDUDDEAAAAAAUUAAAAAAAAAAAAAVVVAAAAPPPPORRRRRROOORRROJOVOFFFFFFFFZZZZZZOOOZQQQQQQQQQQQQQQQQQGGYAAAAHAALLLLLLLLLLLLLXXXXXXXXFFFFFKKKKKKKKK
                                  DDDDDDDDDEEAAAAUUUUUUUAAAAAAAAAAAVAAAAPWWPRRRRRRROOOOOOOOMMFFFFFFFFFFFFZZZZZZZZQQQQQQQQQQQQQQQUUUYAAAAAAAGGLLLLLLLLLLAAXXXXXXXXXLFFFKKMKKKKK
                                  DDDDDDDDDEEAEAAAUUUUUUUUUAAAAUAAAAAAAAARRRRRRRRRZOOOOOOOOMMMFFFFFFFFFFFZZZZZZZZQQQQQQQQQQQQQUUUYYYAYYAAAGGWGLLLLLLLLAAXXXXXXXXXXLLLFKKKKKKKK
                                  DDDDDDKKKKEEEAAAUUUUUYUUUUUAUUUUAAAAAAAARRRRRRZZZOOOOOOOOFFMFFFFFFFFFFFZZZZZZZQQQQQQQQQQQQQQQYYYYYYYYYAGGGGGGLLLLLLLAAXLXXXXXLLLLLEEEVVVVKKK
                                  DDDDDDDKKEEEEAAAUBUUUUUUUUUUUUUUUAAAOOORRRRRRRRZZKOOOOZZZFFFFFFFFFFFFFFZZZZZZZZZQQQQQHQFQQFQQYYYYYYYYYYGGGGGGGLLLLLLLAXLLXLXLLLLLLEEEEVVVKVK
                                  DDDDDDDDDEEEEEAAAUUUUUUUUUUUUUUUFAAAOORKRRRRRRRZKKKOOOZWWFFFFSFFFFFFFFFZZZZZZZVVVVZQFFQFFFFQFYYYYYYYYYYYYGGGGGGLGLAGMLLLLLLXLLLLLLEEEVVVKKKV
                                  DDDDDDDDDEEEEWAAAUUUUUUUUUUUUKUUOOOOOORRRRRRRRRZZKKOOOZWWWWWFSFFFFXFFFFZZZZZZZZVVVFFFFFFFXFFFFYYYYYYYYYGGGGGGGGLGIGGLLLLLLLLLLLLEEEEEEVVVVVV
                                  DDDDDDEEEEEEUWWUUUUUUUUUUUUUUKKKKOOOOORRRRRRRRRRKKKKKWWWWWWWWWEFFFBFBBFZZZZZZZZVVVSFFFFFFXFFFFYYYYYYYYYYYGGGGGGGGGGGGLLLLLLLLLLEEEEEEEEVVVVV
                                  DDEEEDDDEKEEWWWWFUUUUUUUUUUUUUKKOOOOOOPRRZZZZZZZKKKKKZZZZWWWWWEEFFBBBBZZZZZZZZCSSSSFFFFFFXXXFFFFYYYYYYYYYYGGGGGGGGGPPLLLLLLLLLLEEEEEEEEVVVVV
                                  DEEEEEEDDDDDIWWFFFWWWWUUUUUUUUKKOOOOOPPRRZZZZZZZZZZZZZZZZWWWWWBBFBBBBBBBZZZZZZCCCSSFSSSFFOXXXXXXXXXYYYYYYYGGGGGGGGGGPLLLLLHLLLLEEEEEEEEVVVVV
                                  DEEEEEEEDDDDWEWWWWWWWWKUUUUUWWWKOOOOOOPPRZZZZZZZZZZZZZZZZWWWTWBBBBBBBBBBZZSSZZZCSSSSSSSFFOXXXXXXXXXXYYYYYYYYYGGGGGTTTTLLLLLLLLLLEOEEEEVVVVVV
                                  DEEEEEEEDDDWWWWWWWWWWWKKUIWWWWKKOOPOPPPPXZZZZZZZZZZZZZZZZKWWWWBBBBBBBBBBZZZSSSSSSSSSSSSSXOXXXXXXXXXXYYYYYYYYYGGYTTTTTTTTLLLLLLLLLLEEEEVVVVVV
                                  EEEEEEEEEDTWWWWWWWWWWIIIIIIWWWWWPPPPPPXXXZZZZZZZZZZZZZZZZKKWBBBBBBBBBBBBZZZSWSWSSSSWWSSSXXXXXXXXXXXXXYYYYYYYYYYYTTTTTTTTTTOLLLLLLLEVVVVVVVVV
                                  IEEEEEEEVWWWWWWWWWWPWIIIIIIWIIPPPPPPPPPXXZZZZZZZZZZZZZZZZZKKBBBBBBBBBBBBBBBBWSWSSWWWWWWXXXXXXXXXXXXXXYYYYYYYYYYTTTTTTTTTTTTLLLLLLVVVVVVVVVVV
                                  IEEEEEEEEEELWWWPWWPPWIIIIIIIIIPPPPPPPXXXXZZZZZZZZZZZZZZZZZPPBTBBBBBBBBBBBBMMWWWWWWWWWWWWXXXXXXXXXZYYYYYYYWYYYYYTTXTTTTTKKTTLLLLLLVVVVVVVVVVV
                                  IIIIIEEEEEEEPWWPPPPPPAIIIIIIIIPPPPPPPXXXXZZZZZZZZZZZZZZZZZPPPBBXNBBBBBBBBBMMWMWWWWWWWQQQXXXXXXXXXZZYYYYYYWWYYYYTTTTTTTTTTTTTLLLLVVVVVZZZZZZV
                                  IIIIEEEEEECCCNWPPAPPAAIIIIIIIPPPGPGPGGXXXXXZZZZZZZZZZZZZZZPPPPBXXVBBBBBBBMMMMMMWWWWWWWWXXXXXXXXXXZYYYYYYWWWYWWYTTWTWWWWWWTTTLPPLLVVVZZZZZZZV
                                  IIIIEEEEECCCCNNAAAPAAAIIIIIIIPPPGGGGGGXXXXXHHHWWZZZZZZZZZZPPPXXXXXXZXBBMMMMQQMMWWWWWWWWHXXXXXHXHHYYYEYYYWWWYWWWWWWWWWWWKKKKLLPVVVVVVVZZZZZZZ
                                  IVVVVGGEECCCNNNAAAPAAAAAIIIIIPPGGGGGGGGGXXXHWWWWZZZZZZZZZZPPPXXXXXXXXAAAMMMQQQMWWWWWWWWHHHXXHHXHEEEEEYEYWWWWWWWWWWCWWWWKKKKWHVVVOOVVVZQZZZZZ
                                  IVVVVGGEJJJJANAAAAAAAAAAYIPPPPPPGGGGGGGKXXXHWWWWWWWKPKPPPPPPXXXXXXXXXAAAMMMQQQQWWWWWWWWHHHHHHHHHHEEEEEEWWWWWFWWWWCCCCCCKKKKWHVVOOOOOVOQQZZZZ
                                  VVVVVVVJJJJAAAAAAAAAAAAAAPPPRPPPGPGGGGGKKHHHHWWWWWWWPPPPPPXXXXXXXXXXAAAAAMQQXQQVVVWWWWHHHHHHHHHHHEEEEEEWEWWFFWWWWICCCCCKKKKHHNNOOOOOOOQZZZZZ
                                  VVVVVVJJJJJJAAAAAAAAAAAAAAPPRRRPPPGGGGGKKKKHWWWWWWWWPPPPPPPPPXXXXXXXAAARAARQQRVVVVWWHHHHHHHHHHHEEEEEEEEEEFFFFFWWCCCCCCCKKKKHHHOOOOOOOOZZZZZZ
                                  VVVVVVJJJLJJAAAAAAAAAAAAAAAPPRRGGGGGGGGKKKKKFWWWWWWPPPPPPOOPXXXXXXXAAARRRRRQRRVVVVWWHHHOOOOOOOEEEEEEEEEEEFFFFFWWCCCCCCHKKKKHHHHHOJOOOOOOZZZZ
                                  VVVVVVJJJLLJJAAAAAAAAAAAWTPPRRRRRRGTGKKKKKKKFWWWWWWPPPPPPOOOOOXPPPCCAAARRRRRRRVVVVLSHHSCCOOOOOEEEEEEEEEEFFFFFFFCCCCCCCHKKKKKKKHOOOOOOOOOZZZO
                                  VVVVVVJJJLMJJUAAAAAAAAAAWTPRRRRRRRRRKKKKKKKKKWWWWWPPPPPPPOOOOOPPPCCCAAARRRRRRVVVVVVSSSSOOOOOOOOOEEEEEEEEAAAFFFFCCCCCCCHKKKKKKKHVVOOOOOOOOZOO
                                  VVVVVVJJJLMMUUUUAAAAAAAAATTRRRRRRRRKKKKKHKKOKWWWWWPPPPPPPPOOOOWWJOOOORRRRRRRRGVRVSSSSSSOOOOOOOJEEEEEEEEJJAAAFFFCCCCHHHHKKKKKKKGGVOOOOOOOOZOO
                                  VVAVVMMMMMMMHUUUUUAAAAATATTTRRRRRRRRKKKKKKKRRRWWWIIPPPPPPOOAOOWWWOOOORRRRRRRRRRRSSVSSSSOEOOOOOOEEEEEEEJJJAAFFFFCFCCHHHHHGKKKKKGGOOOOOOOOOOOO
                                  VVAVVMMMMMMMMUUUUUUAAAATTTTTTRRRRRTTKKKKKRRRRTTTTUIPPPPPPPMOOWWWWAOOOOXXRXRRRRRSSSSSSSSOOOOOOOUUUEEEEEJJJAAAFFFFFIIHHHHHHKKKKKGOOOOOOOOOOOOO
                                  VVXXXMMMMMMMMUUUUUUUUTTTTTTTRRRRRRRRRRNKGRRRRXTUUUPPPPPPPUWWWWWWWWOOOXXXXXXXERRRSSSSSSSSSSOOOOOOEEHEEEJKKKKKKKKKKIHHHHHHHKKKKKGGGOOOOOOOOOOO
                                  XXXXXMMMMMMMMUUUUUUUTTTTTTTTTBBRRRQRRQKKGXRRRXTUUUUUPPPUUUWWWWWWWWOWOXXXXXXOERERSSSSSSSSSHOHHHHHHHHEEJJKKKKKKKKKKKKKKKKKKKKKKKLGGGGOOOOOOOOO
                                  XXXXXMMMMMMMMMOUUUTTTTTTTTBBBBBQQQQQRRGXGXXXXXXXXXUUPPPPUUTWWWWWWWWWXXXXXXXXEEEESSSSSSSHSHHHHHHHHHHHJJJKKKKKKKKKKKKKKKKKKKLSSLGGGGGGOOOOOOOO
                                  XEEXEEEEEMMMMMOUWUTTTTTTTTTZBBZQZZZQQQXXXXXXXXXXXXUUUUUUUUUWWWWWWWWWXXXXXXXEEEEESSSSSSSHHHHHHHHHHHHHJJIKKKKKKKKKKKKKKKKKKKLLLLGGGGGWOOOOOOOO
                                  EEEEEEEEEEKKMMOKKKJJTTTTTTTZZZZZZZZXXXXXXXXXXXXXXXUUUUUUUUUWWWWWWWWWXXXXXXXXEEEEEESSSSSHHHHHHHHHHHHHHJIKKKKKKKKKKIIIQQLLLLLLLLGGVVVOOVVVGGOO
                                  EEEEEEEEEEKKKKKKKKRJJTTTTTTZZZZQQZZZXKXXXDXXXXXXUUUUUEUUUNNNNWWWWWWWXXXWXXEEEEEEEESSSSSKQQQKKHHHHHHHHIIJIIIIIIIIIIIQQQLLLLLLLLLLVVVVOVVVVGGG
                                  EEEEEEEEEEEKKKKKKJJJJJTTTTTZZZZZZZZZZZXXXDDDXXDXUUUUUENEENNNNNWWWWWWXXXWEEEEEEEEESSSSSSKKKKKKHHHHFKNNIIIIIIIIIIIIQQQQQLLLLLLLLLVVVVVVVVGGGGG
                                  EEEEEEEEEEEEKKKJJJJJJJTTTTTTZZZZZZZZZXXDDDDDXDDXUUBUUEEEEENNNWWWWGWWWWWWOEEEEEEEEESSSSKKKKKKKKKKKKKNKKKIIIIIIIIIIIQQQQLLLLLLLLLVVVVVVVGGGGGG
                                  EEEMMEEEEEEEKKKJJJJJJJJTTTTBZZZZZZWZZZDDDDDDDDDDUUBBEEEEEENNNWWWIWWWWWWWWETTEEEEEESSSSSKKKKKKKKKKKKKKKKKIIIIIIIIIIQQQLLLLLLLVAAVVVVVVJJJJJJG
                                  EEMMMMMEEKKKKKKKJJJJJJJJTTTTZZZZZZWZGZDDDDDDDDDDDDBBEEEEEENNWWWWWWWWWWWWWETTEEEEEHSSSKKKKKKKKKKKKKKKKKKKIIIIIIIIIQQQQQQLLLVVVVVVVVVVVVAJJJJJ
                                  EEMMMMMEEKKKKKKKJJJJJJJZZZZZZZZZZWWGGZDDDDDDDDDDDDBBBEEBBBNNBIIWWWWWWWWWWTTTEXEEEETSSSBBBBKKKKKKKKKKKKKIIIILLLIIQQQQQQQQLVVVVVVVVVVVVVAAJJJP
                                  AAMMMMMKEKKKKKKJJJJJJJJZZZZZZZZZZWWWGDDDDDDDDDDDDDBBBBBBBBBBBIWWWWWWWWWJWTTTTEEETTTBBBBBBBKKKKKKKKKKKKKIBBLLLIIIIQQQQQQQQQVVVVVVVVVVVVAAJJJP
                                  AAAMMMMKKKKKKJKJJJJJJJJZZZZZZZZZZWWWWDDDDDDDDDDDDDDBBBBBBBBBBIWWWWWWWWWWWTTTTEETTTTTBBBBBBBBKKKKKKKKKKKBBBBLLLLLQQQQQQQQQVVVVVVVVVVVVVVAJJJJ
                                  AAAAAAMKKKKKJJKJJJJJJJJJZZZZZZZZZWWDDDDDDDDDDDDDDDBBBBBBBBBBBBJNWWWWWWWWWPTTTTTTTUTBBBBBBBBBBKKKKKKKKKKKBBBLLLLLQQQQQQTQQQQVVVVVVVVVVVAAAAJI
                                  AATTTATKKKKKKJJJJJJJJJJJJJFZZZZZZWWWDDDDDDDDDDDDDBBBBBBBBBBBBNNNWWWWWWWWWPTTTTTTTUUBBBBBBBBBBKKKKKKKKKKKKBBLLLLLQQQQQQTQQQQVVVVVVVVVVRRAARRR
                                  AATTTTTKTKKKJLJJJJJJJJJZZZZZZZZZZZZZDDDDDDDDDDDDBBBBBBBBBBBBBNNNWWNWWWWWPPPTTTTTTUUUABBBBBBBBBKBKKPPKKKKBBFLLLLLQQQQQQTTTTTYYVVVVVVVVRRRRRRR
                                  TTTTTTTTTTKKJLJJJJJJJJJJJZZZWWZZZZZZDGDDDDDDDDBBBBBBBBBBBBBBBNNNNNNWWNJWEPPTPUUUUUUUUBBBBBBBBBBBBBBPKKKFBFFLLLTQQQQQTQOTTTTTYVVVVVVVVRRRRRRR
                                  TTTTTTTTTTTJJJJJJJJJJJJJJWWZWWZZZZIIIIODDDDDDXSXBBBBBBBBBBBBBFNNNNNNNNNQPPPPPKURRRUUUBBBBBBBBBBBBBPPZKFFFFFLFTTQQQQQTTTTTTTTTTTTVVVVVVRRRRRR
                                  TTTTTTTTTTTJJJJJRJJJJJJWWWWWWZZZZIIIIIDDDDDMMXXXBBBBBBBBBBNNNFNNNNNNNNNQQPPPPCRRRUUUBBBBBBBBBBBBBBBZZKFFFFFFFTQQQQTTTTTTTTTTTTTVVVVVVVVRRRRV
                                  ETTTTTTTVTTJJWJJJJJJJWWWWWWWWZZZPIIIIIIDDDMMMMXXXXXBBBBBBBNNNNNNNNNNNNNNQPPPCCRRRRUUBBBBBBYBBBBBBZZZZZZFFFFFFFQQQEETTTTTTTTTTTTVVVVVVVVRRVVV
                                  ETTTTTTTVVVVWWWJWWWJWWWWWWWWZZZZZIIIPIMMMDMMMXXXXXXXXBTBTNNNNNNNNNNNNNNNNPPPCCRCRCFFBBBBBBBBBTTTBZZZZZFFFFFFFGGQQETTTTTTTTTVTTPVVVVVVVVVVVVV
                                  ETTTTTTTTVWWWWWWWWWWWWWWWWWWWWZZZWWWWWMMMMMMXXXXXXXXXTTTTTNNNNNNNNNNNNNNPPPPCCCCCCCBBBBBBTBBBTTTTTTZZZZFFFFFFGGGQQGTTTTTTBVVPPPPVVVVVVVVVVVV
                                  EEETTTTTVVWXWWWWWWWWWWWWWWWWWZZZZWWWWMMMMMMMXXXXXXXXXXTTTTTTNNNNNNNNNNNNPPPPCCCCCCCBBBBTTTTTTTTTTTTZZZTTMTTFFGGGGGGTTBTTBBVVPVPPVVVVVVVVVVVV
                                  EEETTTTMWWWWWWWWWWWWWWWWWWWWWWZZWWWWMMMMMMMMMMXXXXXXTTTTTTTTNNNNNNNNNNNNNAPPCCCCCCCCCXXTTTTTTTTTTTTZTTTTTTTGGGGGGGGGGTTTBVVVVVVVVVVVVVVVVVVV
                                  EEETTTMMWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWMMMMMMXXXXXXXXXXXTTTTTTNNNNNNNNNNNNAPPCACXXXXXXXXTTTTTTTTTTTTTTTTTTTTGGGGGGGGGGGGTBVVVVVVVVVVVVVVVVVVV
                                  """;
    [Test]
    public void Solution1()
    {
        var gp = GardenPlot.FromString(Input1);
        TestContext.Out.WriteLine(gp.Price);
    }
    
    [Test]
    public void Solution2()
    {
        var gp = GardenPlot.FromString(Input1);
        TestContext.Out.WriteLine(gp.DiscountedPrice);
    }

    
}