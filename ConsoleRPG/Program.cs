using System;
using System.Media;
using System.Threading;

namespace rogueLike
{
    class Program
    {

        public void imagePainter()
        {
            Map map = new Map();
            Player player = new Player(map.mapArray);




        }
        public static Program instance = new Program();

        static void Main(string[] args)
        {

            new GameManager();

            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int equipmentInteger = 0;

            bool singlePlayer = false;
        //    bool multiPlayer = false;
          //  bool manual = false;
            bool musicOn = true;
            SoundPlayer musicPlayer = new SoundPlayer();

        //    int race = 0;        //human, elf, troll and goblin
        //    int classs = 0;      //attacker, assassin, sorcerer and defender   

            int str = 0;
            int con = 0;
            int dex = 0;
            int intel = 0;
            int speed = 120;







            //display the menu
            if (singlePlayer == false)
            {
                Console.SetWindowSize(175, 50);

                //print a titlescreen!!   like "primal rogue"
                Console.WriteLine("                                                                                                         ");

                if (musicOn)
                {
                    // play audio  for background
                    // musicPlayer.Stream = new MemoryStream(Properties.Resources.gameMusic);

                 //   musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/soundtrack_intro.wav";
               ////     musicPlayer.Play();
                }

              




                //Console.Beep();     //makes a beep sound
                Console.WriteLine("                                                                                                         ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine("      ████████      ████████       ███████         ████████       ██████        █████████               ");
                Console.WriteLine("      ██            ██    ██       ██    ██        ██            ██                 ██                  ");
                Console.WriteLine("      ██            ██    ██       ██    ██        ██             █████             ██                  ");
                Console.WriteLine("      █████         ██    ██       ███████         ████████           ██            ██                  ");
                Console.WriteLine("      ██            ██    ██       ██    ██        ██           ██    ██            ██                  ");
                Console.WriteLine("      ██            ████████       ██     ██       ████████      █████              ██                  ");
                Console.WriteLine("                                                                                                        ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("      OF THE ENCHANTED SHRINES                                                                                                   ");
                Console.WriteLine("                                                                                                         ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("                                                                                                         ");
                Console.WriteLine("      PRESS ANY KEY                                                                                                                   ");
                Console.WriteLine("                                                                                                         ");


                int[] permutation = { 151,160,137,91,90,15,                 // Hash lookup table as defined by Ken Perlin.  This is a randomly
    131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,    // arranged array of all numbers from 0-255 inclusive.
    190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
    88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
    77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
    102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
    135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
    5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
    223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
    129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
    251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
    49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
    138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
};
                Random seed = new Random();
                int factor = seed.Next(13, 155);
                string tile = "▲";
                //let us create a braneworld
                Map map = new Map();
                Player player = new Player(map.mapArray);
                map.braneGenerator(permutation[factor], tile);



                Console.ReadKey();
                Console.Clear();









                Console.WriteLine("Forest of the enchanted shrines");





                //singlePlayer = true;

                //create player character
                Console.Clear();
                Console.WriteLine("select your race");

                Console.WriteLine("┌────────────────────────┐               ┌────────────────────────┐");
                Console.WriteLine("│human [1]               │               │juggernaut [6]          │");
                Console.WriteLine("└────────────────────────┘               └────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────┐");
                Console.WriteLine("│nightelf [2]            │");
                Console.WriteLine("└────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────┐");
                Console.WriteLine("│troll [3]               │");
                Console.WriteLine("└────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────┐");
                Console.WriteLine("│goblin [4]              │");
                Console.WriteLine("└────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────┐");
                Console.WriteLine("│ork [5]                 │");
                Console.WriteLine("└────────────────────────┘");
                Console.WriteLine("                   ");


                Thread.Sleep(200);


                //verpack es in methoden

                // speicher das: Console.ReadKey(true).Key in variabel

                //dann prüfe welche option ausgewählt wurde.. verwende methoden!

                var keyReader = Console.ReadKey(true).Key;

                //human character   multiplayer EQ: discus  @○
                //humans are exceptional at being reapers and sorcerers
                if (keyReader == ConsoleKey.D1)
                {
                    Console.Clear();

                    str = 5;
                    con = 4;
                    dex = 5;
                    intel = 6;

                    speed = 100;
                    Console.WriteLine("        ");
                    player.race = 0;
                    Console.WriteLine("you selected a clever human character");
                    Console.WriteLine("STR " + str);
                    Console.WriteLine("CON " + con);
                    Console.WriteLine("DEX " + dex);
                    Console.WriteLine("INT " + intel);
                    Console.WriteLine("        ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&@@&");
                    Console.WriteLine("&&&&&&&&&&&&&%&&&&%%%%%%%&&%%&&&&&&&&&&&&&&&&&&&&");
                    Console.WriteLine("&&&&&&&&&&&&&%&%&&%%%%%%%&&&&&&&&&%&%%%%&%&&&&&&&");
                    Console.WriteLine("&&&&&&&&&%%&&&&,,&&&%%&&%&./,*// &&&&%%%%%&&&&&&&");
                    Console.WriteLine("&&&&&&&%%%%%%&&. .&&&&&&.,*///./,/ &%&%%%%%%&%&&&");
                    Console.WriteLine("&&&%&&%%%%%&%%&&%# &&&.**/%**.,.,/.&&%%%%%%%%&&&&");
                    Console.WriteLine("&&&&%%%%%%%%%&&&%/.&& ,,.*,,/* ../.&&%%%%%%%%%&&%");
                    Console.WriteLine("&&&%%%%%%%%%%%%& .& /.. /,,*(%##/.&&%%%%%%%%%%%%&");
                    Console.WriteLine("&&%%%%%%%%%%%%%&%,&&,#./*/.,.,/,&&&%%%%%%%%%%%%%%");
                    Console.WriteLine("&&%%%%%%%%%%%%%&%..##(/. ,/**. &&&&&&%%%%%%%%%%%%");
                    Console.WriteLine("&&%%%%%%%%%%%%&#..*&#/,*,,#*,# @.**. #&&&%%%%%%%%");
                    Console.WriteLine("&&%%%%%%%%%%%&/#/*, , /.,*,/,.**,  ,,.(*&&&%%%%%%");
                    Console.WriteLine("&&%%%%%%%%%%&&.**#,..**,*,... ,,.***, ,,/,&%%%%%%");
                    Console.WriteLine("&&%%%%%**&&&&&,**.,.,///(///*.,****,*,.,,/&&&%%%%");
                    Console.WriteLine("&&%%%&&...#&&%,*,((,//,*/,*,./*.,*.((* ,,*&&&%%%%");
                    Console.WriteLine("&&%&%&&&&& ..,,,,.,,/,&*,,,.,/#*#. ,,..,*.&&&%%%%");
                    Console.WriteLine("&&%%%%%%&&&&&..., &,((.&***#&,*(///# ,,.&&&%%%%%%");
                    Console.WriteLine("&&%%%%%%%%&&&*/.,.///.(,    ....,#/#*#&&&&&%%%%%%");
                    Console.WriteLine("&&&%%%%%%%%&%/&&%,,,,(%(.&&&&&&%,,//,#&&&&%%%%%%&");
                    Console.WriteLine("&&&&%%%%%%%&&&#,**/(/.,,*%#//&&&&*((//(&&&%%%%&&%");
                    Console.WriteLine("&&&%&&%%%&&&&%,*,,,*&&&&.,..(&&,#,//.,#&&%%%%&&%&");
                    Console.WriteLine("&&&&&&&&&&&&&*. ...&&&&&&&&(.,,.&&  .&&&&&&&&&&&&");
                    Console.WriteLine("&&&&&&&&&&&&*..*&&&&&&&&&&&&&&&&@,,,&&&&&&&&&&&&&");
                    Console.WriteLine("&&&&&&&&&&&.*/%/       ....      /../(%*..&&&&&&&");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("        ");

                    // paint line for line an ascii charactor!




                    Console.WriteLine("                                                   ");

                    Console.WriteLine("<<press any key>>");
                }
                //elf character   multiplayer EQ: bow n arrow   @)→
                //Elves make excellent assassins and sorcerers
                else if (keyReader == ConsoleKey.D2)
                {
                    Console.Clear();

                    str = 4;
                    con = 5;
                    dex = 6;
                    intel = 5;

                    speed = 100;

                    Console.WriteLine("        ");
                    player.race = 1;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@*(/*,@@@@@@@@@@@@@@@(@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@/,//((%/#@@@@@@@@@@. ..@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@,**,//%/#@@@@@@  .. @@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@/**,/*(#@@@@@/#.  @@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@(**, ...., (((/(@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@&(...,,,,.//.@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@##(, ,*,.,**/@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@,@@@@@@@@@@@@@&#*/&*(%##*&@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@,@@@@@@@@@&((#*(% ,...,,@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@*@@@@@@@@@@@#*&*/**(/,.@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@.#@@@@@@@@  ***,,*/.@@@@@@@@@@@.,@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@ ..@@@@*,*/**,,, @@@@@@@.@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@,. .........*@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@.@   ...  @@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..  ....@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..**.,.  @@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@...,..,  @@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@  .. # ..  @@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. *@ .  @@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@/   @@ ., @@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. @@. . @@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@..  @@%.. @@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. ..  .,. @@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("        ");


                    Console.WriteLine("you selected a swift nightelf character");
                    Console.WriteLine("STR " + str);
                    Console.WriteLine("CON " + con);
                    Console.WriteLine("DEX " + dex);
                    Console.WriteLine("INT " + intel);
                    Console.WriteLine("        ");

                    Console.WriteLine("                                                   ");

                    Console.WriteLine("<<press any key>>");


                }
                //troll character   multiplayer EQ: shield  @■
                //trolls make exceptional attackers and defenders
                else if (keyReader == ConsoleKey.D3)
                {
                    Console.Clear();

                    str = 7;
                    con = 5;
                    dex = 6;
                    intel = 2;
                    speed = 250;
                    player.race = 2;
                    Console.WriteLine("you selected a fiendish troll character");
                    Console.WriteLine("STR " + str);
                    Console.WriteLine("CON " + con);
                    Console.WriteLine("DEX " + dex);
                    Console.WriteLine("INT " + intel);
                    Console.WriteLine("        ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,((/, ..*,*(@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@.*..   .****# ,.,(*@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@.  ...., ..,,,..,,,.*(*#.&#@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@.*/.**.  .   ..*/*,, @@(**,,.@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@...,**#,,.,,,..,.**.@##@@@@,.@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@..,//*,/,,..  .,*.... %%@@@@/&@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@,*,**,,*,//((*,,,.,,...@@@@@&@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@,.*../,,*/(/((*,*..,,.@@@@@@%@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@%.,,(*/,,...,////,,@,,.,@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@..*,/*,*/,@.,,*.,.,...,...,@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@.,**.,,@(,,@..,*,*..,.**,,...@@@@@@@@@@");
                    Console.WriteLine("@@@.@@@*.*,**,..@@@&   .,**. .. ..*,..,,,@@@@@@@@");
                    Console.WriteLine("@@,..@@@., /./.@@@@@,,,,*.* ....**(#*.*,,,&@@@@@@");
                    Console.WriteLine("@@#....@ ..,*,.@@@@*,**/*...  .. ./#(*.%,,,,@@@@@");
                    Console.WriteLine("@@@@@*  ,*,**,.@@@@,*/**,.,......./##( ,@,,,,*@@@");
                    Console.WriteLine("@@@@@@#.,#,.,.,*@@@...,,,.,.... . /(/* .....,.,@@");
                    Console.WriteLine("@@@@@@@,*,... ...@.,,.... ... .../,&.........,/,@");
                    Console.WriteLine("@@@@@@@@%@#%. , .,,,/.   .  . &  .@..,..@@@@@&@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@.. .,.,,**.@    *.&..,..@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@,.. ..,.,.,.,,..*.....@...#@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@..,., .@@@ .,.,,,,,..@*/....,  .&@@@");
                    Console.WriteLine("@@@@@@@@@@@@...,.* @@@@@  ,..,,.,../*@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@  @@@@@@@@@...,*./(((,@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/ .((//@@@@@@@@@@@@@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("        ");
                    Console.WriteLine("<<press any key>>");
                }
                //goblin character   multiplayer EQ: slingshot  @y°
                //goblins can be great assassins and warriors
                else if (keyReader == ConsoleKey.D4)
                {

                    str = 5;
                    con = 4;
                    dex = 8;
                    intel = 3;
                    speed = 100;
                    Console.WriteLine("        ");
                    player.race = 3;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@/@@(.* @@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@,@@,/,,@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@&*/@@@,/%@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@ ,. &**/@@@,% @@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..,,//**.,/@@@ ./@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@..//,/.,,//@(,,,./@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@./*//.*****,,.,*./..(,/.,,*,*,@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@#.,,,,,/,,,,(..,,,**@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@,,. ,.,//...//, @@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@.,,,.......///%,@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@//*,..*, ./,./,@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@,,*@@..#.../.  @@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@ ,,,@,, ***,.. @@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.*..,***.*,..,,*@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.. ..*/(**## ,,. @@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@,*.,**,, *,/ %,,,,. .(@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@**,, @@@@@@@@,.., @@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@%%/*,@@@@@@@@@@...*@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.*,,@@@@@@@@....@@@@@@@*&.@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@.*, @@@@@@@@@@*,, @@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@ ,@@@@@@@@@@@@@.*,*.@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,*, @@@@@@@@@@@@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("        ");


                    Console.WriteLine("you selected a mischievous goblin character");
                    Console.WriteLine("STR " + str);
                    Console.WriteLine("CON " + con);
                    Console.WriteLine("DEX " + dex);
                    Console.WriteLine("INT " + intel);
                    Console.WriteLine("        ");
                    Console.WriteLine("<<press any key>>");
                }
                //ork character   multiplayer EQ: bombs @●
                //orks are powerful and make great reapers and defenders
                else if (keyReader == ConsoleKey.D5)
                {
                    Console.Clear();

                    str = 6;
                    con = 8;
                    dex = 3;
                    intel = 3;
                    speed = 300;

                    player.race = 4;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@&&,,,,,,*&@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@(,**,,,*,,*/**,.,,*@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@,,,*,*,,*,,***,*(,//,#@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@&,.,**,,,,***/**,,(#.,(%@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@**,,*/,,,****//,,/*.,,*//*(@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@,,,***..,*//(//,*./..,,..,.*&@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@,*,.**.. ..,***(**,.**,,*/,.,,@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@,**,,..@...,.*****,,,* ..//@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@,***,,,@@...,,,....,.....**@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@,,*/,,/@@.............,*..%@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@,,/*,@@@,.....,,,..,... .,*@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@,,//,,@@@.,.,*,,,.,,..*.,.@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@*/(,...@,,.*,**,,,.,.,,. *@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@*,.,**,@@,,..*****,,,,..,..*@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@*, ..@@@@@.,/**,....... ,,*/ %@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@(*..@@@@@@@,,*/*,,..,....,,,*.&#.,@@@@@@@@%@@@@");
                    Console.WriteLine("@/*.@@@@@@@@@.,,,*..@..,., ,,,.,,@@@ .,#@@**,,**@");
                    Console.WriteLine("@(@@@@@@@@@@@/,,,..@@....@@  ,.,,@@@@@#. ,,,,,,,,");
                    Console.WriteLine("@@@@@@@@@@@@%..,...&@.,,*(.......@@@@@@@,,,,**,..");
                    Console.WriteLine("@@@@@@@@@@@@@..... %@@@@@... .(@@@@@@@@..,,,,, .&");
                    Console.WriteLine("@@@@@@@@@@@@@@@ ..@@@@... .@@@@@@@@@@@@...,,,..@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@...@@@&&.,,,,&%%%%%%&&&%%#....@@@");
                    Console.WriteLine("@@@@@@@@@@@@@....,..***********//(#%&@@@@@@@@@@@@");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("you selected an brute ork character");
                    Console.WriteLine("STR " + str);
                    Console.WriteLine("CON " + con);
                    Console.WriteLine("DEX " + dex);
                    Console.WriteLine("INT " + intel);
                    Console.WriteLine("        ");
                    Console.WriteLine("<<press any key>>");
                }

                //juggernaut character   multiplayer EQ: shield  @■
                //juggernaut make exceptional sorcerers and warriors
                else if (keyReader == ConsoleKey.D6)
                {
                    Console.Clear();

                    str = 5;
                    con = 4;
                    dex = 4;
                    intel = 7;
                    speed = 110;
                    player.race = 5;
                    Console.WriteLine("you are a juggernaut");
                    Console.WriteLine("STR " + str);
                    Console.WriteLine("CON " + con);
                    Console.WriteLine("DEX " + dex);
                    Console.WriteLine("INT " + intel);
                    Console.WriteLine("        ");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@..@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ /,,,/@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ **/**@@@@@%%@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@,*@@@.,//*/(/ ..@@@/, */.@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@,/,,.  %@@@,*/ (, *#.*/@@. *.,(@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@/,*. . (@@, *.*.*/, * @@@@@@*/ (@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@%,.,@@@@.*,,,/*..*    .(@@@@ , @@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@...,@@@@@*,,..* ,.,., ***/*@@@@#/./*@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@(/*@@@@@.../ . ,*  (.(.../*@@@@@ #/@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@,,.,.*,/,/@@ .*(,(/,@@ ,.,. .,*%@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@/*/., *@*, **/ (*/@@ */.,#@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@.*.@../*,** , ,@ */@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@**., ,,   ./ *., / (@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@#.,//**(. .,.,,,**,*@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@//,*(  .  , .*/.@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@&@,///*.*,, ,/,/(*@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@**  ./**,.*.,..*.*(*@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@,,  /*/..... *****(@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@&@(., */**.. .  **/ / (@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@,,.  .*.,. . ,,, ..*@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@*@@*/  ,/ ..&, (*@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.*,@@..@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@&*/ *, * ,@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("        ");
                    Console.WriteLine("<<press any key>>");
                }








                else { return; }











                Console.ReadKey();




                //select class (weapons)
                Console.Clear();
                Console.WriteLine("                   ");

                Console.WriteLine("select your class");

                Console.WriteLine("┌────────────────────────────────┐");
                Console.WriteLine("│attacker [1] sword       †      │");
                Console.WriteLine("└────────────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────────────┐");
                Console.WriteLine("│sorcerer [2] staff       Ґ      │");
                Console.WriteLine("└────────────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────────────┐");
                Console.WriteLine("│rogue [3] dagger         →      │");
                Console.WriteLine("└────────────────────────────────┘");
                Console.WriteLine("                   ");
                Console.WriteLine("┌────────────────────────────────┐");
                Console.WriteLine("│defender [4] hammer      Ƭ      │");
                Console.WriteLine("└────────────────────────────────┘");
                Console.WriteLine("                   ");




                var keyReader2 = Console.ReadKey(true).Key;
                


                //attacker character
                if (keyReader2 == ConsoleKey.D1)
                {
                    Console.Clear();
                    str += 3;
                    con += 2;
                    Console.WriteLine("nothing escapes your sharp sword!");
                    Console.WriteLine("attackers get +3 STR and +2 CON");
                    equipmentInteger = 1;
                    player.Class = 1;
                    Console.WriteLine("                                                   ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@.,,.,.@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@, *(*.,@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,*,,@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*.,*(**., *@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@/*....,.*(,,,.#@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@,#..,.,*,,,//.*, @@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@,/...*/, ..,.,.,,*@@@@@@%,/");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,.,....*//,,*(*..,, @@*,*.*/@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@(.,.*,, **,./*&&.,,,.*...,@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@.*,.@../...(**@@,,/,./*..,@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@*...,,.,,,.*,,,,/,//,.../@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@ *,......,.,**,,**///***.@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@&.,,...,..***/,,,/,,/*/*..*@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@.*,..,,.*,,.,,*,,,,,/,/*,...,@@@@");
                    Console.WriteLine("@@@@@@@@@&.,.* #@@@@@ @@..,.,*,..,,,/(*,....&@@@@");
                    Console.WriteLine("@@@((** #@@@@@@@@@@@@@@@....,,,../*,,,*.*..,@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@..,,,./..@,/**....,.@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@.,,**.*@/@*/**.@@,@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@(/****@@@**/,@@@@,&@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@,**%@@@/,**@@@@@.@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@./*@@@@@*,,@@@@@@,@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*/*@@@@@.(/@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@,*,..@@@@@.//@@@@@@@@@@@@");
                    Console.WriteLine("                                                   ");
                    Console.ForegroundColor = ConsoleColor.White;

                   

                }
                //sorcerer character
                else if (keyReader2 == ConsoleKey.D2)
                {
                    Console.Clear();
                    intel += 3;
                    dex += 2;
                    Console.WriteLine("as a wizard you trash your oppponents with a staff");
                    Console.WriteLine("sorcerers get +3 Int and +2 DEX");
                    equipmentInteger = 3;
                    player.Class = 3;
                    Console.WriteLine("                                                   ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@(///*@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@((,,//**/@@@@@@@@@@%/@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@&@@/,(,#..*,,,,@@@@@@@@/***@@@@@@@@@");
                    Console.WriteLine("@@@@@@&@@@@@@@@@,,*/,***.*..%@@@@@@@*((/@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@(,/,./%%%%,..%@@@@@@#,*@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@&@@@@@@@,,*....%*(.,.,,@@@@@@&/#@@@@@@@@@@");
                    Console.WriteLine("@@&@@@@@@@@@@@@@*,....//.*,.,,@@@@@@/*@@@@@@@@@@@");
                    Console.WriteLine("@@@@&&&@@@@@@#(/*,...#%.*..,//@@@@(,@@@@@@@@@@@");
                    Console.WriteLine("@@@@&@&%&@#@@**%(/**,*/,/#,*,,,,@@@@#,@@@@@@@@@@@");
                    Console.WriteLine("@@&&@@&@&%@@##,,,,,,*,*%...%/,*/,@@@(/@@@@@@@@@@@");
                    Console.WriteLine("@##@@@@@&@@#(**/*,.,*(#*%/*,*//*@@(&@@@@@@@@@@@");
                    Console.WriteLine("@@(%@@&@%&@#(#/*,**,..,./,,,../%/.**,@@@@@@@@@@@@");
                    Console.WriteLine("@@@%&@@@@@(#(,/,,.**.,..../*/#((..*@@@@@@@@@@@@");
                    Console.WriteLine("@@&&@@@%@(%.,,.#/.....**...,/.*%%(#*,./@@@@@@@@@@");
                    Console.WriteLine("@@@&@@@@&,,,/,,//.,..*(,,,.,//*/(*,*%..,@@@@@@@@@");
                    Console.WriteLine("@@@@#@@@**%#@.**.,.../,...,,.,,/,..*,/...@@@@@@@@");
                    Console.WriteLine("@@@@@#*...%*,**.,,...*,/....,,,,,,**,,....@@@@@@@");
                    Console.WriteLine("@@@@@#@*/****....,.../,,.,,,,,.,,**/*,.....@@@@@@");
                    Console.WriteLine("@@@@@@@%*/@//,.......%**..,,,.,.**,**,......@@@@@");
                    Console.WriteLine("@@@@@@,,*,///*,,,,,....,//*,.,,,,,,,&@@@@@@@@@(..");
                    Console.WriteLine("@@@@@*,//,*/////,,,,...,%#(,,,/((,,,.@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@,////*//..%//#,....%#///##((*,%.@@@@@@@@@@@@");
                    Console.WriteLine("@@@@,/,//////@@@*,%%,,,./.,,.....**/@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@,,,*//////@@(//...//*,,,./*%@(@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@,,,,//////@@@@@@..,,.,...@@@&*@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@,,//////@@@@@.,,,,,,..@@@,,@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@.....&%*.*,@@@*&@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@.,,.,@#****@%,@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,...@%*,.,..,@@@@@@@@@@@@@@@@");
                    Console.WriteLine("                                                   ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                   ");
                  

                }
                //assassin character
                else if (keyReader2 == ConsoleKey.D3)
                {
                    Console.Clear();
                    str += 2;
                    dex += 3;
                    Console.WriteLine("you have learnt the art of backstabbing with daggers!");
                    Console.WriteLine("assassins get +3 DEX and +2 STR");
                    equipmentInteger = 0;
                    player.Class = 0;
                    Console.WriteLine("                                                   ");

                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@*.*,,,*,,&@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@,   ,,,.,.@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@  ..,*..,.@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@,.  .*...,,,@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@(, .. .,.....,*@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@%  . ........,.,,,,@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@... .  .......,. ,*,*@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@. . ...,.....,,,...,%@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@,*,.........,..,.....&@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@,,,... .,...,..,..,@...*@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@&.*.,.....*((/..,..(%..@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@,.    . .....,.*.,*/@...@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@, ... . ..,.,.,,.,,,(/ ...@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@*....,.,,...,*(.*,,,#,...&@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@,. .....,(. .. /,.,.,,/*./#@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@, ...,* ...,.,  *..,,. ,*(@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@..@@@@ . .....   .......,@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@(........   . .....,#@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@.....,,,..   ,,,.*...@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@.....,,,..   ,,,.*...@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@,., ../*(.*...  .,/**..*@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@....,,(/,/*..  ..,,*  .#@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@/....,,,,/***.....,,,//..@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@,...,,,#.///*(..,.,**/#,.,@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@/. @@@@% ..//%@@@@,*,**./@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@*,,*,,@@@@@@,*,*#@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@% *//,*/*,@@@@@@@@,,,*,@@@@@@@@@@");

                    Console.WriteLine("                                                   ");

                   

                }
                //defender character
                else if (keyReader2 == ConsoleKey.D4)
                {
                    Console.Clear();
                    str += 2;
                    con += 3;
                    Console.WriteLine("you trash your opponents with a heavy mace!");
                    Console.WriteLine("defenders get +3 Con and +2 STR");
                    Console.WriteLine("                                                   ");
                    equipmentInteger = 2;
                    player.Class = 2;
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@# ....*@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@*,(%((*@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@,.%%%/.@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@&, ***,,.@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@&*,.          *,@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@&..    ..  ,. ....,*@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@,**..     . ,,.  ,.#,@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@,..*.,,. ... .*,,/,*/,*@@@@@@");
                    Console.WriteLine("@@@@@@@(@@@@@@@@@@@/*. .*/*,..,...*/%%, .,.,%@@@@");
                    Console.WriteLine("@@@@@%*#@@@@&@@@@@@./,.//*.,,*,,#*/*/*,. .. .,@@@");
                    Console.WriteLine("@@@@/(%@@@@(#@@@@@#,*,#/*,#,**(//( . .,, .    ,@@");
                    Console.WriteLine("@@@&&(*&@@,,&@@@@%,/.@(*,*/**/*.,,.  ,,..     @@@");
                    Console.WriteLine("@@(@&*(%((*,...,.,#@,//,(//#/**. .. . ...        ");
                    Console.WriteLine("@&&/,/&@&./&@@@@@@@@@@*(#*&&/%(*/,,       .,    %");
                    Console.WriteLine("&//*%@@@%@@@@@@@@@@@@(,,,%@&(//%@,.        (@@@@@");
                    Console.WriteLine("*(((@@@@@@@@@@@@@@@@@(.,(%%@@(/@(*.     (@@@@@@@@");
                    Console.WriteLine("((*@@@@@@@@@@@@@@@@@@#* *//*&**,/,*/,@,&@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@&.  *##,@@@%./%(.&@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@%. #*&@@&,.*../@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@..,.  #@@@@@/#%#/*@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@(%/*(*.*@@@@@#.**,@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@((####*%@@@@@#.*.*@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@,*,./@@@@@@@@@@(.,*.,&@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@#,.,.&@@@@@@@@@@@@%*.(@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@(,(/,,@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("@@@@@@@@@@@@@@@@@.....(@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("                                                   ");

                   
                }


                else { return; }
                Console.WriteLine("<<press any key>>");

                Console.ReadKey();
                //start game by pressing spacebar
                Console.WriteLine("                   ");
                Console.Clear();

                player.equipmentInteger = equipmentInteger;
                player.generateStarterItem();

                if (musicOn)
                {
                    // play audio file
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/01_character_creation.wav";
                    musicPlayer.Play();
                }

                //Console.SetWindowSize(240, 63);

                // ADD TEXT HERE: YOU START THE GAME. WHO ARE YOU?
                // DESCRIBE THE WORLD TO THE PLAYER..
                //*************************************************************************************************************

                Console.WriteLine("<< press any key >>");
                Console.ReadKey();





                //     Console.SetWindowSize(player.oWidth, player.oHeigth);

                Console.Clear();
                Thread.Sleep(300);



                player.STR = str;
                player.CON = con;
                player.DEX = dex;
                player.INT = intel;
                player.speed = speed;
                player.actionString = "                             ";


                //GameInterface gameInterface = new GameInterface(map.arrayWidth + 3, 1);

                player.yPos = 20;
                player.xPos = 55;
                
                map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                player.mapArray = map.mapArray;
                map.DrawMap();
                player.DrawPlayer();
                Random random = new Random();
                int enemies = random.Next(2, 10);
                player.populateLevels(enemies);



               
                //           NPC.populateWithNPCs(5);

                while (true)
                {


                    //if ur turn!

                    player.UpdateStats();
                    player.UpdatePlayer();
                    player.UpdateDirection();



                    if (map.activeLevel == 1)
                    {

                        // create an array of enemies, and each gets updated here in for loop
                        // in update the enemies roam around every few seconds


                        //load NPCs 

                        //populate with NPCs
                        //add text according to ID numbers
                        //      player.populateLevels(8);



                    }






                    if (player.playerDied())
                    {
                        // Console.Clear();

                //        map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                        player.mapArray = map.mapArray;
                        player.xPos = 5;
                        player.yPos = 5;
                        player.burnCounter = 0;

                        player.health = player.maxHealth;
                        player.mana = player.maxMana;
                        player.life -= 1;

                        Thread.Sleep(1000);
                //        map.DrawMap();
                //        player.DrawPlayer();
                 //       player.populateLevels(4);
                        musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/01_character_creation.wav";
                        musicPlayer.Play();



                    }


                    //*************** portals  ▼ ► ◄ ▲ *******************************************************************************
                    if (player.enterDoor())
                    {
                        // randomly generate tables, pots, people etc..
                        map.mapArray = map.shopMap;
                        player.xPos = 5;
                        player.yPos = 6;
                        player.mapArray = map.mapArray;
                        map.DrawMap();
                    }

                    if (player.leaveDoor())
                    {
                        player.indoors = false;
                        map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                        player.xPos = 3;
                        player.yPos = 4;
                        player.mapArray = map.mapArray;
                        map.DrawMap();
                    }



                    //***** global world coordiantes **************************************************************************************************************

                    if (player.travelEast())
                    {
                        // Console.Clear();
                        map.xCoordinates++;
                        player.xCoordinates++;
                        map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                        player.mapArray = map.mapArray;
                        player.xPos = 3;
                        player.burnCounter = 0;
                        map.DrawMap();
                        player.DrawPlayer();
                        enemies = random.Next(2, 14);
                        player.populateLevels(enemies);
                    }


                    if (player.travelWest())
                    {
                        //Console.Clear();
                        //map.ChangeMap(map.activeLevel - 1);
                        map.xCoordinates--;
                        player.xCoordinates--;
                        map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                        player.mapArray = map.mapArray;
                        player.xPos = 108;
                        player.burnCounter = 0;
                        map.DrawMap();
                        player.DrawPlayer();
                         enemies = random.Next(2, 14);
                        player.populateLevels(enemies);
                    }

                    if (player.travelSouth())
                    {
                        //Console.Clear();
                        map.yCoordinates--;
                        player.yCoordinates--;
                        map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                        player.mapArray = map.mapArray;
                        player.yPos = 37;
                        player.burnCounter = 0;
                        map.DrawMap();
                        player.DrawPlayer();
                         enemies = random.Next(2, 14);
                        player.populateLevels(enemies);
                    }

                    if (player.travelNorth())
                    {
                        //Console.Clear();
                        map.yCoordinates++;
                        player.yCoordinates++;
                        map.ChangeGlobalMap(map.xCoordinates, map.yCoordinates);
                        player.mapArray = map.mapArray;
                        player.yPos = 3;
                        player.burnCounter = 0;
                        map.DrawMap();
                        player.DrawPlayer();
                         enemies = random.Next(2, 14);
                        player.populateLevels(enemies);
                    }

                    //*************** portals  ▼ ► ◄ ▲ *******************************************************************************




                    player.DrawPlayer();
                    //gameInterface.Draw();
                }



            }





        }
        //display the playermap




    }
}


