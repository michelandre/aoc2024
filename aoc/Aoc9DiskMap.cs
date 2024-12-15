﻿namespace aoc;

public class Aoc9DiskMapTest
{
    
    [Test]
    [TestCase("12345", "0..111....22222")]
    [TestCase("2333133121414131402", "00...111...2...333.44.5555.6666.777.888899")]
    public void DiskMap(string map, string blockStr)
    {
        var d = Disk.FromDiskMap(map);
        Assert.That(d.BlockCount, Is.EqualTo(blockStr.Length));
        Assert.That(d.ToString(), Is.EqualTo(blockStr));
    }
    
    [Test]
    [TestCase("12345", "022111222......")]
    [TestCase("2333133121414131402", "0099811188827773336446555566..............")]
    public void Compact(string map, string blockStr)
    {
        var d = Disk.FromDiskMap(map);
        d.Compact();
        Assert.That(d.ToString(), Is.EqualTo(blockStr));
    }
    
    [Test]
    [TestCase("2333133121414131402", 1928)]
    public void Checksum(string map, int checkSum)
    {
        var d = Disk.FromDiskMap(map);
        d.Compact();
        Assert.That(d.Checksum, Is.EqualTo(checkSum));
        TestContext.Out.WriteLine("Test");
    }

    private const string _input =
        "9784655050729485573117742146782326749053498466885232318469815561847691115579219126424913618270688347973152818919128645713775717082567712712848206277773411336387458133442690406171708766702781215622546518863514373138206156266459929759732354709137917859531572434442251941721151753261263740418547176124631533465840804657649393764239176927184438613825617433778748813456926439928247389618479323898636344088664539763748733958654445415242939032759580923440119731367886661968236250262735552514709512552555273754366753928243232762421110232558278691291442121118652318453346214652688445696133387371489966146418212765791868544591392213105225302526778350729645461128996651828460419683639312752592757746968768757830787881126374344684724250155922529623341230642726334591888995854356632194624484538814507984265129949948387759982676983132234440706674822224476375586625477833101551201786573727923385961314281440671916288935192720687945952128909477983015677351184115226818181711561749573127619168722458646618234337665066499585965578981596324673596021257473652852724921361719227267892037264134282741541668468155538929604483656341784726358113872494958565693916358743949354916242262214765612414944675741447216221615933714282628763118257849454283624696548910966430572966587368521311711390676798374737377244874693295616835088723595661090737367998828949088608845311381772846598817725057605011752575536425579146534379815367406650183629455185752024947637916386588478616670857963505596351524351874458758283887601293299945304570824584665682478535644415742872919850396698274649367920387477725239673060299510517564969785122513531731291174822999179694463720189626886854716536735315967992296712624398882177658491153751108562126883799966679713337331491564924235826329562926813371652940435538225630736749521351319150295445739958394023674472138883429390895015255254773890432978578012417258353758813361561936759072709335657495166152243659387253678159291852611129609945494639884896463434422563757638283562459127432775159634859875318960528775763352336043406382483444559162314115276561289198483036973180435573329143645980564536451119247485533910854219348632363081773351593613601533236770363481171664683891704941937626564850576016785837635839491645427897951638644275945839361755494282412921428891797759287943605021531695159238757060298448576254657610349090703881919190765041174390356443414162197378898856705455939526977276399339378750569437975535181819176865637752621932779928127728875688398099649383204938707491767582912717849736404511453119812290409619408556292547293763698457984082903910863328968088435139551650154089683832121939943092544911712216578695989661215681718538301786671452153995571118265490547887495188143882693366266686673220389925426840937594345291196528524352227999422930636699319557826230556135246130767197845370707633386376219783126732736789522730816160527211613776287586346558137314127561368584987783987437262058997345542860984874574331377454937686819199553437993650522699771788952666774162668346245565427494636129591097567476577390237931698153142679465864213320724193583898765510547334101030237187395581343370863518519841693746366978539317815127927759928677247175157431886277886122929360974198498959818655575990964080201272315990258429312529522297603711116952512029753886655637944727418185165839731431756056496663218344513259534743132464627077527910249864633271572823105059792126555326874917786098494134298693989077153512216830275546442162225872764266549541801069932665476934288338221283944925301316726472783664765236776343562728359265308419722072405986618398961092286417698022726880618110558393542656274073534019543473767862856688632413602165164628811755804558736933836673646253466446885420114178281582512820661034686757849284273093694670735179712122767656616495632228215370944967539049777213859148758966664687616193867334598899101985522934134374424999675533694973926965172792183484318015303651462282422547118093233412444572898549513896359872936834349876884457899661277817805084373157856563333710228795388098531925274142287344465120584643201210581618403898237382815116634035299082251180738280104495943917986170296684749786537666241077532175883395536181503229644478522634723523233991991850402237584121222512365580717117257427117274274362561093236499708535122054921999527678784171465986595567457566401653927688785056178285831894495897282795831220192314331093169960361620873476382569891421438096361189284344138320855460637766646661894219906061713374706345728764557936645432245184851750732227979119223349259441596713272416318334858282274191615191298626702851288525701830243665155990287376118512468927467752111067365489941733345027701355897276993459896352274931784220175154555176448847949390947714756767414923522231171390245122481956835015217458968727802972302390891399396618885657433143392753675449694181189838126961532691811190996164257115941046104210107210695014298075889953858928595534596319752159861627512611812455165584522326796046243510648491463744894797799266598176244199757746481626827636625834741562576614426795447999534837593019575667259139945617119679794712911659431735147664611533482070465220233029897672735590357351655281587751256989317445784913377284595523215414629185225896806331935795223077252818941090176260987046959385396894342725896473323345695925153160787337714260314589779774402884428310997849669577898855535823855080763750877049424620879121744078479067861425448735514849662768727417499015811215971136222139152930738773597779319374585914306472576271628347491199698964855541596696233394623555676656462246434599165582277133585773328141121963509473849131277543716863178088858127725096726492901371422081513031497541597485536066996826404828954191115863113537786761377330973313776057281627708159546952649362571152816732372336888233814489938136317332761779154987913046469637271782753215169681354058506015402466216818577033386448766196195965179574886798699521954883492179366445845828663811572133496731792249447718365376362970121226501725614439303426406192631058312610193093246776983122128413618459448714359916655749205945431516129995597956978566657880383678968634848240409357603192928529435171233121182828866037128437119565124479595257508890729384152946493726166094334749899580393637377712516889312046976039301891734999828272241929968919223971251660546872115082652241996410403597766322164337361527645770455897188713886231994649792445845915353874349886909647361630384817317286563151552852487485232189685612415226818752583854153661798015586944452088353745251694671070512460156613467554346634858547257172399287668095239324153510677560761044466313215659395453778175898358105060344513448216997541474787486041483688844138292653487729283725511625146922174844428561814683942144585024481499826227827475606116138512538410414756354775723364878538973586326026944259871913955441316915394721823334628851348066177589506710702394328090411096655520443528849988907775429571481615466776415225337966489788875847298237963448836338697120744838819836472535664145971696278247217010683820893048744220456664685187115856563879453897615812618640822571947039382091287393589427484599164578586739917316609549724132203338992798408843966352342719628919357112933778511511416137445311382362211677115667874439318123756829866485298496905645739486418090409061673362569231363623425930907364254087337649485371176145512213111516314932907081908110789675565714931581519785777880587627388263104330942547402023165751156516429266524056914611682148538929555493625313197835469186514381121119294837312377591367383295903034123632274492443078331995278756664415241478756737527242599931667334337572505210709424154169594635411699469651218425503668165431581640151670877036948543706544134956359562362155653685464573589645725756271387595959326716545435552257917630636388896010965910334757312863587137894265696313616939128291836427958446166869598475703486336213903252616251959724593891389118445796638816796762919010138169838711984135443145834398402484421913465164822373124699857916429733764829312914596567793992312432529950785932758017352522348766728683891713997361522059481384635638585125527794587774998095491154895187892031995070404859138491904192598911501383595075447818924416653946957057533017456621931215138092969730553152289074523536143860703461432057473689596387592940445771917631197739138772617421746226206216156330852239716246271349834311237799581755329113203492275220753153942870635745869324143390408364272045267547571561103244236331769637996458993052181356425081727771953995983838511716335284127599428772757588251270313758351619747691667710456779974677424870603388378931609939445634607423563866438179699580527618178156526019732063896841807867476759582870736936789171479015852039923185685899345292832639599853831277159267834322782364849416127188402440214715832221673525692879117325719237715041102267232465886715476668432417554592903169406392625961159422483265952215755879731350556956399159683229922763882865535027657191138719797615733688428754187388807141207239798229924141972415697849389875291270274424165670269152477453534985751463265564305227754830758566138463322378667014876116669215448469202730774164382278916582783941173188556741709586279726567372505872454082446616746081713772508379797542239694828855648465287570942559406568435481566638487765838712389520364420484930546031396753485094169612443151868533856997387766151244588876196230223254479648458727792198501569649464649214606468849537725117596078842261518185359255346617747410588749959244532445726677371798396399888763133941644199878350109096527422412383953739505177727341722497453643787682175789252064223171694829397292872437703935881564601144215044487628182532843075128854514657793356613174522017473551925733216541485851643865472975864014392410292511291019446768628076662242944958169635255221314354245470978846624057652795104042521522783498864260506360515565333287339579822755355919124271654434628434758932195665573546834360952646835624469916118560933059677837568645327475211850622491784770186259115997874683419432141745619361642177904797618573837040688330464019539392482897205755261160506975749558393790482257937733871951135912404175418818916326254939396095766494237968533542421242156233586532842694871335483810362372606394899561353829495539953399484142176724511438345490288041962749475789545032285463378535336432488627809638766537137166305141746590346949247968844345861419984594468862982855757121474944543257307338321997823590208468354243308567538912662616839253782028816363382338117649434972866995436422724291363944134863614453231712488654267211262032603159557682276960657293887930582161252875517244158764781315246878338773592966421317535733461758584830113712329074688950679413414073336469603234645337725041386550561683385843689681999094177854849366349087323053726120666596599853246384156126843790533510253798859749504276766559467863164045525972716422689824637147946915963075197299841711936977765970718459868220627813867972203816893915768085198580957871293392443992542592594379203812487975813416397249101328156593155682599439852515505585604057315490781867406971634133772872611481978462349727996996944939795233292315164972226864936794784759832495151849734565719086266125209925841820778365625060327166965349386124434696225748422358449938756513346545214488512974757289589492598813396199957093433042821515754795548916867249117036205689633164444650132714423465327445161568436448707736128567488521337637779679411399574270734089113752648213579998619541948113167437626417842164588738177051959259391720952233942311156996315525355930947177432897574452471379824729975259815974834085234540217168823342287024823682351288714880112232274387271299371870462131871419714929129540681297207851125062276575683358747186619191224291886629696465677517647237795540993793631968729179839113962846704236238651518297472821803958599219951543969813461023147614905192697157705582941657922196363310343177597514903827883631324836985828914641936226522525983674648350613065696718934622362511851921308078126348949314358925488939597542455892136716983750595662859370849916225321855971203727439345603072897679239451555360426334924413223586783389764381281780635859546084542579604493848449293527146671837729927590635144182323372589473274786019329844391562224714926936555767546183937283233185539946266176796299574747299925953595985598363582821539197139322629813346317713344999465170309874108961689948545385891594436287176419216287123250421128326677886894632429563886403990362350222279883335415497383714262396883799491550729294124886687828271026349832836928787872675579159942494058706553241590276919594393883343691185659878936751508247515949311521216192319456209637392493113437381510497431116532618628747172827571345315914773553913748299627397439434354439294018559028516493769193357864603311199739467430132593411349888830357410583320548656926430341881584823339367528377684792826916968287422728736244156763255569613447418418237071243049555246825391425099176743862522981617659568805874213080831238701026765479583659879626121854242556772393568420861195403444595185308514815592186982864716544375493250479650309527454883553051582439555759985186736748194889677688987655675589811762732891845861562868112424575130105783996938405512553472466053325383168231991070479099875622262647713939124095832825689564373157541391175183727090706815928868789479373246966014448288776950991444424443114912573928538044682576487278806059684410242418546993378262253017505869859964123713796158746868614981653885273223661794149176216818802973564458644739232510695411425610487493432878616529349269118557636552398322676236388721963286336431243086397690923481458315634096832382984953326685726546608880877147188555353331296439631998181099288868661837541184196057554493517771434835389648189729378965651598856211579384992317677616304195909331964745758227209078302512387619441414514862675445976996228363919859406114741634502259338543262593662072321240229727231383182839715472898576953889636810544081359759474813473714171156105686251569908832219113802945781611228542858046464932454195768917196553933470832415211920572883712388678922796964388657497876214023347112539072684897911761834642211719326183466285326981469447377485152226182017824349339737353993918055633124963064227555845460199761406977123146995789309029577717279987252964315932592138517146657730107750133750218055149898646199452578234481609689298577901213668965576221408510606093636972951253542077184326983489373344176690727951468548191474102410869210519197923239114191457279299933457299987077694941527478557756553348137456933636696728833181115688486949107354316870956623636454854278911311452285141054339012692024758514799983163296454647813130969679415164345169644145858282353074838956611755327452944699551089893258113612988469719121653566278171901094716814644280763610803697673164261472542897788253675021293270605550586769822787138046183945864323124362892648827982879824563815712987677751613887423698286083173692677840996231647253356540233214433881879189974188624165959151581817882610563897919454546412102766943296483683629828105534291160593614338543561692916135331248582168709799121546129489748280905746256479885076308555686457179572658128447430555335835477456545372287959573948951684153808880636451299366996844957558523744771118691953253910786812398631894155306913347855163174742944482772729389978734761010236046514639564122269967333462914129853165641979275698649851614332991130453023811727879156223658752020665810494510477873791473787290608066743995807356866857522684648820247369156012786989542417739686474943567143786376117916894639403481479627302379528615398056583366684624521135708868191146916229433263965883319466654713229181882722835720493983342051945626222267375541607998613992129289407878237920554395456544774352484469861219571588439847606392634260663082567754861363536163702581752169107217694844877898771210446086347512468598773971627786235036715125314626616386991745244042803756905918739197208347641783101018844738866160465546442611406516426359185566364049868362241896431014491577498543498047433741762886288883363056875876702214128662781984638913653048713061565332335185653520295544269849903233796226549784821593507099168852461278368136182278111198299470199540195717947366497253589483315638819067837220577544578946775211206188413427959489767457632899447734412328752541833859166450105313174326827471184243485941852861533761488732271254269437141517355578934934289126171444901291959689489598165847352879492898304462409724139014275321971222828516742253257443182249699250994173358940647823498968274092665553967345977814624075897591493037449684515056768886471717847424848335112638196444945177688092253072527198934196328243985290775380356291549427147590183564142955122722461567123412206229404553221437515120116891462821445390816352671421938632661252136911233055171670779562821534157965107854242953547461353715261115167490837753374498594285585314203617934880875358914290771838762087121078123787623050713429413964487917235391294327247127477463395258628545787158965568356012436575959492104122475464204222699631804284585839306719705025856926639736754876747251842845202528701528633325205765254464986963403940737850429855926154188164605937655797142841287863535918437162552078139043443093541628557342191067351195726128686541284995932490919462711276698057747271856151455442842341337955493694454896905875703539176687825819455551373236552521517852246286149949614388562880447773832448426051192050797379863590707932191959331819594428188637588889354671407560133394439548918249871420865471249043904284404415259968277926822075888153761749688431149024791267898541855264279766587569993067199147239965846852593562689754526439706015541729708254921519386618775211667864242670725820754334117277163286823557639656931344928359171648984895533964683638149837941199882343927472642298686412155878355419104581783472259761652269715966164931975957265988111736877064482129702126176585263995141520372943987943423961117012164237364065747168421872182599577361869920194053747615813555508448206476865383632512299898736260622653792880422580637169225821735129147998429698829013683423496876839383903939917780219254497520724511311768213418634929803850933666796270282621731980994570461130655181317375547378293891354752603230272828829489167729258945628191713468698270808423797227229031417369257649565329489291305131519916109982725926391048826557466418981566847518948056166092786764317844212556792297489787888391223898323042772351337481867995123730764958281464687380369478501682295488137370175519374363439450799124627930275484986052956419531038237384439518409267539279453548678812413822315187761387652636207249445654916061694854727964987065721083168988135564229095819894945533775042226597435870329746603036808844896246278130988478321910276982957113257887639827851782136591292376918838371582563326608533736330904249796791969987632070882674759117125946933297142890871389252035604524103688357419938941514875694043738988981797374060609848104616109331398984101194291560477987829443361060133252765237759352888196692469998239525875202961755933971943636635313790641512354211717351251616111566473087359329361979243671137618895378608076496614843365343979111210494674601574271328175631339162757649608287168532726278964773611880739181384667591372733458951718555165745941774960918982662923164662549162507643389751809042751241924144435726246136795219805431367953801512822340786224679193246176314686881316178572998821638540282339534036185282792545942981561424475952857074529523389637112790327890831616175113807082811027652987261675195143585051102495201783683453708468925614606175985639325359966150506152889632587077792660897942108614614329596189346040638053679514251932942150858568807490228672696876472836583320251167183179758931377538186389227219752960564070572024145879658274844430563976923160243881504621293382231018133428708770842674829220964154504729208813525212616247801527635789811317478740636033756498881783605285984840752574538725636810446928737940143415985518498050523349869086435188331580143150264388808498241993199255915123309593481676527772274293469634171076915019132968462643445646495542712755384749602050509916433645711454764286951075202392937010374163791";
    
    [Test]
    public void PuzzlePart1()
    {
        var d = Disk.FromDiskMap(_input);
        d.Compact();
        TestContext.Out.WriteLine(d.Checksum.ToString());
    }
    
    [Test]
    [TestCase("2333133121414131402", "00992111777.44.333....5555.6666.....8888..")]
    public void BlockCompact(string map, string blockStr)
    {
        var d = Disk.FromDiskMap(map);
        d.BlockCompact();
        Assert.That(d.ToString(), Is.EqualTo(blockStr));
    }

    [Test]
    [TestCase("2333133121414131402", 2858)]
    public void BlockCompactChecksum(string map, int checkSum)
    {
        var d = Disk.FromDiskMap(map);
        d.BlockCompact();
        Assert.That(d.Checksum, Is.EqualTo(checkSum));
        TestContext.Out.WriteLine("Test");
    }
    
    [Test]
    public void PuzzlePart2()
    {
        var d = Disk.FromDiskMap(_input);
        d.BlockCompact();
        TestContext.Out.WriteLine(d.Checksum.ToString());
    }

}