using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Timers;


namespace rogueLike
{
    public class Player
    {
        // stats for player 1
        public int health = 25;
        public int maxHealth = 25;
        public int mana = 15;
        public int maxMana = 15;
        public int coins = 0;
        public int life = 4;

        public int DEX = 1;
        public int STR = 1;
        public int CON = 1;
        public int INT = 1;
        public int speed = 220;  //100 very fast 1000 very sluggish!

        SoundPlayer musicPlayer = new SoundPlayer();

        public bool zoomBool = false;
        public int fieldsWalked = 0; // walk 5 fields per turn or make enemy contact
        public int oWidth = Console.WindowWidth;
        public int oHeigth = Console.WindowHeight;
        public bool replaceMapImage = false;
        public int xPos = 20;
        public int yPos = 3;
        public int dmg;
        public int equipmentInteger = 0;
        public int equipment2Integer = 0;
        public string actionString;
        public int burnCounter = 0;
        public bool leverTurned = false;
        ConsoleKeyInfo key;

        // 0 sword    @→
        // 1 daggers  @⇉
        // 2 staff    @⌠↯
        // 3 warplow  @↱


        // bow      @)→
        // hookshot @---↠
        // magnet   @⊂
        // firekit  @▲
        // discus   @🞇
        // shield   @◆◊
        // bomb     @○


        bool hasFire = false;
        bool hasMagnet = false;
        bool hasDiscus = false;
        bool hasShield = false;
        bool hasBomb = false;
        bool hasHookshot = false;
        bool hasBow = false;

        int enemyNumbers;

        public int level = 1;

        public int weaponGrade = 0; // 0 is white and basic, // 1 is gold // 2 is blue!
        public string item1 = "→";
        public string item2 = "▲";
        //)→
        public string direction = "East";
        public string[,] mapArray;
        public string[,] enemyArray;
        public string floorString;

        bool attack = false;
        bool skillAttack = false;

        bool use = false;
        public Map map;
        bool enemyContact = false;
        public Random random = new Random();
        List<Enemy> enemyList = new List<Enemy>();
        List<rogueLike.NPC> npcList = new List<rogueLike.NPC>();
        private Enemy currentEnemy;
        private bool enemyContactEast;
        private bool enemyContactWest;
        private bool enemyContactSouth;
        private bool enemyContactNorth;
        private int enemyIndex;
        private bool riddleSolved = false;
        private static System.Timers.Timer aTimer;

        public int xCoordinates = 4;
        public int yCoordinates = 3;

        internal Enemy CurrentEnemy { get => currentEnemy; set => currentEnemy = value; }



        public Player(string[,] MapArray)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            mapArray = MapArray;
            map = new Map();
            // change to maparray 1
        }

        public void die()
        {
            Thread.Sleep(1000);
           // life -= 1;
           // actionString = "You just died";
           // riddleSolved = false;
           // Map lvl = new Map();
        }

        public void UpdatePlayer()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.SetWindowSize(90,30);
            Console.SetCursorPosition(xPos, yPos);


            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }

            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;

            // *** Full Screen or only small windows? ***********************************************************************

          //  if (zoomBool == true) { Console.SetWindowSize(140, 63); }
        //    else { Console.SetWindowSize(oWidth, oHeigth); }

            // *** LEVEL DESIGN CAMPAIGN ************************************************************************************


            map = new Map();

            // loose if you have 0 life left!

            if (health <= 0)
            {
                die();
            }



            //let us check if we are in the right level!
            if (level == 1)
            {
                //spawn enemies on level 1a

                //map.populateLevels();


                if (burnCounter < 3 && riddleSolved == false)
                {
                    //place a dot over the ladder!
                    //actionString = "i am in level 1a";

                    // coverLadder(mapArray.GetLength(1) - 2, 6);
                }

                //light 8 piles of wood in first level to get to next one
                if (burnCounter > 3 && map.mapArray == map.map1Array && riddleSolved == false)
                {

                    actionString = "you solved the riddle";
                    riddleSolved = true;
                    // add a ladder to the level!
                    int xpos = random.Next(5, 12);
                    int ypos = random.Next(3, 12);
                    giveLadder(mapArray.GetLength(1) - xpos, ypos);

                    // if this is not lvl 1

                }




                else if (burnCounter > 3 && map.mapArray != map.map1Array)
                {

                    actionString = "lets delete the old ladder";

                    // add a ladder to the level!
                    //      giveLadder(mapArray.GetLength(1) - xpos, ypos);
                    int xpos = random.Next(2, 12);
                    int ypos = random.Next(3, 12);
                    Console.SetCursorPosition(mapArray.GetLength(1) - xpos, ypos);

                    Console.Write(" ");
                    // remove burn counter to zero
                }



            }
            else if (level == 2)
            {
                actionString = "welcome to the next level            ";

                if (burnCounter >= 1)
                {
                coins +=100;
                    burnCounter = 0;
                }
                //activate the lever

                // if activated give ladder!


            }

            else if (level == 3 )
            {

          
            }



            //*** Steuerung / Controls! ****************************************************************************

            if (Console.KeyAvailable)
            {
                Console.TreatControlCAsInput = true;



                switch (Console.ReadKey(true).Key)
                {

                    // player attack
                    case ConsoleKey.Spacebar:
                        attack = true;
                        break;

                    case ConsoleKey.E:
                        use = true;
                        break;

                    case ConsoleKey.Enter:
                        skillAttack = true;
                        break;

                    

                        // get the enemy array from map??

                        // enemyArray [yPos, xPos]
                        if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                        else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
                        else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                        else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }

                    case ConsoleKey.D:
                        direction = "East";
                        fieldsWalked++;
                        if (mapArray[yPos, xPos + 1] != "█" && mapArray[yPos, xPos + 1] != "▒" && mapArray[yPos, xPos + 1] != "e")
                        {
                            Console.SetCursorPosition(xPos, yPos); //Erst an Position Löschen
                            Console.Write(mapArray[yPos, xPos]);

                            xPos += 1;
                            Console.SetCursorPosition(xPos, yPos); //An neuer Position zeichnen
                            
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("@");
                            Console.ForegroundColor = ConsoleColor.White;
                        }



                 //       Thread.Sleep(speed);
                        //array with only enemies on same size


                        break;
                    case ConsoleKey.A:
                        direction = "West";
                        fieldsWalked++;
                        if (mapArray[yPos, xPos - 1] != "█" && mapArray[yPos, xPos - 1] != "▒" && mapArray[yPos, xPos - 1] != "e") //Kollision links
                        {
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write(mapArray[yPos, xPos]);

                            xPos -= 1;
                            Console.SetCursorPosition(xPos, yPos);
                          
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("@");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                //        Thread.Sleep(speed);

                        break;
                    case ConsoleKey.S:
                        direction = "South";
                        fieldsWalked++;
                        if (mapArray[yPos + 1, xPos] != "█" && mapArray[yPos + 1, xPos] != "▒"
                        && mapArray[yPos + 1, xPos] != "e") //Kollision unten
                        {
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write(mapArray[yPos, xPos]);

                            yPos += 1;
                            Console.SetCursorPosition(xPos, yPos);

                           
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("@");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                 //       Thread.Sleep(speed);

                        break;
                    case ConsoleKey.W:
                        direction = "North";
                        fieldsWalked++;
                        if (mapArray[yPos - 1, xPos] != "█" && mapArray[yPos - 1, xPos] != "▒"
                        && mapArray[yPos - 1, xPos] != "e") //Kollision oben
                        {
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write(mapArray[yPos, xPos]);

                            yPos -= 1;
                            Console.SetCursorPosition(xPos, yPos);


                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("@");
                            Console.ForegroundColor = ConsoleColor.White;

                        }



                  //      Thread.Sleep(speed);

                        break;

                    case ConsoleKey.D1:
                        equipment2Integer = 0;
                        item2 = "▲";
                        break;

                    case ConsoleKey.D2:
                        equipment2Integer = 1;
                        item2 = "∩";
                        break;

                    case ConsoleKey.D3:
                        equipment2Integer = 2;
                        item2 = "○";
                        break;

                    case ConsoleKey.D4:
                        equipment2Integer = 3;
                        item2 = "■";
                        break;

                    case ConsoleKey.D5:
                        equipment2Integer = 4;
                        item2 = "●";
                        break;

                    case ConsoleKey.D6:
                        equipment2Integer = 5;
                        item2 = ")→";
                        break;

                    case ConsoleKey.F:
                        zoomBool = !zoomBool;
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;



                }






                //spawn a red "X" or a red circle above enemy for blood... same for you..


                // ►▼◄▲

          /*      if (mapArray[yPos, xPos] == "◄")
                {
                    actionString = "you travel east";
                    xCoordinates++;
                }
                else if (mapArray[yPos, xPos] == "▼")
                {
                    actionString = "you travel south";
                    yCoordinates++;
                }
                else if (mapArray[yPos, xPos] == "►")
                {
                    actionString = "you travel west";
                    xCoordinates--;
                }
                else if (mapArray[yPos, xPos] == "▲")
                {
                    actionString = "you travel north";
                    yCoordinates--;
                }*/

                /* if (mapArray[yPos, xPos] == "►" || mapArray[yPos, xPos] == "▼" || mapArray[yPos, xPos] == "◄" || mapArray[yPos, xPos] == "▲")
                 {
                     Console.SetCursorPosition(xPos, yPos);
                     Console.Write(" ");
                     actionString = "you go to the next map";

                     //level++;
                     // instead of level++ add coordinates to 
                     riddleSolved = false;
                     Map lvl = new Map();

                 }*/



                if (mapArray[yPos, xPos] == "#")
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(" ");
                    actionString = "You found a ladder to level " + level;
                    
                //    level++;
                    riddleSolved = false;
                    Map lvl = new Map();

                }
                if (mapArray[yPos, xPos] == "♥")
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(" ");
                    actionString = "You found 1Up!                                ";
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_magnet.wav";
                    musicPlayer.Play();
                    life++;
                    health = maxHealth;
                    mana = maxMana;
                    mapArray[yPos, xPos] = "⁃";

                }
                if (mapArray[yPos, xPos] == "□")
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(" ");
                    actionString = "You open a treasure box! with [e]";
                    // give an item!!
                }
                if (mapArray[yPos, xPos] == "≡")
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(" ");
                    actionString = "You stand near a pile of wood.";

                    // give an item!!
                }
                
                if (mapArray[yPos, xPos] == "┖")
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(" ");
                    actionString = "You activate a lever with [e]";

                    // give a ladder?!!
                }


                

            }

            //*** check for enemy positions here! ****************************************************************************

            if (mapArray[yPos, xPos + 1] == "e" || mapArray[yPos, xPos + 1] == "s" || mapArray[yPos, xPos + 1] == "w" || mapArray[yPos, xPos + 1] == "g" || mapArray[yPos, xPos + 1] == "t" || mapArray[yPos, xPos + 1] == "k" || mapArray[yPos, xPos + 1] == "r" || mapArray[yPos, xPos + 1] == "e")
            {
                //actionString = "north of you stands an enemy                    ";
                enemyContact = true; ;
                
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        if (enemyList[i].xPos == xPos + 1 && enemyList[i].yPos == yPos)
                        {
                            enemyIndex = i;
                            enemyContactEast = true;
                            enemyContactWest = false;
                            enemyContactNorth = false;
                            enemyContactSouth = false;

                           // actionString = "you got the right enemy!";
                            CurrentEnemy = enemyList[i];

                        }
                    }
                


            }
            else if (mapArray[yPos, xPos - 1] == "e" || mapArray[yPos, xPos - 1] == "s" || mapArray[yPos, xPos - 1] == "w" || mapArray[yPos, xPos - 1] == "g" || mapArray[yPos, xPos - 1] == "t" || mapArray[yPos, xPos - 1] == "k" || mapArray[yPos, xPos - 1] == "r" || mapArray[yPos, xPos - 1] == "e")
            {
                // actionString = "west of you stands an enemy                    "; 
                enemyContact = true; ;
                
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        if (enemyList[i].xPos == xPos - +1 && enemyList[i].yPos == yPos)
                        {
                            enemyIndex = i;
                            enemyContactEast = false;
                            enemyContactWest = true;
                            enemyContactNorth = false;
                            enemyContactSouth = false;
                          //  actionString = "you got the right enemy !                   ";
                            CurrentEnemy = enemyList[i];

                        }
                    }
                


            }
            else if (mapArray[yPos + 1, xPos] == "e" || mapArray[yPos + 1, xPos] == "s" || mapArray[yPos + 1, xPos] == "w" || mapArray[yPos + 1, xPos] == "g" || mapArray[yPos + 1, xPos] == "t" || mapArray[yPos + 1, xPos] == "k" || mapArray[yPos + 1, xPos] == "r" || mapArray[yPos + 1, xPos] == "e")
            {

                //actionString = "north of you stands an enemy                    ";
                enemyContact = true; ;
                
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        if (enemyList[i].xPos == xPos && enemyList[i].yPos == yPos + 1)
                        {
                            enemyIndex = i;
                            enemyContactEast = false;
                            enemyContactWest = false;
                            enemyContactNorth = true;
                            enemyContactSouth = false;
                          //  actionString = "you got the right enemy!         ";
                            CurrentEnemy = enemyList[i];

                        }
                    }
                

            }
            else if (mapArray[yPos - 1, xPos] == "e" || mapArray[yPos - 1, xPos] == "s" || mapArray[yPos - 1, xPos] == "w" || mapArray[yPos - 1, xPos] == "g" || mapArray[yPos - 1, xPos] == "t" || mapArray[yPos - 1, xPos] == "k" || mapArray[yPos - 1, xPos] == "r" || mapArray[yPos - 1, xPos] == "e")
            {

               // actionString = "south of you stands an enemy                ";
                enemyContact = true;
               
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        if (enemyList[i].xPos == xPos && enemyList[i].yPos == yPos - 1)
                        {
                            enemyIndex = i;
                            enemyContactEast = false;
                            enemyContactWest = false;
                            enemyContactNorth = false;
                            enemyContactSouth = true;
                        //    actionString = "you got the right enemy!                ";
                            CurrentEnemy = enemyList[i];

                        }
                    
                }

            }
            else
            {
                enemyContactEast = false;
                enemyContactWest = false;
                enemyContactNorth = false;
                enemyContactSouth = false;
                enemyContact = false;
            }



            floorString = mapArray[yPos, xPos];
            Console.SetCursorPosition(xPos, yPos);

            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
            //mapArray[yPos,xPos] = 

            //battle method

            if (enemyContact == true)
            {


               // Thread.Sleep(300);
                EnemyAttackFunction(enemyIndex);
                return;
            }
            return;
        }


        public void dealDamage()
        {
            //hit currentEnemy!
            CurrentEnemy.health -= dmg;
            CurrentEnemy.ready = true;
            actionString = "you hit "+CurrentEnemy.raceString;
            Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("●");  // blutstropfen 
            Thread.Sleep(100);
            Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(CurrentEnemy.raceLetter);

            if (CurrentEnemy.health < 1)
            {
                Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
                mapArray[CurrentEnemy.yPos, CurrentEnemy.xPos] = CurrentEnemy.floorString;
                actionString = "the enemy died                  ";
                Thread.Sleep(100);

                // give exp, coins and loot!
                int lootRoll = random.Next(0, 8); // 0 sticks, 1 ore, 2 herbs, 3 life potion, 4 magicpotion, 5 arrows, 6 bombs, 7 extra coins, 8 loot items
                int coinsGathered = random.Next(1, 25);
                coins += coinsGathered;
                if (lootRoll == 0)
                {
                    actionString = "you found sticks.";
                }
                if (lootRoll == 1)
                {
                    actionString = "you found iron ore.";
                }
                if (lootRoll == 2)
                {
                    actionString = "you found healing herbs.";
                }
                if (lootRoll == 3)
                {
                    actionString = "you found a life potion.";
                }
                if (lootRoll == 4)
                {
                    actionString = "you found a magic potion.";
                }
                if (lootRoll == 5)
                {
                    actionString = "you found arrows.";
                }
                if (lootRoll == 6)
                {
                    actionString = "you found bombs.";
                }
                if (lootRoll == 7)
                {
                    actionString = "you found extra coins.";
                }
                if (lootRoll == 8)
                {
                    actionString = "you found a weapon.";
                }

                CurrentEnemy = null;
            }
            else
            {
                actionString = "you deal [" + dmg + "] damage to an enemy       ";
            }
        }


        //*******************************************************************************************************************
        public void DrawPlayer()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // if the sword should be removed again, read pos from map string array..
          

            // for now only four classes!    if (equipmentInteger == 4) { item1 = "┲"; }


            Console.SetCursorPosition(xPos, yPos);
            if (equipmentInteger == 1) { item1 = "†"; Console.ForegroundColor = ConsoleColor.DarkGreen; }
            if (equipmentInteger == 0) { item1 = "←"; Console.ForegroundColor = ConsoleColor.Magenta; }
            if (equipmentInteger == 2) { item1 = "┲"; Console.ForegroundColor = ConsoleColor.DarkYellow; }
            if (equipmentInteger == 3) { item1 = "Ґ"; Console.ForegroundColor = ConsoleColor.DarkCyan; }
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;





            // firekit      @▲
            // magnet       @∩
            // discus       @○
            // shield       @■
            // bomb         @●       
            // bow          @)→
            // slingshot    @y  °
            // hookshot     @--->

            // life         ♥
            // treasure     □
            // ladder       #
            // fire         ▲

          



            if (attack == true)
            {
                //ॐ
                if (weaponGrade == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (weaponGrade == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (weaponGrade == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
               
                }

                


                // paint map new: mapArray[yPos, xPos]

                // ****** sword      @† ⚠  **********************************************************************************************************
                if (equipmentInteger == 1)
                {

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_sword.wav";
                    musicPlayer.Play();
                    int criticalDamage;
                    criticalDamage = random.Next(0, 3);
                    dmg = STR * CON / 10+criticalDamage;
                    actionString = "you swing your sword! [" + dmg + "] damage";
                    if (direction == "East")
                    {



                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("†");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);

                        attack = false;
                    }

                    else if (direction == "South")
                    {

                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("†");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);

                        attack = false;
                    }

                    else if (direction == "West")
                    {

                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("†");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(300);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);

                        attack = false;
                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("†");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);

                        attack = false;

                    }
                    
                    else
                    {

                    }

                    // withdraw health from enemy

                    if (enemyContact == true && CurrentEnemy != null)
                    {

                        dealDamage();


                    }

                }

                // ****** dagger      @†   **********************************************************************************************************
                if (equipmentInteger == 0)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                    musicPlayer.Play();
                    int criticalDamage;
                    criticalDamage = random.Next(0, 3);
                    dmg = DEX * STR / 10+criticalDamage;
                    actionString = "you stab with your daggers! [" + dmg + "] damage";

                    if (direction == "East")
                    {
                        

                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("←");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        attack = false;

                    }

                    else if (direction == "South")
                    {
                        
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("↑");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);

                        attack = false;
                    }

                    else if (direction == "West")
                    {
                       
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("→");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        attack = false;
                    }

                    else if (direction == "North")
                    {
                        

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("↓");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        attack = false;

                    }
                    else
                    {



                    }
                    // withdraw health from enemy

                    if (enemyContact == true && CurrentEnemy != null)
                    {

                        dealDamage();


                    }
                }

                // ****** warplow      @┲   **********************************************************************************************************
                if (equipmentInteger == 2)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_plow.wav";
                    musicPlayer.Play();
                    int criticalDamage;
                    criticalDamage = random.Next(0, 3);
                    dmg = INT * CON / 10+ criticalDamage;
                    actionString = "you swing your warplow! [" + dmg + "] damage";

                    if (direction == "East")
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("┮");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);

                        Console.Write(mapArray[yPos, xPos + 1]);
                        attack = false;
                        

                    }

                    else if (direction == "South")
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("┶");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);

                        Console.Write(mapArray[yPos + 1, xPos]);
                        attack = false;
                       

                    }

                    else if (direction == "West")
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("┭");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 1, yPos);

                        Console.Write(mapArray[yPos, xPos - 1]);
                        attack = false;
                        

                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("┭");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 1);

                        Console.Write(mapArray[yPos - 1, xPos]);
                        attack = false;
                        


                    }
                    else
                    {



                    }
                    // withdraw health from enemy

                    if (enemyContact == true && CurrentEnemy != null)
                    {

                        dealDamage();


                    }
                }



                // ****** staff      @Ґ☇   **********************************************************************************************************
                if (equipmentInteger == 3)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_staff.wav";
                    musicPlayer.Play();
                    int criticalDamage;
                    criticalDamage = random.Next(0, 3);
                    dmg = INT * DEX / 10+ criticalDamage;
                    actionString = "you trash with your staff! [" + dmg + "] damage";

                    if (direction == "East")
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("Ґ");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        attack = false;
                        


                    }

                    else if (direction == "South")
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("Ґ");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        attack = false;
                        
                        
                        }

                    else if (direction == "West")
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("Ґ");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        attack = false;
                        

                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("Ґ");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        attack = false;
                        

                    }
                    else
                    {
                     

                    }
                    // withdraw health from enemy

                    if (enemyContact == true && CurrentEnemy != null)
                    {

                        dealDamage();


                    }


                }





            }

            //*************************************************************************************************************************************

            //press enter!


            if (skillAttack == true && mana >=2)
            {



                //ॐ
                Console.ForegroundColor = ConsoleColor.Black;

                // paint map new: mapArray[yPos, xPos]

                // ****** sword      @← ⚠  **********************************************************************************************************
                if (equipmentInteger == 1)
                {
                    mana -= 2;
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_sword.wav";
                    musicPlayer.Play();

                    int criticalDamage;
                    criticalDamage = random.Next(0,STR);

                     dmg = 2*STR * CON / 10 + criticalDamage;
                    actionString = "heavy sword attack!! [" + dmg + "] damage";

                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write("†");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(100);
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos]);
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("†");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write("†");
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos]);
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write("†");
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos - 1]);

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_exp.wav";
                    musicPlayer.Play(); 


                    if (enemyContactEast || enemyContactSouth || enemyContactWest || enemyContactNorth)
                    {
                        //hit currentEnemy!
                        dealDamage();
                    }

                 


                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_exp.wav";
                    musicPlayer.Play();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

             /*       
                    */
                  

                    //*********************************************************************


                    Thread.Sleep(300);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);


                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);


                    /* */
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos]);



                    //1st row



                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);



                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos - 1]);
                    //2nd row



                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos]);

                    //3rd row

                    

                    

                    //******************************************************


                    skillAttack = false;


                }

                // ****** dagger      @←   **********************************************************************************************************
                if (equipmentInteger == 0)
                {
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    mana -= 4;
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                    musicPlayer.Play();

                    int criticalDamage;
                    criticalDamage = random.Next(0, DEX);

                    dmg = 3*DEX * STR / 10 + criticalDamage;
                    actionString = "you deliver a critical hit! [" + dmg + "] damage";
                    //Console.BackgroundColor = ConsoleColor.DarkRed;


                    if (direction == "East")
                    { //Norden
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("←");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);




                        if (weaponGrade == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (weaponGrade == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (weaponGrade == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        //Osten
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("↑");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("↑");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        
                    }

                    else if (direction == "South") 
                    {
                        //Osten
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("↑");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        if (weaponGrade == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (weaponGrade == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (weaponGrade == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        //Süden
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("→");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("→");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);

                        

                    }

                    else if (direction == "West")
                    {
                        //Süden
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("→");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        if (weaponGrade == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (weaponGrade == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (weaponGrade == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        //Westen 
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("↓");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("↓");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);

                        
                    }

                    else if (direction == "North")
                    {
                        //Westen 
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("↓");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        if (weaponGrade == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (weaponGrade == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (weaponGrade == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        //Norden
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("←");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("←");

                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);

                    }

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_hookshot.wav";
                    musicPlayer.Play();

                    if (enemyContactEast || enemyContactSouth || enemyContactWest || enemyContactNorth)
                    {

                        //hit currentEnemy!
                        dealDamage();
                    }
                    //*********************************************************************************************
                    
                    skillAttack = false;

                  

                }

                // ****** warplow      @┲   **********************************************************************************************************
                if (equipmentInteger == 2)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_plow.wav";
                    musicPlayer.Play();

                    int criticalDamage;
                    criticalDamage = random.Next(0, CON);
                    dmg = 2*CON * INT/10 + criticalDamage;
                    mana -= 2;

                    actionString = "you crush your foes! [" + dmg + "] damage";
                    //      Console.BackgroundColor = ConsoleColor.DarkYellow;

                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }


                    if (direction == "East")
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("┮");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("●");
                        Thread.Sleep(200);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("O");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);

                    }

                    else if (direction == "South")
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("┶");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos+1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("●");
                        Thread.Sleep(200);
                        Console.SetCursorPosition(xPos, yPos+1);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("O");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                    }

                    else if (direction == "West")
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("┭");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("●");
                        Thread.Sleep(200);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("O");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("┭");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("●");
                        Thread.Sleep(200);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("O");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);

                    }
                    else
                    {



                    }

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_exp.wav";
                    musicPlayer.Play();

                    if (enemyContactEast || enemyContactSouth || enemyContactWest || enemyContactNorth)
                    {
                        //hit currentEnemy!
                        dealDamage();
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;

                    Console.SetCursorPosition(xPos - 1, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos + 1, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    //
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    //
                    Console.SetCursorPosition(xPos - 1, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos + 1, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    //*********************************************************************


                    Thread.Sleep(300);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos + 1]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos]);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos - 1]);
                    //1st row



                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos - 1]);
                    //2nd row


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos + 1]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos - 1]);
                    //3rd row
                    skillAttack = false;

                }



                // ****** staff      @Ґ☇   **********************************************************************************************************
                if (equipmentInteger == 3)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_firekit.wav";
                    musicPlayer.Play();
                    int criticalDamage;
                    criticalDamage = random.Next(0, INT);
                    dmg = 2*INT * DEX / 10 + criticalDamage;
                    actionString = "you use your wand! [" + dmg + "] damage";
                    mana -= 2;

                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }





                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write("Ґ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(100);
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos]);
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write("Ґ");
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write("Ґ");
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos]);
                    if (weaponGrade == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (weaponGrade == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (weaponGrade == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write("Ґ");
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos - 1]);

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/skill_missile_exp.wav";
                    musicPlayer.Play();


                    if (enemyContactEast || enemyContactSouth || enemyContactWest || enemyContactNorth)
                    {
                        //hit currentEnemy!
                        dealDamage();
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;

                    Console.SetCursorPosition(xPos - 1, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos + 1, yPos - 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    //
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    //
                    Console.SetCursorPosition(xPos - 1, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    Console.SetCursorPosition(xPos + 1, yPos + 1);
                    Console.Write(mapArray[yPos, xPos + 1]);

                    //*********************************************************************


                    Thread.Sleep(300);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos + 1]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos]);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos - 1);
                    Console.Write(mapArray[yPos - 1, xPos - 1]);
                    //1st row



                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(mapArray[yPos, xPos + 1]);


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(mapArray[yPos, xPos - 1]);
                    //2nd row


                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos + 1, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos + 1]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(xPos - 1, yPos + 1);
                    Console.Write(mapArray[yPos + 1, xPos - 1]);
                    //3rd row
                    skillAttack = false;

                }



                

            }







            //**************************************************************************************************************************************

            if (use == true)
            {


                // display the various items! up make sure by pressing key 1-9, you can select equioment2integer!!

                // ****** magnet     @∩   **********************************************************************************************************
                if (equipment2Integer == 1 && hasMagnet)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_magnet.wav";
                    musicPlayer.Play();


                    actionString = "you use a magnet to attract metal!";

                    if (direction == "East")
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("∩");
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        use = false;
                    }

                    else if (direction == "South")
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("∩");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        use = false;
                    }

                    else if (direction == "West")
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("∩");
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        use = false;
                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("∩");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        use = false;

                    }


                }
                else
                {

                }


                //)→
                // ****** bow and arrow @)→  **********************************************************************************************************
                if (equipment2Integer == 2 && hasDiscus)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_discus.wav";
                    musicPlayer.Play();
                    //mapArray[yPos, xPos]    for the char on tile x/y



                    if (direction == "East" && xPos < mapArray.GetLength(1) - 4)
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("⁔");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        // only use if distance from screen is far enough (3 fields N and S, 4 fields East and West)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("●");
                        Thread.Sleep(300);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos, xPos + 1]);
                        Console.SetCursorPosition(xPos + 2, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 2, yPos);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos, xPos + 2]);
                        Console.SetCursorPosition(xPos + 3, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 3, yPos);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos, xPos + 3]);
                        Console.SetCursorPosition(xPos + 4, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 4, yPos);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos, xPos + 3]);


                        skillAttack = false;
                    }

                    else if (direction == "East" && xPos > mapArray.GetLength(1) - 4)
                    {
                        actionString = "you cannot shoot or it could ricojet";
                        skillAttack = false;
                    }


                    else if (direction == "South" && yPos < mapArray.GetLength(0) - 4)
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("Ґ");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 2);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos + 2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos + 2, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 3);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 3);
                        Console.Write(mapArray[yPos + 3, xPos]);
                        skillAttack = false;
                    }
                    else if (direction == "South" && yPos > mapArray.GetLength(0) - 4)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        skillAttack = false;
                    }

                    else if (direction == "West" && xPos > 4)
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("Ґ");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        attack = false;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(300);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos - 1, xPos]);
                        Console.SetCursorPosition(xPos - 2, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 2, yPos);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos - 2, xPos]);
                        Console.SetCursorPosition(xPos - 3, yPos);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 3, yPos);
                        Console.Write(mapArray[yPos - 3, xPos]);



                        skillAttack = false;
                    }
                    else if (direction == "West" && xPos < 4)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        skillAttack = false;
                    }

                    else if (direction == "North" && yPos > 45)
                    {
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("Ґ");
                        Console.SetCursorPosition(xPos, yPos);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos - 1, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 2);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(mapArray[yPos - 2, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 3);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("●");
                        Thread.Sleep(100);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 3);
                        Console.Write(mapArray[yPos - 3, xPos]);

                        skillAttack = false;

                    }
                    else if (direction == "North" && yPos < 4)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        skillAttack = false;
                    }


                }
                else
                {

                }


                // ****** discus     @○   **********************************************************************************************************
                if (equipment2Integer == 2 && hasDiscus)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_discus.wav";
                    musicPlayer.Play();
                    //mapArray[yPos, xPos]    for the char on tile x/y



                    if (direction == "East" && xPos < mapArray.GetLength(1) - 4)
                    {
                        // only use if distance from screen is far enough (3 fields N and S, 4 fields East and West)

                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);

                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        Console.SetCursorPosition(xPos + 2, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);

                        Console.SetCursorPosition(xPos + 2, yPos);
                        Console.Write(mapArray[yPos, xPos + 2]);
                        Console.SetCursorPosition(xPos + 3, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 3, yPos);
                        Console.Write(mapArray[yPos, xPos + 3]);
                        Console.SetCursorPosition(xPos + 4, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 4, yPos);
                        Console.Write(mapArray[yPos, xPos + 4]);
                        Console.SetCursorPosition(xPos + 3, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 3, yPos);
                        Console.Write(mapArray[yPos, xPos + 3]);
                        Console.SetCursorPosition(xPos + 2, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 2, yPos);
                        Console.Write(mapArray[yPos, xPos + 2]);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        use = false;
                    }

                    else if (direction == "East" && xPos > mapArray.GetLength(1) - 4)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        use = false;
                    }


                    else if (direction == "South" && yPos < mapArray.GetLength(0) - 4)
                    {


                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 2);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos + 2);
                        Console.Write(mapArray[yPos + 2, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 3);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos + 3);
                        Console.Write(mapArray[yPos + 3, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 2);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos + 2);
                        Console.Write(mapArray[yPos + 2, xPos]);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);

                        use = false;
                    }
                    else if (direction == "South" && yPos > mapArray.GetLength(0) - 4)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        use = false;
                    }

                    else if (direction == "West" && xPos > 5)
                    {

                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        Console.SetCursorPosition(xPos - 2, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 2, yPos);
                        Console.Write(mapArray[yPos - 2, xPos]);
                        Console.SetCursorPosition(xPos - 3, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 3, yPos);
                        Console.Write(mapArray[yPos - 3, xPos]);
                        Console.SetCursorPosition(xPos - 4, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 4, yPos);
                        Console.Write(mapArray[yPos - 4, xPos]);
                        Console.SetCursorPosition(xPos - 3, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 3, yPos);
                        Console.Write(mapArray[yPos - 3, xPos]);
                        Console.SetCursorPosition(xPos - 2, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 2, yPos);
                        Console.Write(mapArray[yPos - 2, xPos]);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        use = false;
                    }
                    else if (direction == "West" && xPos < 5)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        use = false;
                    }

                    else if (direction == "North" && yPos > 5)
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 2);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 2);
                        Console.Write(mapArray[yPos - 2, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 3);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 3);
                        Console.Write(mapArray[yPos - 3, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 2);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 2);
                        Console.Write(mapArray[yPos - 2, xPos]);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("○");
                        Thread.Sleep(100);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        use = false;

                    }
                    else if (direction == "North" && yPos < 5)
                    {
                        actionString = "you cannot throw the discus too close to wall";
                        use = false;
                    }



                }
                else
                {

                }
                // ****** shield     @■◊◆   **********************************************************************************************************
                if (equipment2Integer == 3 && hasShield)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_shield.wav";
                    musicPlayer.Play();
                    actionString = "you use a shield to repell attacks!";

                    if (direction == "East")
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write("■");
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        use = false;
                    }

                    else if (direction == "South")
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write("■");
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        use = false;
                    }

                    else if (direction == "West")
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write("■");
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        use = false;
                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write("■");
                        Thread.Sleep(700);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        use = false;

                    }


                }
                else
                {

                }




                // ****** bow n arrow @)-    ()⁀‿

                // ****** firekit      @▲   **********************************************************************************************************
                if (equipment2Integer == 0 && hasFire)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_firekit.wav";
                    musicPlayer.Play();
                    actionString = "you use a striker to create fire!";

                    if (direction == "East")
                    {
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▲");
                        Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(400);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);
                        use = false;
                    }

                    else if (direction == "South")
                    {
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▲");
                        Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(400);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                        use = false;
                    }

                    else if (direction == "West")
                    {
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▲");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(400);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                        use = false;
                    }

                    else if (direction == "North")
                    {

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("▲");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(400);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);
                        use = false;

                    }
                    else
                    {

                    }



                    // we wanna use items and do stuff with them!

                    // burn wood [≡] with the firekit
                    if (mapArray[yPos, xPos] == "≡")
                    {
                        Console.SetCursorPosition(xPos, yPos - 1);
                        burnWood(xPos, yPos - 1);
                        burnCounter++;


                    }




                }

                else
                {
                   /* if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                    else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                    else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;*/
                }



            }
            else
            {
                if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
                else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // if you stand on a heart, remove it and add health to max!
            if (mapArray[yPos, xPos] == "♥")
            {




                getHeart(xPos, yPos - 1);


            }

            // open treasure box
            else if (mapArray[yPos, xPos] == "□")
            {
                Console.SetCursorPosition(xPos, yPos - 1);
                giveTreasureItem(xPos, yPos - 1);


            }
            
            // activate lever
            else if (mapArray[yPos, xPos] == "┖")
            {
                Console.SetCursorPosition(xPos, yPos - 1);
                giveLadder(xPos, yPos-1);
            }


        }


        // in every dungeon there is loot to find ;D

        public void giveTreasureItem(int x, int y)
        {
            actionString = "you opened a treasure box!!";
            Thread.Sleep(300);
            //check which maparray - are we in lvl 1, 2, 3?
            Map map = new Map();
            //if we are in dungeon 1a, earth shrine, the treasure gives firetool
            if (level == 1)
            {
                // give firekit
                actionString = "you are given an archaic firetool!";
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("▲");
                hasFire = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(mapArray[y, x]);
                //Thread.Sleep(1000);
                actionString = "you are given an archaic firetool!                 ";
            }



            //if we are in dungeon  2, water temple, the treasure gives magnet
            if (level == 12)
            {
                //give magnet
                actionString = "you are given a powerful magnet!!";
            }
            //in level 3, air temple, it gives bow and arrow
            if (mapArray == map.map3Array)
            {

            }
            //in level 4 it gives discus
            if (mapArray == map.map4Array)
            {

            }
            //in level 5 it gives bombs
            if (mapArray == map.map5Array)
            {

            }
        }


        public void burnWood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▲");
            Console.ForegroundColor = ConsoleColor.White;
            actionString = "you burn a pile of wood!                 ";

        }

        public void replaceMapPic(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("⁃");
            actionString = "we replaced the map image!                 ";

        }

        public void giveLadder(int x, int y)
        {
            if (map.mapArray == map.map1Array)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("#");
                mapArray[y, x] = "#";
                actionString = "a ladder [#] appeared!                 ";
            }

           /* else if (map.mapArray == map.map2Array)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
                actionString = "a ladder [#] appeared!                 ";
            }*/
        }
        public void coverLadder(int x, int y)
        {
            if (level == 1)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("⁃");
                //actionString = "a ladder [#] appeared!                 ";
            }
            else if (level == 2)
            {
                Console.SetCursorPosition(x, y);
                //Console.Write("⁃");
                //actionString = "a ladder [#] appeared!                 ";
            }
        }
        public void destroyLadder(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            //actionString = "a ladder [#] appeared!                 ";

        }


        public void getHeart(int x, int y)
        {


            //write a red ♥ over your player!
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥");
            Console.ForegroundColor = ConsoleColor.White;
            life++;
            //override the red heart with a wall
            Thread.Sleep(600);
            Console.SetCursorPosition(x, y);
            Console.Write(mapArray[yPos - 1, xPos]);
            Console.ForegroundColor = ConsoleColor.White;

            //remove the heart symbol from the map override with ⁃!

            replaceMapImage = true;
        }


        // health and compass!
        public void UpdateDirection()
        {
            int xPos = 0;
            int yPos = mapArray.GetLength(0) + 1;
            



                //Console.BackgroundColor = ConsoleColor.Black;
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.ResetColor();







                Console.SetCursorPosition(xPos + 25, yPos + 3);
                Console.Write("                     "); // Alte Richtung löschen, mit Leerschlag überschreiben
                Console.Write(actionString + "           ");  // was machst du?


            /*    Console.SetCursorPosition(xPos + 25, yPos + 6);
                Console.Write("                     "); // Alte Richtung löschen, mit Leerschlag überschreiben
                Console.Write("next turn [enter] " + fieldsWalked + "/5");  // was machst du?
                */


            




        }

        public void UpdateStats()
        {

            // xPos can be maparray.getlength!!

            int xPos = 60;
            int yPos = 1;

            

            Console.SetCursorPosition(xPos, yPos);
            Console.Write("STR      " + STR);
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("CON      " + CON);
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("DEX      " + DEX);
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("INT      " + INT);
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" ");
            yPos++;




            Console.SetCursorPosition(xPos, yPos);
            Console.Write("weapon [space] " + item1);
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            if (equipmentInteger == 1) { Console.Write("skill [enter] " + item1); }
            if (equipmentInteger == 0) { Console.Write("skill [enter] " + item1); }
            if (equipmentInteger == 2) { Console.Write("skill [enter] " + item1); }
            if (equipmentInteger == 3) { Console.Write("skill [enter] " + item1); }

            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("item [e] " + item2);
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("walk [wasd]");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" ");
            yPos++;




            // only show these if the player found the required item (itemBool = true)

            // firekit      @▲
            // magnet       @∩
            // discus       @○
            // shield       @■
            // bomb         @●       
            // bow          @)→
            // hookshot     @--->

            // life         ♥
            // treasure     □
            // ladder       #
            // fire         ▲

/*
            if (hasFire)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("firekit [1] ▲");
                yPos++;
            }

           else
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write(" 1");
                yPos++;
            }

            if (hasMagnet)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("magnet [2] ∩");
                yPos++;
            }

            if (hasDiscus)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("discus [3] ○");
                yPos++;
            }

            if (hasShield)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("shield [4] ■");
                yPos++;
            }



            if (hasBomb)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("bomb [5] ●");
                yPos++;
            }

            if (hasBow)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("bow [6] )→");
                yPos++;
            }

            else
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write(" ");
                yPos++;
            }

                if (hasHookshot)
            {
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("rope [7] --->");
                yPos++;
            }
            */


            Console.SetCursorPosition(xPos, yPos);
            Console.Write("coins");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" ♦ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(+ coins);

            Console.SetCursorPosition(xPos, yPos+1);
            Console.Write("life ") ;
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write(" ♥ ");
            for (int i = 0; i < life; i++)
            {
                if (i < health)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("♥ ");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(" ");  // wieviel leben hast du?
                }
            }


            //Console.SetCursorPosition(xPos, yPos);
            //Console.Write(burnCounter);
            //yPos++;

            yPos++;
            yPos++;
            yPos++;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(xPos, yPos);

            //    << minimap >>  ****************************************************************************************************************
      

            for (int y = 1; y <9;y++)
            {
                for (int x = 1; x < 9; x++)
                {
                    if (x < 9)
                    {
                        
                        if (x == xCoordinates && y == yCoordinates)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(xCoordinates+""+yCoordinates+" ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(x+""+y+",");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            
                        }
                        if (x == 8)
                        {
                            yPos++;
                            Console.SetCursorPosition(xPos, yPos);
                            //y++;
                        }
                    }
                }

                

            }

            yPos++;
            /*
            Console.Write("┌────────────────┐");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("│ A2,B2,C2,D2,E2 │");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("│ A3,B3,C3,D3,E3 │");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("│ A3,B4,C4,D4,E4 │");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("│ A4,B5,C5,D5,E5 │");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("│ A6,B6,C6,D6,E6 │");
            yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("└────────────────┘");
            yPos++;*/

            //**********************************************************************************************************************************
            Console.SetCursorPosition(xPos, yPos);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // other parts of interface
            xPos = 0;
            yPos = mapArray.GetLength(0) + 2;

            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            yPos++;
            Console.Write("                               "); // Alte Richtung löschen, mit Leerschlag überschreiben
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" level " + xCoordinates + "/" + yCoordinates + ", compass: " + direction);  // neue Richtungsangabe
            Console.Write("                               ");

            //for each life u got, for loop and write "█"
            Console.SetCursorPosition(xPos, yPos + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ♥ ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(health + "/" + maxHealth + " ");

            for (int i = 0; i < 25; i++)
            {
                if (i < health)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("▄");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            //for each life u got, for loop and write "█"
            Console.SetCursorPosition(xPos, yPos + 3);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" ▲ ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(mana + "/" + maxMana + " ");

            for (int i = 0; i < maxMana; i++)
            {
                if (i < mana)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("▄");  // wieviel mana hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("▄");  // wieviel mana hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            


        }

        public bool playerDied()
        {
            if (health <=0)
            {
                return true;
            }
            return false;
        }


        //*************** doors 1-6 *******************************************************************************


        //turn into an enum...
       /* public enum GameState
        {
            door1,
            door2,
            door3,
            door4,
            door5,
            door6,
            outside
        }*/

        public bool enterDoor()        //open doors
        {
            if (mapArray[yPos, xPos] == "1")
            {
                actionString = "you open door 1";
                return true;
            }
            return false;
        }

        public bool enterDoor2()        //open doors
        {
            if (mapArray[yPos, xPos] == "2")
            {
                actionString = "you open door 2";
                return true;
            }
            return false;
        }

        public bool enterDoor3()        //open doors
        {
            if (mapArray[yPos, xPos] == "3")
            {
                actionString = "you open door 3";
                return true;
            }
            return false;
        }

        public bool enterDoor4()        //open doors
        {
            if (mapArray[yPos, xPos] == "4")
            {
                actionString = "you open door 4";
                
                return true;
            }
            return false;
        }

        public bool enterDoor5()        //open doors
        {
            if (mapArray[yPos, xPos] == "5")
            {
                actionString = "you open door 5";
             
                return true;
            }
            return false;
        }

        public bool enterDoor6()        //open doors
        {
            if (mapArray[yPos, xPos] == "6")
            {
                actionString = "you open door 6";
                
                return true;
            }
            return false;
        }

        //*************** portals  ▼ ► ◄ ▲ *******************************************************************************

        public bool travelEast()        //enchanted forests
        {
            if (mapArray[yPos, xPos] == "◄")
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel east " + (xCoordinates +1)+ "/" + yCoordinates;
            //    xCoordinates++;
                return true;
            }
            return false;
        }

        public bool travelSouth()       // a scorching sun in the desert!
        {
            if (mapArray[yPos, xPos] == "▼")
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel south " + xCoordinates + "/" + (yCoordinates - 1);
           //     yCoordinates++;
                return true;
            }
            return false;
        }

        public bool travelWest()        // land of the stormy winds!
        {
            if (mapArray[yPos, xPos] == "►")
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel west "+ (xCoordinates-1) + "/"+yCoordinates;
            //    xCoordinates--;
                return true;
            }
            return false;
        }

        public bool travelNorth()       //massive mountains and mystical caves!
        {
            if (mapArray[yPos, xPos] == "▲")
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel north " + xCoordinates + "/" + (yCoordinates + 1);
                //   yCoordinates--;
                return true;
            }
            return false;
        }


       


        //*************** ladders in dungeons *******************************************************************************

        public bool CheckForLadder()
        {
            if (mapArray[yPos, xPos] == "#")
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                return true;
            }
            return false;
        }
        //*************** enemies on the map *******************************************************************************


        public void populateLevels(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                string myFloor;
                string enemyRace = "e";
                int enemyRaceInt = 0;
                Random random = new Random();
                enemyRaceInt = random.Next(0, 6);

                int xpos;
                int ypos;
                xpos = random.Next(4, 55);
                ypos = random.Next(7, 18);

                Enemy myEnemy = new Enemy(enemyRaceInt, xpos, ypos);

                //enum
                if (enemyRaceInt == 0) { enemyRace = "s"; enemyList.Add(myEnemy); myEnemy.raceInt = 0;  }   //this is a snake
                else if (enemyRaceInt == 1) { enemyRace = "w"; enemyList.Add(myEnemy); myEnemy.raceInt = 1;  }   //this is a wolf
                else if (enemyRaceInt == 2) { enemyRace = "g"; enemyList.Add(myEnemy); myEnemy.raceInt = 2;  }   //this is a goblin
                else if (enemyRaceInt == 3) { enemyRace = "t"; enemyList.Add(myEnemy); myEnemy.raceInt = 3;  }   //this is a troll
                else if (enemyRaceInt == 4) { enemyRace = "k"; enemyList.Add(myEnemy); myEnemy.raceInt = 4; }   //this is a knight
                else if (enemyRaceInt == 5) { enemyRace = "r"; enemyList.Add(myEnemy); myEnemy.raceInt = 5; }   //this is a rogue
                else if (enemyRaceInt == 6) { enemyRace = "e"; enemyList.Add(myEnemy); myEnemy.raceInt = 6; }   //this is an enchanter

                myEnemy.raceLetter = enemyRace;
                //else if (enemyRaceInt == 4) { enemyRace = "o"; }   //this is a ork

                myEnemy.xPos = xpos;
                myEnemy.yPos = ypos;


                
                    //enemy.raceInt = enemyNumbers;
                    myFloor = mapArray[ypos, xpos];
                    myEnemy.floorString = myFloor;
                    UpdateEnemy(xpos, ypos, myFloor, enemyRace);

                    //setupEnemy(xpos, ypos, mapArray[xpos, ypos]);
                    enemyRaceInt = random.Next(0, 3);
           

                i++;
            }
           
        }

        public void UpdateEnemy(int x, int y, string floor, string enemy)
        {
            // on the maparray we write "e", on the console itself we write enemy string ("g", "s",..)

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetCursorPosition(x, y); //Erst an Position Löschen
            Console.SetCursorPosition(x, y); //Erst an Position Löschen


            //*** select movement **********************************************************************************************************************************
            int movementInt = random.Next(0, 3);
            Thread.Sleep(100);

            Console.SetCursorPosition(x, y); //Erst an Position Löschen
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(enemy);
            mapArray[y, x] = enemy;
            Console.ForegroundColor = ConsoleColor.White;

            //*** attack player ************************************************************************************************************************************

            

            //battle method
            if (enemyContact == true)
            {
                //

                
               
                EnemyAttackFunction(enemyIndex);
            }
            else
            {
                //moveEnemy(x, y, floor, enemy);
            }
        }

        //**********************************************************************************************************************************************

       



        public void moveEnemy(int x, int y, string floor, string enemy)
        {

            int movementInt = random.Next(0, 3);
            Thread.Sleep(100);
/*
            //move east
            if (movementInt == 0 && mapArray[y, x + 1] != "█" && mapArray[yPos, xPos + 1] != "▒")
            {
                Console.SetCursorPosition(x+1, y); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y, x + 1] = enemy;

            }
            //move south
            else if (movementInt == 1 && mapArray[y + 1, x] != "█" && mapArray[yPos + 1, xPos] != "▒")
            {
                Console.SetCursorPosition(x, y+1); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y + 1, x] = enemy;
            }
            //move west
            else if (movementInt == 2 && mapArray[y, x - 1] != "█" && mapArray[yPos, xPos - 1] != "▒")
            {
                Console.SetCursorPosition(x - 1, y); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y, x - 1] = enemy;

            }
            //move north
            else if (movementInt == 3 && mapArray[y - 1, x] != "█" && mapArray[yPos - 1, xPos] != "▒")
            {
                Console.SetCursorPosition(x, y-1); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y - 1, x] = enemy;

            }

            else
            {
                return;
            }
            */


            
            //move east
            if (movementInt == 0 && mapArray[y, x + 1] != "█" && mapArray[yPos, xPos + 1] != "▒")
            {
                
                //replace floor with old floor! maparray y,x!!
                mapArray[y, x] = floor;
                Console.ForegroundColor = ConsoleColor.White;
                //replace console character with floor image
                Console.SetCursorPosition(x, y);
                Console.Write(mapArray[y, x]);
                Console.SetCursorPosition(x + 1, y); //write on new tile
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y, x + 1] = enemy;
                Console.Write(enemy);
                mapArray[y, x] = enemy;
                Thread.Sleep(200);
                x += x;
                return;
            }
            //move south
            else if (movementInt == 1 && mapArray[y + 1, x] != "█" && mapArray[yPos + 1, xPos] != "▒")
            {
                
                //replace floor with old floor! maparray y,x!!
                mapArray[y, x] = floor;
                Console.ForegroundColor = ConsoleColor.White;
                //replace console character with floor image
                Console.SetCursorPosition(x, y);
                Console.Write(mapArray[y, x]);
                Console.SetCursorPosition(x, y + 1); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y + 1, x] = enemy;
                Console.Write(enemy);
                mapArray[y, x] = enemy;
                Thread.Sleep(200);
                y += 1;
                return;
            }
            //move west
            else if (movementInt == 2 && mapArray[y, x - 1] != "█" && mapArray[yPos, xPos - 1] != "▒")
            {
                
                //replace floor with old floor! maparray y,x!!
                mapArray[y, x] = floor;
                Console.ForegroundColor = ConsoleColor.White;
                //replace console character with floor image
                Console.SetCursorPosition(x, y);
                Console.Write(mapArray[y, x]);
                Console.SetCursorPosition(x - 1, y); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y, x + 1] = enemy;
                Console.Write(enemy);
                mapArray[y, x] = enemy;
                Thread.Sleep(200);
                x -= x;
                return;
            }
            //move north
            else if (movementInt == 3 && mapArray[y - 1, x] != "█" && mapArray[yPos - 1, xPos] != "▒")
            {
                
                //replace floor with old floor! maparray y,x!!
                mapArray[y, x] = floor;
                Console.ForegroundColor = ConsoleColor.White;
                //replace console character with floor image
                Console.SetCursorPosition(x, y);
                Console.Write(mapArray[y, x]);
                Console.SetCursorPosition(x, y - 1); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y - 1, x] = enemy;
                Console.Write(enemy);
                mapArray[y, x] = enemy;
                Thread.Sleep(200);

                y -= y;
                return;
            }

            else
            {
                Console.SetCursorPosition(x, y); //Erst an Position Löschen
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(enemy);
                mapArray[y, x] = enemy;
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(200);
            }


            //move to next tile!
        }

        public void EnemyAttackFunction(int i)
        {
            if (health >= 1 && enemyList[i].ready == true)
            {
            currentEnemy = enemyList[i];
            int enemySTR = enemyList[i].STR;
            int enemyCON = enemyList[i].CON;
            int enemyDEX = enemyList[i].DEX;
            int enemyINT = enemyList[i].INT;
            int enemyRaceInt = enemyList[i].raceInt;

                Thread.Sleep(250);
            Console.SetCursorPosition(xPos, yPos);
            currentEnemy.targetPosX = xPos;
            currentEnemy.targetPosY = yPos;
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_mace.wav";
                musicPlayer.Play();
            // Thread.Sleep(200);

            //int enemyDamage = random.Next (1, currentEnemy.dmg);

            if (enemyRaceInt == 0)
            {
                actionString = "a snake attacks you! " + currentEnemy.dmg + "/" + currentEnemy.health + ")                       ";
            }
            else if (enemyRaceInt == 1)
            {
                actionString = "a wolf attacks you! (" + currentEnemy.dmg + "/"+ currentEnemy.health+")            ";
            }
            else if (enemyRaceInt == 2)
            {
                actionString = "a goblin attacks you! " + currentEnemy.dmg + "/" + currentEnemy.health + ")             ";
            }
            else if (enemyRaceInt == 3)
            {
                actionString = "a troll attacks you! " + currentEnemy.dmg + "/" + currentEnemy.health + ")      ";
            }
                else if (enemyRaceInt == 4)
                {
                    actionString = "a knight attacks you! " + currentEnemy.dmg + "/" + currentEnemy.health + ")               ";
                }
                else if (enemyRaceInt == 5)
                {
                    actionString = "a rogue attacks you! " + currentEnemy.dmg + "/" + currentEnemy.health + ")                 ";
                }
                else if (enemyRaceInt == 6)
                {
                    actionString = "an enchanter attacks you! " + currentEnemy.dmg + "/" + currentEnemy.health + ")             ";
                }



                //battle method
                if (enemyContact == true)

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(currentEnemy.attackString);  // angriffbildchen? 

                    currentEnemy.ready = false;
                    Thread.Sleep(400);
                    health -= currentEnemy.dmg;
                    enemyList[i].attack(health);
                    Thread.Sleep(200);

            }
            }
            

        }




        /*  public void enemyAttack(int x, int y)
          {
              musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_sword.wav";
              musicPlayer.Play();

              enemyContact = true;
              actionString = "this enemy wants to attack you!";
              Console.SetCursorPosition(x, y); //Erst an Position Löschen

              //enemyList[enemyIndex];  //this is your enemy
              int enemyIndex; //which enemy in the array stands on coordinates x/y??

              //Console.SetCursorPosition(x,y);
              Console.ForegroundColor = ConsoleColor.Red;
              Console.Write("X");  // wieviel leben hast du?
              Console.ForegroundColor = ConsoleColor.White;
              Thread.Sleep(200);
              if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
              else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Green; }
              else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
              else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
              Console.Write("@");  // wieviel leben hast du?
              Console.ForegroundColor = ConsoleColor.White;
          }*/



    }

