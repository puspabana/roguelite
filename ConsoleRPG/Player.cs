using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

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
        public int race =0;
        public int Class=0;

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

        public List<string> inventory = new List<string>();  //the ints here are itemIDs!

        public int weaponDMG;
        public int weaponDEF;

        private Item equippedPrimary = new Item();
        private Item equippedOffhand = new Item();
        List<Item> eqList = new List<Item>();

        List<Enemy> enemyList = new List<Enemy>();
        List<rogueLike.NPC> npcList = new List<rogueLike.NPC>();

        public bool equipNow = false;

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
        public bool indoors = false;

        bool attack = false;
        bool skillAttack = false;

        bool use = false;
        public Map map;
        bool enemyContact = false;
        public Random random = new Random();
        
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

        public int exp = 0;
        public int requiredExp = 50;
        public int lvl = 1;
        private bool lvlUp = false;


        private bool displayInventory = false;
        public int selectedItem = 0;

        internal Enemy CurrentEnemy { get => currentEnemy; set => currentEnemy = value; }
        internal Item EquippedPrimary { get => equippedPrimary; set => equippedPrimary = value; }
        internal Item EquippedOffhand { get => equippedPrimary; set => equippedPrimary = value; }



        public int doorCounter;
        private string enemyFloorString = " ";
        private int attackedFloorX = 0;
        private int attackedFloorY = 0;


        public int itemID = 0;




        public Player(string[,] MapArray)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            mapArray = MapArray;
            map = new Map();

            
        }

        public void generateHerbs()
        {
            string itemName = " ";
            int number = random.Next(1, 8);
            int SubType = random.Next(0, 13);
            int price = 5;
            if (SubType == 0) { itemName = "dill"; price = 3; }
            else if (SubType == 1) { itemName = "ginger"; price = 4; }
            else if (SubType == 2) { itemName = "mandrake"; price = 15; }
            else if (SubType == 3) { itemName = "sanjeevani"; price = 150; }
            else if (SubType == 4) { itemName = "basil"; price = 5; }
            else if (SubType == 5) { itemName = "thyme"; price = 6; }
            else if (SubType == 6) { itemName = "Coriander"; price = 6; }
            else if (SubType == 7) { itemName = "marihuana"; price = 6; }
            else if (SubType == 8) { itemName = "mushroom"; price = 6; }
            else if (SubType == 9) { itemName = "thistle"; price = 6; }
            else if (SubType == 10) { itemName = "turmeric"; price = 6; }
            else if (SubType == 11) { itemName = "rosemary"; price = 6; }
            else if (SubType == 12) { itemName = "sage"; price = 6; }
            else if (SubType == 13) { itemName = "sandalwood"; price = 6; }
        
        //now declare what you have found to the player
                itemName = number+"*"+itemName;
                inventory.Add(itemName);
                Item item = new Item(itemName, price, 3,0 ,".", 5);
                eqList.Add(item);
                actionString = "you found " + number + " * " + itemName + ". (" + itemID + " ID) ";
        }
        public void generateWood()
        {
            string itemName = " ";
            int number = random.Next(1, 8);
            int price = 5;
            int SubType = random.Next(0, 5);
            if (SubType == 0) { itemName = "ebony wood"; price = 45; }
            else if (SubType == 1) { itemName = "hazel wood"; price = 25; }
            else if (SubType == 2) { itemName = "acacia wood"; price = 15; }
            else if (SubType == 3) { itemName = "cedar wood"; price = 22; }
            else if (SubType == 4) { itemName = "ash wood"; price = 15; }
            else if (SubType == 5) { itemName = "oak wood"; price = 35; }

            //now declare what you have found to the player
            


            itemName = number + "*" + itemName;
            inventory.Add(itemName);

            Item item2 = new Item(itemName, price, 3,0, ".", 2);
            eqList.Add(item2);
            actionString = "you found " + number + " * " + itemName + ". (" + itemID + " ID) ";
        }

        public void generateStarterItem()
        {
            //deactive the function below if the player is loaded from playerprefs!
            Random random = new Random();
            string ItemName = "";
            int price = random.Next(1, 25);
            float DMG = random.Next(2, price / (5) + 3);
            float DEF = random.Next(0, price / (5));
            float extraMana = random.Next(0, price / (4));
            string itemIcon = "";
            int SubType = 0;

            //generate a unique starter dagger!
            if (equipmentInteger == 0)
            {
                //add a sword to your character!
               

                SubType = random.Next(0, 4);
                if (SubType == 0) { ItemName = "stiletto"; itemIcon = "←"; }
                else if (SubType == 1) { ItemName = "sai fork"; itemIcon = "ψ"; }
                else if (SubType == 2) { ItemName = "pushdagger"; itemIcon = "Џ"; }
                else if (SubType > 2) { ItemName = "dagger"; itemIcon = "ƭ"; }

            }
            //generate a unique starter sword!
            else if (equipmentInteger == 1)
            {
                //add a sword to your character!
               

                 SubType = random.Next(0, 6);
                if (SubType == 0) { ItemName = "longswords"; itemIcon = "†"; }
                else if (SubType == 1) { ItemName = "kodachi"; itemIcon = "Ϯ"; }
                else if (SubType == 2) { ItemName = "katana"; itemIcon = "ϯ"; }
                else if (SubType == 3) { ItemName = "sabre"; itemIcon = "ƪ"; }
                else if (SubType == 4) { ItemName = "battleaxe"; itemIcon = "ȹ"; }
                else if (SubType > 4) { ItemName = "tomahawk"; itemIcon = "ͳ"; }

            }
            //generate a unique starter mace!
            else if (equipmentInteger == 2)
            {
                //add a sword to your character!
                

                 SubType = random.Next(0, 6);
                if (SubType == 0) { ItemName = "warhammer"; itemIcon = "┮"; }
                else if (SubType == 1) { ItemName = "mace"; itemIcon = "ϙ"; }
                else if (SubType == 2) { ItemName = "morningstar"; itemIcon = "✶"; }
                else if (SubType == 3) { ItemName = "warplough"; itemIcon = "Ƭ"; }//ӷ
                else if (SubType == 4) { ItemName =  "halberd"; itemIcon = "ŧ"; }
                else if (SubType > 4) { ItemName = "cleaver"; itemIcon = "Ƿ"; }
                


            }
            //generate a unique starter staff!
            else if (equipmentInteger == 3)
            {
                //add a sword to your character!
                

                 SubType = random.Next(0, 4); if (SubType == 0) { ItemName = "rod"; itemIcon = "/"; }
                else if (SubType == 1) { ItemName = "warstaff"; itemIcon = "Ґ"; }
                else if (SubType == 2) { ItemName = "shamanstaff"; itemIcon = "ϡ"; }
                else if (SubType == 3) { ItemName = "sprig"; itemIcon = "Ԇ"; }
                else if (SubType == 4) { ItemName = "trident"; itemIcon = "Ψ"; }


            }

            //later generate weapon:item and so on up there!
            ItemName = ItemName + " (" + itemIcon + ") " + DMG + "/" + DEF;

            Item item = new Item(ItemName, price, 0, equipmentInteger, itemIcon, SubType);
            EquippedPrimary = item;
            equipItem(itemIcon, (int)DMG, (int)DEF, item.itemDefiningType);

            inventory.Add(ItemName);
            eqList.Add(item);
        }


        public void die()
        {
            Thread.Sleep(1000);
            // life -= 1;
            // actionString = "You just died";
            // riddleSolved = false;
            // Map lvl = new Map();
        }

        
        private void levelUp()
        {
           
            exp = 0;
            lvl ++;
            if (lvlUp == false)
            {
                    if (equipmentInteger == 0) { STR++; DEX++; DEX++; maxMana++; maxHealth++; requiredExp +=15; }//rogue gets dex and str
                    else if (equipmentInteger == 1) { STR++; STR++; CON++; maxMana++; maxHealth++; requiredExp += 15; }//attacker gets str and con
                    else if (equipmentInteger == 2) { STR++; CON++; CON++; maxMana++; maxHealth++; requiredExp += 15; }//priest gets con and str
                    else if (equipmentInteger == 3) { INT++; INT++; DEX++; maxMana++; maxHealth++; requiredExp += 15; }//enchanter gets dex and int
                    mana = maxMana; health = maxHealth;
                    //seems saver to add reqExp like this:
                    


                    lvlUp = true;

            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/01_character_creation.wav";
            musicPlayer.Play();
            }

            lvlUp = false;
            return;
            
        }
        public void UpdatePlayer()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.SetWindowSize(90,30);
            Console.SetCursorPosition(xPos, yPos);
           
            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }

            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;

            // let us use the equipped items!!





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

            // 1up!
            if (exp >= requiredExp && lvlUp == false)
            {
                // lvlUp = true;
                levelUp();
            }
            else if (lvlUp == true)
            {
                lvlUp = false;

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
                    coins += 100;
                    burnCounter = 0;
                }
                //activate the lever

                // if activated give ladder!


            }

            else if (level == 3)
            {


            }

            // *** item selection in inventory **************************************************************************************************

            if (selectedItem < 0)
            {

                selectedItem = inventory.Count - 1;
            }
            else if (selectedItem < inventory.Count - 1)
            {

            }
            else if (selectedItem > inventory.Count - 1)
            {
                selectedItem = 0;
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
                    // player use item
                    case ConsoleKey.E:
                        use = true;
                        break;

                    // player use spell / skill
                    case ConsoleKey.Enter:
                        skillAttack = true;
                        break;

                    case ConsoleKey.I:
                       displayInventory = true;
                        break;

                    case ConsoleKey.B:
                        displayInventory = false;
                        break;

                    case ConsoleKey.F:
                        equipNow = true;
                        break;

                    //select different items!!
                    case ConsoleKey.DownArrow:
                        selectedItem++;
                        actionString = "position "+ selectedItem;
                        break;
                    case ConsoleKey.UpArrow:
                        selectedItem--;
                        actionString = "position " + selectedItem;
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
                        if (mapArray[yPos, xPos + 1] != "█" && mapArray[yPos, xPos + 1] != "▒" && mapArray[yPos, xPos + 1] != "▲" && mapArray[yPos, xPos + 1] != "#")
                        {

                            if (mapArray[yPos, xPos] == "~") {Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (mapArray[yPos, xPos] == "«"){Console.ForegroundColor = ConsoleColor.Green;  }
                            else if (mapArray[yPos, xPos] == "▒"){ Console.ForegroundColor = ConsoleColor.DarkCyan;  }
                            else if (mapArray[yPos, xPos] == "●") {  Console.ForegroundColor = ConsoleColor.Green;  }
                            else if (mapArray[yPos, xPos] == "▀") { Console.ForegroundColor = ConsoleColor.DarkGray;  }
                            else if (mapArray[yPos, xPos] == "▲"){Console.ForegroundColor = ConsoleColor.DarkGreen; }



                            Console.SetCursorPosition(xPos, yPos); //Erst an Position Löschen
                            Console.Write(mapArray[yPos, xPos]);

                            xPos += 1;
                            Console.SetCursorPosition(xPos, yPos); //An neuer Position zeichnen
                            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
                            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }

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
                        if (mapArray[yPos, xPos - 1] != "█" && mapArray[yPos, xPos - 1] != "▒" && mapArray[yPos, xPos - 1] != "▲" && mapArray[yPos, xPos - 1] != "#") //Kollision links
                        {
                            if (mapArray[yPos, xPos] == "~") { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (mapArray[yPos, xPos] == "«") { Console.ForegroundColor = ConsoleColor.Green; }
                            else if (mapArray[yPos, xPos] == "▒") { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                            else if (mapArray[yPos, xPos] == "●") { Console.ForegroundColor = ConsoleColor.Green; }
                            else if (mapArray[yPos, xPos] == "▀") { Console.ForegroundColor = ConsoleColor.DarkGray; }
                            else if (mapArray[yPos, xPos] == "▲") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write(mapArray[yPos, xPos]);

                            xPos -= 1;
                            Console.SetCursorPosition(xPos, yPos);
                            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
                            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }

                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("@");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                        //        Thread.Sleep(speed);

                        break;
                    case ConsoleKey.S:
                        direction = "South";
                        fieldsWalked++;
                        if (mapArray[yPos + 1, xPos] != "█" && mapArray[yPos + 1, xPos] != "▒" && mapArray[yPos + 1, xPos] != "▲" && mapArray[yPos + 1, xPos] != "#") //Kollision unten
                        {
                            if (mapArray[yPos, xPos] == "~") { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (mapArray[yPos, xPos] == "«") { Console.ForegroundColor = ConsoleColor.Green; }
                            else if (mapArray[yPos, xPos] == "▒") { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                            else if (mapArray[yPos, xPos] == "●") { Console.ForegroundColor = ConsoleColor.Green; }
                            else if (mapArray[yPos, xPos] == "▀") { Console.ForegroundColor = ConsoleColor.DarkGray; }
                            else if (mapArray[yPos, xPos] == "▲") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write(mapArray[yPos, xPos]);

                            yPos += 1;
                            Console.SetCursorPosition(xPos, yPos);
                            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
                            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }


                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("@");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                        //       Thread.Sleep(speed);

                        break;
                    case ConsoleKey.W:
                        direction = "North";
                        fieldsWalked++;
                        if (mapArray[yPos - 1, xPos] != "█" && mapArray[yPos - 1, xPos] != "▒" && mapArray[yPos - 1, xPos] != "▲" && mapArray[yPos - 1, xPos] != "#") //Kollision oben
                        {
                            if (mapArray[yPos, xPos] == "~") { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (mapArray[yPos, xPos] == "«") { Console.ForegroundColor = ConsoleColor.Green; }
                            else if (mapArray[yPos, xPos] == "▒") { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                            else if (mapArray[yPos, xPos] == "●") { Console.ForegroundColor = ConsoleColor.Green; }
                            else if (mapArray[yPos, xPos] == "▀") { Console.ForegroundColor = ConsoleColor.DarkGray; }
                            else if (mapArray[yPos, xPos] == "▲") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write(mapArray[yPos, xPos]);

                            yPos -= 1;
                            Console.SetCursorPosition(xPos, yPos);
                            if (equipmentInteger == 1) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                            else if (equipmentInteger == 0) { Console.ForegroundColor = ConsoleColor.Magenta; }
                            else if (equipmentInteger == 2) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                            else if (equipmentInteger == 3) { Console.ForegroundColor = ConsoleColor.DarkCyan; }

                            
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



                /*  if (mapArray[yPos, xPos] == "#")
                  {
                      Console.SetCursorPosition(xPos, yPos);
                      Console.Write(" ");
                      actionString = "You found a ladder to level " + level;

                  //    level++;
                      riddleSolved = false;
                      Map lvl = new Map();

                  }*/
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

                // pickup loot $
                if (mapArray[yPos, xPos] == "$")
                {
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write(" ");
                    actionString = "You found 1Up!                                ";
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/credits.wav";
                    musicPlayer.Play();
                    
                    //put a skeleton there!
                    mapArray[yPos, xPos] = enemyFloorString;
                    

                    pickUpLoot( );
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
                        direction = "East";
                        // actionString = "you got the right enemy!";
                        CurrentEnemy = enemyList[i];
                        enemyFloorString = CurrentEnemy.floorString;
                    }
                }



            }
            else if (mapArray[yPos, xPos - 1] == "e" || mapArray[yPos, xPos - 1] == "s" || mapArray[yPos, xPos - 1] == "w" || mapArray[yPos, xPos - 1] == "g" || mapArray[yPos, xPos - 1] == "t" || mapArray[yPos, xPos - 1] == "k" || mapArray[yPos, xPos - 1] == "r" || mapArray[yPos, xPos - 1] == "e")
            {
                // actionString = "west of you stands an enemy                    "; 
                enemyContact = true; ;

                for (int i = 0; i < enemyList.Count; i++)
                {
                    if (enemyList[i].xPos == xPos - 1 && enemyList[i].yPos == yPos)
                    {
                        enemyIndex = i;
                        enemyContactEast = false;
                        enemyContactWest = true;
                        enemyContactNorth = false;
                        enemyContactSouth = false;
                        direction = "West";

                        //  actionString = "you got the right enemy !                   ";
                        CurrentEnemy = enemyList[i];
                        enemyFloorString = CurrentEnemy.floorString;

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
                        direction = "South";

                        //  actionString = "you got the right enemy!         ";
                        CurrentEnemy = enemyList[i];
                        enemyFloorString = CurrentEnemy.floorString;

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
                        direction = "North";

                        //    actionString = "you got the right enemy!                ";
                        CurrentEnemy = enemyList[i];
                        enemyFloorString = CurrentEnemy.floorString;

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

        public void pickUpLoot( )
        {





            //how many loot items??
            //int itemNumber = random.Next(1,5);
            // for (int i = 0; i < itemNumber; i++)
            //   {
            int lootRoll = random.Next(0, 8);
            int coinsGathered = random.Next(1, 25);
            coins += coinsGathered;

            



            //item new item, then define the item down there!
            actionString = "                                                                               ";
            string itemName = "item";
            int price = random.Next(lvl, lvl*10+5);
            int itemType = 0;

            //you the weapon directly at the lootroll below
            //with defining all the params for the weapon:item

            //consumables and resources
            if (lootRoll >= 0 && lootRoll <= 4)
            {
                itemType = 3; price = 5;
                //determine what kinda item it is, then name it!
                //0=consumables,1=ammo,2=woods,3=crystals,4=resources,6=herbs
                int objectType = random.Next(0,5);
                //int objectType = random.Next(0, 5);
                int number = random.Next(1, 10);
                //consumables: 0=rations,1=medkit,2=potion
                if (objectType == 0)
                {
                    int SubType = random.Next(0, 2);
                    if (SubType == 0) { itemName = "rations"; price = 5; }
                    else if (SubType == 1) { itemName = "medkit"; price = 15; }
                    else if (SubType == 2) { itemName = "magic potion"; price = 20; }
                }
                //ammo: 0=arrows, 1=bullets
                else if (objectType == 1)
                {
                    int SubType = random.Next(0, 2);
                    if (SubType == 0) { itemName = "arrows"; price = 5; }
                    else if (SubType == 1) { itemName = "bullets"; price = 10; }
                    else if (SubType == 2) { itemName = "bombs"; price = 25; }

                }
                //woods: 0=ebony, 1=hazel, 2=Acacia, 3=cedar, 4=ash, 5=oak
                else if (objectType == 2)
                {
                    int SubType = random.Next(0, 5);

                    if (SubType == 0) { itemName = "ebony wood"; price = 45; }
                    else if (SubType == 1) { itemName = "hazel wood"; price = 25; }
                    else if (SubType == 2) { itemName = "acacia wood"; price = 15; }
                    else if (SubType == 3) { itemName = "cedar wood"; price = 22; }
                    else if (SubType == 4) { itemName = "ash wood"; price = 15; }
                    else if (SubType == 5) { itemName = "oak wood"; price = 35; }
                }
                //crystals
                else if (objectType == 3)
                {
                    number = random.Next(1, 3);
                    int SubType = random.Next(0, 5);
                    if (SubType == 0) { itemName = "diamond"; price = 350; }
                    else if (SubType == 1) { itemName = "ruby"; price = 250; }
                    else if (SubType == 2) { itemName = "emerald"; price = 150; }
                    else if (SubType == 3) { itemName = "sapphire"; price = 225; }
                    else if (SubType == 4) { itemName = "topaz"; price = 15; }
                    else if (SubType == 5) { itemName = "amethyst"; price = 35; }
                }
                //resources
                else if (objectType == 4)
                {
                    number = random.Next(1, 4);
                    int SubType = random.Next(0, 8);
                    if (SubType == 0) { itemName = "fabric"; price = 5; }
                    else if (SubType == 1) { itemName = "fur"; price = 10; }
                    else if (SubType == 2) { itemName = "leather"; price = 12; }
                    else if (SubType == 3) { itemName = "silk"; price = 45; }
                    else if (SubType == 4) { itemName = "cotton"; price = 15; }
                    else if (SubType == 5) { itemName = "iron ore"; price = 35; }
                    else if (SubType == 6) { itemName = "copper ore"; price = 25; }
                    else if (SubType == 7) { itemName = "silver ore"; price = 400; }
                    else if (SubType == 8) { itemName = "gold ore"; price = 1225; }
                }
                //herbs
                else if (objectType == 5)
                {
                    number = random.Next(1, 8);
                    int SubType = random.Next(0, 13);
                    if (SubType == 0) { itemName = "dill"; price = 3; }
                    else if (SubType == 1) { itemName = "ginger"; price = 4; }
                    else if (SubType == 2) { itemName = "mandrake"; price = 15; }
                    else if (SubType == 3) { itemName = "sanjeevani"; price = 150; }
                    else if (SubType == 4) { itemName = "basil"; price = 5; }
                    else if (SubType == 5) { itemName = "thyme"; price = 6; }
                    else if (SubType == 6) { itemName = "Coriander"; price = 6; }
                    else if (SubType == 7) { itemName = "marihuana"; price = 6; }
                    else if (SubType == 8) { itemName = "mushroom"; price = 6; }
                    else if (SubType == 9) { itemName = "thistle"; price = 6; }
                    else if (SubType == 10) { itemName = "turmeric"; price = 6; }
                    else if (SubType == 11) { itemName = "rosemary"; price = 6; }
                    else if (SubType == 12) { itemName = "sage"; price = 6; }
                    else if (SubType == 13) { itemName = "sandalwood"; price = 6; }
                }
                //now declare what you have found to the player
                actionString = "you found " + number + " * " + itemName + ". (" + itemID + " ID) ";
                itemName = number+"*"+itemName;
                Item item = new Item(itemName, price, itemType, 0, ".", objectType);
                eqList.Add(item);

            }
            // offhand weapons and tools
            else if (lootRoll == 5)
            {
                itemType = 2;
                float DMG = random.Next(1, price / (2*lvl)+2);
                float DEF = random.Next(0, price / (2 * lvl));
                float extraMana = random.Next(0, price / (4 * lvl));
                string itemString = " ";
                //determine what kinda item it is, then name it!
                //tools: 0=offhandweapons,1=tools
                int toolType = random.Next(0, 3);


               

               
                //tools
                 if (toolType == 0)
                {
                    int SubType = random.Next(0, 6);
                    if (SubType == 0) { itemName = "firekit"; price = 15; }
                    else if (SubType == 1) { itemName = "shovel"; price = 25; }
                    else if (SubType == 2) { itemName = "magnet"; price = 40; }
                    else if (SubType == 3) { itemName = "lockpick"; price = 10; }
                    else if (SubType == 4) { itemName = "hookshot"; price = 25; }
                    else if (SubType == 5) { itemName = "destillator"; price = 35; }
                    else if (SubType == 6) { itemName = "hammer"; price = 15; }

                    actionString = "you found " + itemName + ", price " + price + " $ (" + itemID + " ID)  ";
                    itemName = itemName+" tool";
                    Item item = new Item(itemName, price, itemType, 0,"[", SubType);
                    eqList.Add(item);

                }
                else if (toolType > 0)
                {
                    int SubType = random.Next(0, 6);
                    if (SubType == 0) { itemName = "shield"; itemString = "■"; }
                    else if (SubType == 1) { itemName = "buckler"; itemString = "●"; }
                    else if (SubType == 2) { itemName = "mirroshield"; itemString = "Θ"; }
                    else if (SubType == 3) { itemName = "longbow"; itemString = ")"; }
                    else if (SubType == 4) { itemName = "recuvebow"; itemString = "}"; }
                    else if (SubType == 5) { itemName = "musket"; itemString = "Į"; }
                    else if (SubType == 6) { itemName = "wand"; itemString = "⫯"; }
                    else if (SubType == 7) { itemName = "liladanda"; itemString = "⥉"; }
                    else if (SubType == 8) { itemName = "discus"; itemString = "○"; }
                    else if (SubType == 9) { itemName = "pushdagger"; itemString = "Џ"; }
                    else if (SubType == 10) { itemName = "thumbscrews"; itemString = "≚"; }

                // alternative weapon icons  --   (↡ ⥉ ⥖ ⫰ ← ⋲ џ ┮ Ґ ԇ  ∫ ҁ ӷ ϟ Ϡ ϡ  Ψ ϙ  ϟ  ϯ  Ƿ  Ͽ  ȹ  Ͳ  Ƭ ͳ Ϯ Ԇ ſ ƪ 

                    actionString = "you found " + itemName + "[" + itemString + "] price " + price + " $ (" + itemID + " ID) ";
                    itemName = itemName + " (" + itemString + ") " + DMG + "/" + DEF;
                    Weapon item = new Weapon(itemName, price, itemType, 0,itemString, SubType);
                    eqList.Add(item);

                }
            }
            // armor, helmets, boots..
            else if (lootRoll == 6)
            {
                price = price;
                //assess quality and grade by the value of the price!
                //randomly define if this is a dagger, sword, mace, staff or axe!
                //then define the 4 subclasses for each of the 5 types!
                float DEF = random.Next(0, price / (2 * lvl) + 1);
                float extraMana = random.Next(0, price / (2 * lvl));
                string itemIcon = "";
                //determine what kinda item it is, then name it!
                //armor: 0=helmet,1=armor,2=gloves,3=boots,4=rings
                int toolType = random.Next(0, 5);
                int SubType = 0;
                //helmet
                if (toolType == 0)
                {
                     SubType = random.Next(0, 4);
                    if (SubType == 0) { itemName = "helmet"; }
                    else if (SubType == 1) { itemName = "circlet"; }
                    else if (SubType == 2) { itemName = "hood"; }
                    else if (SubType == 3) { itemName = "hat"; }
                }
                //armor
                else if (toolType == 1)
                {
                     SubType = random.Next(0, 4);
                    if (SubType == 0) { itemName = "iron armor"; }
                    else if (SubType == 1) { itemName = "leather armor"; }
                    else if (SubType == 2) { itemName = "robes"; }
                    else if (SubType == 3) { itemName = "chainmall"; }
                }
                //gloves
                else if (toolType == 2)
                {
                     SubType = random.Next(0, 3);
                    if (SubType == 0) { itemName = "gloves"; }
                    else if (SubType == 1) { itemName = "mitten"; }
                    else if (SubType == 2) { itemName = "gauntlet"; }
                }
                //boots
                else if (toolType == 3)
                {
                     SubType = random.Next(0, 4);
                    if (SubType == 0) { itemName = "sandals"; }
                    else if (SubType == 1) { itemName = "boots"; }
                    else if (SubType == 2) { itemName = "shoes"; }
                    else if (SubType == 3) { itemName = "footwear"; }
                }
                //rings
                else if (toolType >= 4)
                {
                     SubType = random.Next(0, 6);
                    if (SubType == 0) { itemName = "diamond ring"; }
                    else if (SubType == 1) { itemName = "ruby ring"; }
                    else if (SubType == 2) { itemName = "emerald ring"; }
                    else if (SubType == 3) { itemName = "sapphire ring"; }
                    else if (SubType == 4) { itemName = "amethyst ring"; }
                    else if (SubType == 5) { itemName = "topaz ring"; }
                    else if (SubType == 6) { itemName = "sulphur ring"; }



                }

                actionString = "you found " + itemName + ", price " + price + " $ (" + itemID + " ID)";
                itemName = itemName + " (" + DEF + ")";
                Item item = new Item(itemName, price, itemType, 0,".", SubType);
                eqList.Add(item);


            }
            // primary weapons ;D
            else
            {
                //primary weapons: item

                //assess quality and grade by the value of the price!
                //randomly define if this is a dagger, sword, mace, staff or axe!
                //then define the 4 subclasses for each of the 5 types!
                float DMG = random.Next(1, price / (2 * lvl) + 2);
                float DEF = random.Next(0, price / (2 * lvl));
                float extraMana = random.Next(0, price / (4 * lvl));
                string itemIcon = "";
                //determine what kinda item it is, then name it!
                //weapons: 0=daggers,1=swords,2=maces,3=staves,4=axes
                int toolType = random.Next(0, 5);
                int SubType = random.Next(0, 4);

                //swords
                if (toolType == 1)
                {
                    if (SubType == 0) { itemName = "longswords"; itemIcon = "†"; }
                    else if (SubType == 1) { itemName = "kodachi"; itemIcon = "Ϯ"; }
                    else if (SubType == 2) { itemName = "katana"; itemIcon = "ϯ"; }
                    else if (SubType >2) { itemName = "sabre"; itemIcon = "ƪ"; }

                }
                //daggers
                else if (toolType == 0)
                {
                    if (SubType == 0) { itemName = "stiletto"; itemIcon = "←"; }
                    else if (SubType == 1) { itemName = "sai fork"; itemIcon = "ψ"; }
                    else if (SubType == 2) { itemName = "dagger"; itemIcon = "ƭ"; }
                    else if (SubType > 2) { itemName = "pushdagger"; itemIcon = "Џ"; }
                }
                //warhammers
                else if (toolType == 2)
                {
                    if (SubType == 0) { itemName = "warhammer"; itemIcon = "┮"; }
                    else if (SubType == 1) { itemName = "mace"; itemIcon = "ϙ"; }
                    else if (SubType == 2) { itemName = "morningstar"; itemIcon = "✶"; }
                    else if (SubType > 2) { itemName = "warplough"; itemIcon = "Ƭ"; } //ӷ
                }
                //staves
                else if (toolType == 3)
                {
                    if (SubType == 0) { itemName = "rod"; itemIcon = "/"; }
                    else if (SubType == 1) { itemName = "warstaff"; itemIcon = "Ґ"; }
                    else if (SubType == 2) { itemName = "shamanstaff"; itemIcon = "ϡ"; }
                    else if (SubType ==3) { itemName = "sprig"; itemIcon = "Ԇ"; }
                    else if (SubType == 4) { itemName = "trident"; itemIcon = "Ψ"; }

                 
                }
                //axes
                else if (toolType >= 4)
                {
                    if (SubType == 0) { itemName = "cleaver"; itemIcon = "Ƿ"; }
                    else if (SubType == 1) { itemName = "battleaxe"; itemIcon = "ȹ"; }
                    else if (SubType == 2) { itemName = "halberd"; itemIcon = "ŧ"; }
                    else if (SubType > 2) { itemName = "tomahawk"; itemIcon = "ͳ"; }
                }
                //swords    -     subtypes:     1=longsword (†), 2=katana (Ϯ), 3=broadSword (ϯ), 4=rapier(ƪ)                           
                //daggers   -     subtypes:     1=shiv (←), 2=sai (⫛), 3=dagger (ƭ), 4= knuckles (Ͽ)
                //hammers   -     subtypes:     1=warhammer (┮), 2=mace (ϙ), 3=morningstar (✸), 4=warplow (ӷ)                       
                //staves    -     subtypes:     1=staff (/), 2=trident (∈), 3=treebranch (ϡ), 4=warstaff (Ґ)
                //axes      -     subtypes:     1=cleaver (Ƿ), 2= doublebearded axe (ȹ), 3=tomahawk (Ƭ)
                actionString = "you found " + itemName + "[" + itemIcon + "] price " + price + " $ (" + itemID + " ID) ";
                itemName = itemName + " (" + itemIcon + ") " + DMG + "/" + DEF;
                Weapon item = new Weapon(itemName, price, itemType, equipmentInteger, itemIcon, SubType);
                eqList.Add(item);
            }

            //generate an item!
            //later generate weapon:item and so on up there!
            inventory.Add( itemName);

            itemID++;
            return;
         //   mapArray[CurrentEnemy.yPos, CurrentEnemy.xPos] = currentEnemy.floorString;
        }


      


        public void dealDamage()
        {
            //hit currentEnemy!
            currentEnemy.health -= dmg;
            currentEnemy.ready = true;
            actionString = "you hit " + currentEnemy.raceString;

            // lightning damage!
            /*if (equipmentInteger == 3)
            {
                Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("ϟ");  // blutstropfen 
                Thread.Sleep(70);
                Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("ϟ");  // staves give off charge! 
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(200);
                
            }*/

            //normal damage with blood spatter!
            Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("●");  // blutstropfen 
            Thread.Sleep(200);
            

            Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(CurrentEnemy.raceLetter);

            if (CurrentEnemy.health < 1)
            {
                Console.SetCursorPosition(CurrentEnemy.xPos, CurrentEnemy.yPos);
                mapArray[CurrentEnemy.yPos, CurrentEnemy.xPos] = "$";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("$");
                Console.ForegroundColor = ConsoleColor.White;
                actionString = "the enemy died                  ";
                // give exp
                int expAmount = lvl * (currentEnemy.att + currentEnemy.def) / (10) + currentEnemy.expirienceGained;
                int expNumber = random.Next(expAmount / 2, expAmount * 2);
                exp += expNumber;
                actionString = "you gained (" + expNumber + ") expirience            ";



                CurrentEnemy = null;
            }
            else
            {
                actionString = "you deal [" + dmg + "] damage to an enemy             ";
            }


        }


        public void equipItem(string itemIcon, int weaponDamage, int weaponDefense, int weaponType)
        {

           
                item1 = equippedPrimary.itemIcon;
                weaponDMG = weaponDamage;
                weaponDEF = weaponDefense;
            
            

        }


        //*******************************************************************************************************************
        public void DrawPlayer()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // if the sword should be removed again, read pos from map string array..


            // for now only four classes!    if (equipmentInteger == 4) { item1 = "┲"; }

            
            Console.SetCursorPosition(xPos, yPos);
            if (equipmentInteger == 1) {  Console.ForegroundColor = ConsoleColor.DarkGreen; }
            if (equipmentInteger == 0) {  Console.ForegroundColor = ConsoleColor.Magenta; }
            if (equipmentInteger == 2) {  Console.ForegroundColor = ConsoleColor.DarkYellow; }
            if (equipmentInteger == 3) {  Console.ForegroundColor = ConsoleColor.DarkCyan; }
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;


          //  item1 = equippedPrimary.itemIcon;
            
            //     

            // alternative weapon icons  --   (↡ ⥉ ⥖ ⫰ ← ⋲ џ ┮ Ґ ԇ  ∫ ҁ ӷ ϟ Ϡ ϡ  Ψ ϙ  ϟ  ϯ  Ƿ  Ͽ  ȹ  Ͳ  Ƭ ͳ Ϯ Ԇ ſ ƪ 


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

                //shrine Ħ   smile ☺ ☻  

                //swords    -     subtypes:     1=longsword (†), 2=katana (Ϯ), 3=broadSword (ϯ), 4=rapier(ƪ)                        //sins 1 sword 1 dagger
                //daggers   -     subtypes:     1=stiletto (←), 2=sai (∈), 3=dagger (ƭ), 4=pushdagger (Џ)             //katar, sai and stiletto are offhand too
                //hammers   -     subtypes:     1=warhammer (┮), 2=mace (ϙ), 3=morningstar (✸), 4=warplow (ӷ)                       
                //staves    -     subtypes:     1=staff (/), 2=trident (⫛ Ψ), 3=treebranch (ϡ), 4=warstaff (Ґ)
                //axes      -     subtypes:     1=executioner (Ƿ), 2= doublebearded axe (ȹ), 3=pickaxe (Ƭ)

                //offhand weapons for left hand

                //offhand shield        -       1= studded shield (■), 2=buckler (●), 3=mirrorshield  (⧫) 
                //offhand bows          -       1= longbow(❫), 2= recurve (❵), compoundbow (❱)
                //offhand discus        -       1= chakram (Ѳ), 2= sunwheel (⛭), 3= discus (○) 
                //offhand musket        -       1= flintlock (Į), 2= pistol (⌐), 3= musket (⥖)
                //offhand wand          -       1= wand (⫯), 2= szepter (⫰) pole (ı) 
                //offhand torturedevice -       thumbscrews (≚), garotte (ю)



                // alternative weapon icons  --   (↡ ⥉ ⥖ ⫰ ← ⋲ џ ┮ Ґ  ∫ ҁ ӷ ϟ Ϡ ϡ  Ψ ϙ  ϟ  ϯ  Ƿ  Ͽ  ȹ  Ͳ  Ƭ ͳ Ϯ Ԇ ſ ƪ 

                // paint map new: mapArray[yPos, xPos]

                // ****** sword      @† ⚠  **********************************************************************************************************
                //      if (equipmentInteger == 1)
                //    {

                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_sword.wav";
                musicPlayer.Play();
                int criticalDamage;
                string weaponName = "";
                if (equipmentInteger == 0)
                {
                    criticalDamage = random.Next(1, DEX / 2 + STR / 2);
                    dmg = weaponDMG + (DEX + STR) / 10 + criticalDamage;
                }
                else if (equipmentInteger == 1)
                {
                    criticalDamage = random.Next(1, DEX / 2 + STR / 2);
                    dmg = weaponDMG + (STR + CON) / 10 + criticalDamage;
                }
                else if (equipmentInteger == 2)
                {
                    criticalDamage = random.Next(1, DEX / 2 + CON / 2);
                    dmg = weaponDMG+(CON + STR) / 10 + criticalDamage;
                }
                else if (equipmentInteger == 3)
                {
                    criticalDamage = random.Next(1, DEX / 2 + INT / 2);
                    dmg = weaponDMG + (INT + DEX) / 10 + criticalDamage;
                }

                actionString = "                                       ";
                actionString = "you swing your " + EquippedPrimary.name + "! [" + dmg + "] damage      ";
                if (direction == "East")
                {
                    attackedFloorX = xPos + 1;
                    attackedFloorY = yPos;

                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(item1);
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPos + 1, yPos);
                    if (enemyContact == false)
                    {

                        if (mapArray[attackedFloorY, attackedFloorX] == "~")
                        {
                            actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")          ";
                            //nothing happens
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                        {
                            actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")        ";
                            //you destroy the tree and get some wood
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                        {
                            actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")          ";
                            //you destroy the grass and get herbs 
                            Console.ForegroundColor = ConsoleColor.Green;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                        {
                            actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")           ";
                            //you cannot destroy water
                            Console.ForegroundColor = ConsoleColor.DarkCyan;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                        {
                            actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")              ";
                            //destroy the bush
                            Console.ForegroundColor = ConsoleColor.Green;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                        {
                            actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")                ";
                            //you cannot destroy rocks
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                        }
                    }
                    else { }
                    Console.Write(mapArray[yPos, xPos + 1]);
                    attack = false;

                }

                else if (direction == "South")
                {
                    attackedFloorX = xPos;
                    attackedFloorY = yPos + 1;

                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(item1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(300);
                    Console.SetCursorPosition(xPos, yPos + 1);

                    if (enemyContact == false)
                    {

                        if (mapArray[attackedFloorY, attackedFloorX] == "~")
                        {
                            actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")              ";
                            //nothing happens
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                        {
                            actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")                ";
                            //you destroy the tree and get some wood
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                        {
                            actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")                   ";
                            //you destroy the grass and get herbs 
                            Console.ForegroundColor = ConsoleColor.Green;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                        {
                            actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")                 ";
                            //you cannot destroy water
                            Console.ForegroundColor = ConsoleColor.DarkCyan;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                        {
                            actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")                    ";
                            //destroy the bush
                            Console.ForegroundColor = ConsoleColor.Green;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                        {
                            actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")                 ";
                            //you cannot destroy rocks
                            Console.ForegroundColor = ConsoleColor.DarkGray;

                        }
                    }
                    else { }
                    Console.Write(mapArray[yPos + 1, xPos]);

                    attack = false;
                }

                else if (direction == "West")
                {
                    attackedFloorX = xPos - 1;
                    attackedFloorY = yPos;

                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(item1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(300);
                    Console.SetCursorPosition(xPos - 1, yPos);
                    if (enemyContact == false)
                    {

                    if (mapArray[attackedFloorY, attackedFloorX] == "~")
                    {
                        actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")           ";
                        //nothing happens
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                    {
                        actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")             ";
                        //you destroy the tree and get some wood
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                    {
                        actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")               ";
                        //you destroy the grass and get herbs 
                        Console.ForegroundColor = ConsoleColor.Green;

                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                    {
                        actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")               " ;
                        //you cannot destroy water
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                    {
                        actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")                ";
                        //destroy the bush
                        Console.ForegroundColor = ConsoleColor.Green;

                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                    {
                        actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")                  ";
                        //you cannot destroy rocks
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    }
                    }
                    else { }

                    Console.Write(mapArray[yPos, xPos - 1]);

                    attack = false;
                }

                else if (direction == "North")
                {
                    attackedFloorX = xPos;
                    attackedFloorY = yPos - 1;

                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(item1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(300);
                    Console.SetCursorPosition(xPos, yPos - 1);
                    if (enemyContact == false)
                    {

                    if (mapArray[attackedFloorY, attackedFloorX] == "~")
                    {
                        actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")             ";
                        //nothing happens
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                    {
                        actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")                 ";
                        //you destroy the tree and get some wood
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                    {
                        actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")                     ";
                        //you destroy the grass and get herbs 
                        Console.ForegroundColor = ConsoleColor.Green;

                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                    {
                        actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")                  ";
                        //you cannot destroy water
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                    {
                        actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")                   ";
                        //destroy the bush
                        Console.ForegroundColor = ConsoleColor.Green;

                    }

                    else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                    {
                        actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")                   ";
                        //you cannot destroy rocks
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    }
                    }
                    else { }
                    Console.Write(mapArray[yPos - 1, xPos]);
                attack = false;


                }

            // withdraw health from enemy

            if (enemyContact == true && CurrentEnemy != null)
            {
                dealDamage();
            }
            }

          


            /* if (direction == "East")
                   {
                       attackedFloorX = xPos + 1;
                       attackedFloorY = yPos;

                       Console.SetCursorPosition(xPos + 1, yPos);
                       Console.Write(item1);
                       Thread.Sleep(300);
                       Console.ForegroundColor = ConsoleColor.White;
                       Console.SetCursorPosition(xPos + 1, yPos);
                       if (enemyContact == false)
                       {

                           if (mapArray[attackedFloorY, attackedFloorX] == "~")
                           {
                               actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //nothing happens
                               Console.ForegroundColor = ConsoleColor.DarkYellow;
                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                           {
                               actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you destroy the tree and get some wood
                               Console.ForegroundColor = ConsoleColor.DarkGreen;
                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                           {
                               actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you destroy the grass and get herbs 
                               Console.ForegroundColor = ConsoleColor.Green;

                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                           {
                               actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you cannot destroy water
                               Console.ForegroundColor = ConsoleColor.DarkCyan;

                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                           {
                               actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //destroy the bush
                               Console.ForegroundColor = ConsoleColor.Green;

                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                           {
                               actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you cannot destroy rocks
                               Console.ForegroundColor = ConsoleColor.DarkGray;

                           }
                       }
                       else { }
                       Console.Write(mapArray[yPos, xPos + 1]);
                       attack = false;

                   }

                   else if (direction == "South")
                   {
                       attackedFloorX = xPos;
                       attackedFloorY = yPos + 1;

                       Console.SetCursorPosition(xPos, yPos + 1);
                       Console.Write(item1);
                       Console.ForegroundColor = ConsoleColor.White;
                       Thread.Sleep(300);
                       Console.SetCursorPosition(xPos, yPos + 1);

                       if (enemyContact == false)
                       {

                           if (mapArray[attackedFloorY, attackedFloorX] == "~")
                           {
                               actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //nothing happens
                               Console.ForegroundColor = ConsoleColor.DarkYellow;
                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                           {
                               actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you destroy the tree and get some wood
                               Console.ForegroundColor = ConsoleColor.DarkGreen;
                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                           {
                               actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you destroy the grass and get herbs 
                               Console.ForegroundColor = ConsoleColor.Green;

                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                           {
                               actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you cannot destroy water
                               Console.ForegroundColor = ConsoleColor.DarkCyan;

                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                           {
                               actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //destroy the bush
                               Console.ForegroundColor = ConsoleColor.Green;

                           }

                           else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                           {
                               actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                               //you cannot destroy rocks
                               Console.ForegroundColor = ConsoleColor.DarkGray;

                           }
                       }
                       else { }
                       Console.Write(mapArray[yPos + 1, xPos]);

                       attack = false;
                   }

                   else if (direction == "West")
                   {
                       attackedFloorX = xPos - 1;
                       attackedFloorY = yPos;

                       Console.SetCursorPosition(xPos - 1, yPos);
                       Console.Write(item1);
                       Console.ForegroundColor = ConsoleColor.White;
                       Thread.Sleep(300);
                       Console.SetCursorPosition(xPos - 1, yPos);
                       if (enemyContact == false)
                       {

                       if (mapArray[attackedFloorY, attackedFloorX] == "~")
                       {
                           actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //nothing happens
                           Console.ForegroundColor = ConsoleColor.DarkYellow;
                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                       {
                           actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you destroy the tree and get some wood
                           Console.ForegroundColor = ConsoleColor.DarkGreen;
                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                       {
                           actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you destroy the grass and get herbs 
                           Console.ForegroundColor = ConsoleColor.Green;

                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                       {
                           actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you cannot destroy water
                           Console.ForegroundColor = ConsoleColor.DarkCyan;

                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                       {
                           actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //destroy the bush
                           Console.ForegroundColor = ConsoleColor.Green;

                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                       {
                           actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you cannot destroy rocks
                           Console.ForegroundColor = ConsoleColor.DarkGray;

                       }
                       }
                       else { }

                       Console.Write(mapArray[yPos, xPos - 1]);

                       attack = false;
                   }

                   else if (direction == "North")
                   {
                       attackedFloorX = xPos;
                       attackedFloorY = yPos - 1;

                       Console.SetCursorPosition(xPos, yPos - 1);
                       Console.Write(item1);
                       Console.ForegroundColor = ConsoleColor.White;
                       Thread.Sleep(300);
                       Console.SetCursorPosition(xPos, yPos - 1);
                       if (enemyContact == false)
                       {

                       if (mapArray[attackedFloorY, attackedFloorX] == "~")
                       {
                           actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //nothing happens
                           Console.ForegroundColor = ConsoleColor.DarkYellow;
                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                       {
                           actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you destroy the tree and get some wood
                           Console.ForegroundColor = ConsoleColor.DarkGreen;
                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                       {
                           actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you destroy the grass and get herbs 
                           Console.ForegroundColor = ConsoleColor.Green;

                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                       {
                           actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you cannot destroy water
                           Console.ForegroundColor = ConsoleColor.DarkCyan;

                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                       {
                           actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //destroy the bush
                           Console.ForegroundColor = ConsoleColor.Green;

                       }

                       else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                       {
                           actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                           //you cannot destroy rocks
                           Console.ForegroundColor = ConsoleColor.DarkGray;

                       }
                       }
                       else { }
                       Console.Write(mapArray[yPos - 1, xPos]);
                   attack = false;


                   }*/


            /*        }

                    // ****** dagger      @←←   **********************************************************************************************************
                    if (equipmentInteger == 0)
                    {
                        musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                        musicPlayer.Play();
                        int criticalDamage;
                        criticalDamage = random.Next(0, 3);
                        dmg = (DEX * STR / 10 + criticalDamage)/2;
                        actionString = "you stab with your daggers! [" + dmg + "] damage";

                        if (direction == "East")
                        {


                            Console.SetCursorPosition(xPos + 1, yPos);
                            Console.Write("←");
                            Thread.Sleep(300);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(xPos + 1, yPos);
                            Console.Write(mapArray[yPos, xPos + 1]);
                            Thread.Sleep(100);
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                            musicPlayer.Play();
                            if (enemyContact == true)
                                dealDamage();

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
                            Thread.Sleep(100);
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                            musicPlayer.Play();
                            if (enemyContact == true)

                                dealDamage();

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
                            Thread.Sleep(100);
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                            musicPlayer.Play();
                            if (enemyContact == true)

                                dealDamage();

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
                            Thread.Sleep(100);
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                            musicPlayer.Play();
                            if (enemyContact == true)

                                dealDamage();

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
                        dmg = CON * STR / 10 + criticalDamage;
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
                        dmg = INT * DEX / 10 + criticalDamage;
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
                    */






            //*************************************************************************************************************************************

            //press enter!


            if (skillAttack == true && mana >= 2)
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
                    criticalDamage = random.Next(0, STR);

                    dmg = 5 * STR * CON / 10 + criticalDamage;
                    actionString = "heavy sword attack!! [" + dmg + "] damage                  ";

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
                        attackedFloorX = xPos + 1;
                        attackedFloorY = yPos;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos + 1, yPos);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("/");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);

                    }

                    else if (direction == "South")
                    {
                        attackedFloorX = xPos;
                        attackedFloorY = yPos + 1;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos + 1);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("/");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                    }

                    else if (direction == "West")
                    {
                        attackedFloorX = xPos - 1;
                        attackedFloorY = yPos;

                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos - 1, yPos);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("/");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                    }

                    else if (direction == "North")
                    {
                        attackedFloorX = xPos;
                        attackedFloorY = yPos - 1;

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos - 1);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("/");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);

                    }
                    else
                    {



                    }

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_shovel.wav";
                    musicPlayer.Play();

                    if (enemyContactEast || enemyContactSouth || enemyContactWest || enemyContactNorth)
                    {
                        //hit currentEnemy!
                        dealDamage();
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    /*attackedFloorX = xPos;
                    attackedFloorY = yPos - 1;


                     
                     */
                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);

          //          Console.SetCursorPosition(xPos, yPos);
        //            Console.Write("@");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    //*********************************************************************


                    Thread.Sleep(300);


                    if (enemyContact == false)
                    {

                        if (mapArray[attackedFloorY, attackedFloorX] == "~")
                        {
                            actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //nothing happens
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                        {
                            actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the tree and get some wood
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = ".";
                            generateWood();
                            //generate woods
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                        {
                            actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the grass and get herbs 
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                        {
                            actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy water
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                        {
                            actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //destroy the bush
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            //generate herbs
                            generateHerbs();
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                        {
                            actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy rocks
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }
                    }
                    else
                    {
                        actionString = "you hit the ground";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                        Console.Write(mapArray[attackedFloorY, attackedFloorX]);
                    }


                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    //recolorize this map tile ASAP!
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);

                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

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

                    mana -= 2;
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_dagger.wav";
                    musicPlayer.Play();

                    int criticalDamage;
                    criticalDamage = random.Next(0, DEX);

                    dmg = 4 * DEX * STR / 10 + criticalDamage;
                    actionString = "you deliver a critical hit! [" + dmg + "] damage           ";
                    //Console.BackgroundColor = ConsoleColor.DarkRed;


                    if (direction == "East")
                    { //Norden
                        attackedFloorX = xPos + 1;
                        attackedFloorY = yPos;
                        //Osten
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);

                    }

                    else if (direction == "South")
                    {
                        attackedFloorX = xPos;
                        attackedFloorY = yPos+1;
                        //Süden
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);



                    }

                    else if (direction == "West")
                    {
                        attackedFloorX = xPos - 1;
                        attackedFloorY = yPos;
                        //Westen 
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);


                    }

                    else if (direction == "North")
                    {
                        attackedFloorX = xPos;
                        attackedFloorY = yPos-1;
                        //Norden
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(item1);

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
                    //       map.DrawMap();


                    if (enemyContact == false)
                    {

                        if (mapArray[attackedFloorY, attackedFloorX] == "~")
                        {
                            actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //nothing happens
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                        {
                            actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the tree and get some wood
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = ".";
                            generateWood();
                            //generate woods
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                        {
                            actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the grass and get herbs 
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                        {
                            actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy water
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                        {
                            actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //destroy the bush
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                        {
                            actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy rocks
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }
                    }
                    else
                    {
                        actionString = "you hit the ground";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                        Console.Write(mapArray[attackedFloorY, attackedFloorX]);
                    }

                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    //recolorize this map tile ASAP!
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    skillAttack = false;

                

                }

                // ****** warplow      @┲ ͳ  **********************************************************************************************************
                if (equipmentInteger == 2)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/att_plow.wav";
                    musicPlayer.Play();

                    int criticalDamage;
                    criticalDamage = random.Next(0, CON);
                    dmg = 4 * CON * STR / 10 + criticalDamage;
                    mana -= 2;

                    actionString = "you crush your foes! [" + dmg + "] damage              ";
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
                        attackedFloorX = xPos+1;
                        attackedFloorY = yPos;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(item1);
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
                        attackedFloorX = xPos;
                        attackedFloorY = yPos + 1;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("●");
                        Thread.Sleep(200);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("O");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                    }

                    else if (direction == "West")
                    {
                        attackedFloorX = xPos-1;
                        attackedFloorY = yPos;

                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(item1);
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
                        attackedFloorX = xPos;
                        attackedFloorY = yPos - 1;

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(item1);
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
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    /*attackedFloorX = xPos;
                    attackedFloorY = yPos - 1;


                     
                     */
                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);
                  //  Console.SetCursorPosition(xPos, yPos);
                //    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    //*********************************************************************


                    Thread.Sleep(300);


                    if (enemyContact == false)
                    {

                        if (mapArray[attackedFloorY, attackedFloorX] == "~")
                        {
                            actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //nothing happens
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                        {
                            actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the tree and get some wood
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = ".";
                            generateWood();
                            //generate woods
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                        {
                            actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the grass and get herbs 
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                        {
                            actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy water
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                        {
                            actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //destroy the bush
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                        {
                            actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy rocks
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }
                    }
                    else
                    {
                        actionString = "you hit the ground";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                        Console.Write(mapArray[attackedFloorY, attackedFloorX]);
                    }


                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    //recolorize this map tile ASAP!
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

                    skillAttack = false;

                }



                // ****** staff      @Ґϟ   **********************************************************************************************************
                if (equipmentInteger == 3)
                {
                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_firekit.wav";
                    musicPlayer.Play();
                    int criticalDamage;
                    criticalDamage = random.Next(0, INT);
                    dmg = 4 * INT * DEX / 10 + criticalDamage;
                    actionString = "you use your wand! [" + dmg + "] damage                  ";
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




                    if (direction == "East")
                    {
                        attackedFloorX = xPos + 1;
                        attackedFloorY = yPos;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("ϟ");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos + 1, yPos);
                        Console.Write(mapArray[yPos, xPos + 1]);

                    }

                    else if (direction == "South")
                    {
                        attackedFloorX = xPos;
                        attackedFloorY = yPos + 1;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("ϟ");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos + 1);
                        Console.Write(mapArray[yPos + 1, xPos]);
                    }

                    else if (direction == "West")
                    {
                        attackedFloorX = xPos - 1;
                        attackedFloorY = yPos;

                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("ϟ");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos - 1, yPos);
                        Console.Write(mapArray[yPos, xPos - 1]);
                    }

                    else if (direction == "North")
                    {
                        attackedFloorX = xPos;
                        attackedFloorY = yPos - 1;

                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(item1);
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("ϟ");
                        Thread.Sleep(200);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xPos, yPos - 1);
                        Console.Write(mapArray[yPos - 1, xPos]);

                    }
                    else
                    {



                    }

                    musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/item_explosion.wav";
                    musicPlayer.Play();

                    if (enemyContactEast || enemyContactSouth || enemyContactWest || enemyContactNorth)
                    {
                        //hit currentEnemy!
                        dealDamage();
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    /*attackedFloorX = xPos;
                    attackedFloorY = yPos - 1;


                     
                     */
                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);

              //      Console.SetCursorPosition(xPos, yPos);
               //     Console.Write("@");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    //*********************************************************************


                    Thread.Sleep(300);

                    if (enemyContact == false)
                    {

                        if (mapArray[attackedFloorY, attackedFloorX] == "~")
                        {
                            actionString = "we are hitting sand! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //nothing happens
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▲")
                        {
                            actionString = "we are removing this tree! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the tree and get some wood
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = ".";
                            generateWood();
                            //generate woods
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "«")
                        {
                            actionString = "we are hitting the grass! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you destroy the grass and get herbs 
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▒")
                        {
                            actionString = "we are hitting water! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy water
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "●")
                        {
                            actionString = "we are hitting a bush! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //destroy the bush
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            mapArray[attackedFloorY, attackedFloorX] = "⁃";
                            generateHerbs();
                            //generate herbs
                        }

                        else if (mapArray[attackedFloorY, attackedFloorX] == "▀")
                        {
                            actionString = "we are hitting rocks! (" + attackedFloorX + "/" + attackedFloorY + ")";
                            //you cannot destroy rocks
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }
                    }
                    else
                    {
                        actionString = "you hit the ground";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                        Console.Write(mapArray[attackedFloorY, attackedFloorX]);
                    }


                    Console.SetCursorPosition(attackedFloorX, attackedFloorY);
                    //recolorize this map tile ASAP!
                    Console.Write(mapArray[attackedFloorY, attackedFloorX]);

                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("@");

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
                giveLadder(xPos, yPos - 1);
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







         //   Console.SetCursorPosition(xPos + 25, yPos + 3);
          

            /*    Console.SetCursorPosition(xPos + 25, yPos + 6);
                Console.Write("                     "); // Alte Richtung löschen, mit Leerschlag überschreiben
                Console.Write("next turn [enter] " + fieldsWalked + "/5");  // was machst du?
                */







        }

        public void UpdateStats()
        {

            // xPos can be maparray.getlength!!

            int xPos = 60;
            int yPos = 12;

            //display stats only when needed!

         

          /*  Console.SetCursorPosition(xPos, yPos);
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
          

            */






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
         //   Console.Write(actionString);
           


            //Console.SetCursorPosition(xPos, yPos);
            //Console.Write(burnCounter);
            //yPos++;

           

            yPos++;
          

                //    << minimap >>  ****************************************************************************************************************

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                yPos++;
                Console.SetCursorPosition(xPos, yPos);

                int oldYpos = yPos;


                for (int y = 1; y < 9; y++)
                {
                    for (int x = 1; x < 9; x++)
                    {
                        if (x < 9)
                        {

                            if (x == xCoordinates && y == yCoordinates)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(xCoordinates + "" + yCoordinates + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.Write(x + "" + y + ",");
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

                xPos = 88;
                yPos = oldYpos;

                Console.SetCursorPosition(xPos, yPos);
                Console.Write("weapon [space] " + item1);
                yPos++;
                Console.SetCursorPosition(xPos, yPos);
                if (equipmentInteger == 1) { Console.Write("bash [enter] " + item1); }
                if (equipmentInteger == 0) { Console.Write("backstab [enter] " + item1); }
                if (equipmentInteger == 2) { Console.Write("holy hammer [enter] " + item1); }
                if (equipmentInteger == 3) { Console.Write("magic blast [enter] " + item1); }

                yPos++;
                Console.SetCursorPosition(xPos, yPos);
                Console.Write("offhand [e] " + item2);
                yPos++;

                Console.SetCursorPosition(xPos, yPos);
                Console.Write(" ");
                yPos++;



                Console.SetCursorPosition(xPos, yPos);
                Console.Write("coins");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" ♦ ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(+coins);




                Console.SetCursorPosition(xPos, yPos + 1);
                Console.Write("Level " + lvl + ", exp " + exp + "/" + requiredExp+"        ");
                yPos++;
                Console.SetCursorPosition(xPos, yPos + 1);
                Console.Write("life ");
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


            

                //display inventory
                yPos = 0;
                xPos = 60;
                Console.SetCursorPosition(xPos, yPos);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("inventory");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;

                yPos++;
                if (inventory.Count >= 1)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        yPos++;
                        // we are looking at this from the inventory!
                        if (selectedItem == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(xPos, yPos);
                            if (inventory.Count >= 1 && i < inventory.Count)
                            Console.Write("" + inventory[i]);
                            Console.ForegroundColor = ConsoleColor.White;

                        //if we press r while over this item,
                        //then equip it!

                        if (eqList[i] != null)
                        {
                            if (equipNow == true && eqList[selectedItem].itemType == 0)
                            {
                                equipItem(eqList[i].itemIcon, 2, 2, eqList[i].itemDefiningType);
                                item1 = eqList[i].itemIcon;
                                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/01_character_creation.wav";
                                musicPlayer.Play();
                                equipNow = false;

                            }
                        }
                        //consume items!
                        /*       else if (equipNow == true && eqList[selectedItem].itemType == 3 && eqList[selectedItem].itemSubType == 0 || equipNow == true && eqList[selectedItem].itemType == 3 && eqList[selectedItem].itemSubType == 5)
                               {
                                   actionString = ("you are eating " + eqList[selectedItem].name);
                                   eqList.RemoveAt(selectedItem);
                                   health +=5; mana += 2;
                               }*/
                        //other things dont work yet!
                        else if (equipNow == true)
                        {
                            actionString= ("you can not equip " + eqList[selectedItem].name);
                        }

                        itemID++;
                        }
                        else
                        {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(xPos, yPos);
                        if (inventory.Count >= 1 && i < inventory.Count)
                            Console.Write("" + inventory[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        itemID++;
                        }
                    }
                }
                yPos = 1;
                xPos = 85;
                if (inventory.Count > 10)
                {
                for (int i = 10; i < inventory.Count; i++)
                {
                    yPos++;
                    // we are looking at this from the inventory!
                    // we are looking at this from the inventory!
                    if (selectedItem == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(xPos, yPos);
                        if (inventory.Count >= 1 && i < inventory.Count)
                            Console.Write("" + inventory[i]);
                        Console.ForegroundColor = ConsoleColor.White;

                        //if we press r while over this item,
                        //then equip it!
                        if (eqList[i] != null)
                        {
                        if (equipNow == true && eqList[selectedItem].itemType == 0)
                        {
                            equipItem(eqList[i].itemIcon, 2, 2, eqList[i].itemDefiningType);
                            item1 = eqList[i].itemIcon;
                            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/01_character_creation.wav";
                            musicPlayer.Play();
                            equipNow = false;

                        }
                        }
                        //consume items!
                      /*  else if (equipNow == true && eqList[selectedItem].itemType == 3 && eqList[selectedItem].itemSubType == 0 || equipNow == true && eqList[selectedItem].itemType == 3 && eqList[selectedItem].itemSubType == 5)
                        {
                            actionString = ("you are eating " + eqList[selectedItem].name);
                            eqList.RemoveAt(selectedItem);
                            health += 5; mana += 2;
                        }*/
                        //other things dont work yet!
                        else if (equipNow == true)
                        {
                            actionString = ("you can not equip " + eqList[selectedItem].name);
                        }

                        itemID++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(xPos, yPos);
                        if (inventory.Count >= 1 && i < inventory.Count)
                            Console.Write("" + inventory[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        itemID++;
                    }
                }

            }
            

          
           
            

           

           

            //**********************************************************************************************************************************
            //Console.SetCursorPosition(xPos, yPos);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // other parts of interface
            xPos = 0;
            yPos = mapArray.GetLength(0) +1;

            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            yPos++;
            Console.Write("                               "); // Alte Richtung löschen, mit Leerschlag überschreiben
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(" level " + xCoordinates + "/" + yCoordinates + ", compass: " + direction);  // neue Richtungsangabe

            //            Console.Write("                               ");

            xPos = 40;
            //yPos++;
            Console.SetCursorPosition(xPos, yPos);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" "+actionString + "");
            Console.ForegroundColor = ConsoleColor.White;

            yPos++;
            xPos = 0;

            //for each life u got, for loop and write "█"
            Console.SetCursorPosition(xPos, yPos + 1);
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
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("▄");  // wieviel leben hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            //for each life u got, for loop and write "█"
            Console.SetCursorPosition(xPos, yPos + 2);
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
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("▄");  // wieviel mana hast du?
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            // display all actions via console.writeline
            Console.Write(" STR:" + STR);
    //        yPos++;
            Console.Write(" CON:" + CON);
    //        yPos++;
            Console.Write(" DEX:" + DEX);
    //        yPos++;
            Console.Write(" INT:" + INT);
            //        yPos++;
            Console.Write(" DMG:" + dmg);

            Console.Write(" weapon damage:" + weaponDMG+"                   ");






        }

        public bool playerDied()
        {
            if (health <= 0)
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
                indoors = true;
                actionString = "you open a door";
                return true;
            }

            else if (mapArray[yPos, xPos] == "2")
            {
                indoors = true;
                actionString = "you open a door";
                return true;
            }

            else if (mapArray[yPos, xPos] == "3")
            {
                indoors = true;
                actionString = "you open a door";
                return true;
            }

            else if (mapArray[yPos, xPos] == "4")
            {
                indoors = true;
                actionString = "you open a door";
                return true;
            }

            else if (mapArray[yPos, xPos] == "5")
            {
                indoors = true;
                actionString = "you open a door";
                return true;
            }

            else if(mapArray[yPos, xPos] == "6")
            {
                indoors = true;
                actionString = "you open a door";
                return true;
            }
            return false;
        }


        public bool leaveDoor()        //open doors
        {
            if (yPos > 10 && indoors == true)
            {
                actionString = "you leave the house";
                return true;
            }
            return false;
        }

        //*************** move global map ********************************************************************************

        public bool travelEast()        //enchanted forests
        {
            if (xPos == 52 && indoors == false && xCoordinates <8)
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel east " + (xCoordinates + 1) + "/" + yCoordinates;
                //    xCoordinates++;
                return true;
            }
            return false;
        }

        public bool travelWest()        //city of the sonnenritter, schönwelt
        {
            if (xPos == 2 && indoors == false && xCoordinates > 1)
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel west " + (xCoordinates + 1) + "/" + yCoordinates;
                //    xCoordinates++;
                return true;
            }
            return false;
        }

        public bool travelSouth()        //ocean of milk 
        {
            if (yPos == 2 && indoors == false && yCoordinates > 1)
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel south " + (xCoordinates + 1) + "/" + yCoordinates;
                //    xCoordinates++;
                return true;
            }
            return false;
        }

        public bool travelNorth()        //silver mountains
        {
            if (yPos == 18 && indoors == false && yCoordinates < 8)
            {
                musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                musicPlayer.Play();
                actionString = "you travel north " + (xCoordinates + 1) + "/" + yCoordinates;
                //    xCoordinates++;
                return true;
            }
            return false;
        }



        //*************** portals  ▼ ► ◄ ▲ *******************************************************************************

        /*     public bool travelEast()        //enchanted forests
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
                 }com
                 return false;
             }

                 */



        //*************** ladders in dungeons *******************************************************************************


        /*  public bool CheckForLadder()
          {
              if (mapArray[yPos, xPos] == "#")
              {
                  musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Properties/menu_click.wav";
                  musicPlayer.Play();
                  return true;
              }
              return false;
          }

                      */

        //*************** enemies on the map *******************************************************************************


        public void populateLevels(int numberOfEnemies)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                string myFloor;
                string enemyRace = "e";
                int enemyRaceInt = 0;
                Random random = new Random();
                enemyRaceInt = random.Next(0, 7);

                int xpos;
                int ypos;
                xpos = random.Next(4, 53);
                ypos = random.Next(7, 18);

                if (mapArray[ypos, xpos] == "█")
                {
                    int newYPos = random.Next(-2,2);
                    ypos = ypos + newYPos;
                    if (mapArray[ypos, xpos] == "█")
                    {
                        int newXPos = random.Next(-2, 2);
                        xpos = xpos+ newXPos;
                    }
                }
                Enemy myEnemy = new Enemy(enemyRaceInt, xpos, ypos, lvl);

                //enum
                if (enemyRaceInt == 0) { enemyRace = "s"; enemyList.Add(myEnemy); myEnemy.raceInt = 0; }   //this is a snake
                else if (enemyRaceInt == 1) { enemyRace = "w"; enemyList.Add(myEnemy); myEnemy.raceInt = 1; }   //this is a wolf
                else if (enemyRaceInt == 2) { enemyRace = "g"; enemyList.Add(myEnemy); myEnemy.raceInt = 2; }   //this is a goblin
                else if (enemyRaceInt == 3) { enemyRace = "t"; enemyList.Add(myEnemy); myEnemy.raceInt = 3; }   //this is a troll
                else if (enemyRaceInt == 4) { enemyRace = "k"; enemyList.Add(myEnemy); myEnemy.raceInt = 4; }   //this is a knight
                else if (enemyRaceInt == 5) { enemyRace = "r"; enemyList.Add(myEnemy); myEnemy.raceInt = 5; }   //this is a rogue
                else if (enemyRaceInt == 6) { enemyRace = "e"; enemyList.Add(myEnemy); myEnemy.raceInt = 6; }   //this is an enchanter
                else { enemyRace = "e"; enemyList.Add(myEnemy); myEnemy.raceInt = 6; }   //this is an enchanter

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
                    actionString = "a snake attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " +lvl+ "                       ";
                }
                else if (enemyRaceInt == 1)
                {
                    actionString = "a wolf attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " + lvl + "            ";
                }
                else if (enemyRaceInt == 2)
                {
                    actionString = "a goblin attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " + lvl + "             ";
                }
                else if (enemyRaceInt == 3)
                {
                    actionString = "a troll attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " + lvl + "      ";
                }
                else if (enemyRaceInt == 4)
                {
                    actionString = "a knight attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " + lvl + "               ";
                }
                else if (enemyRaceInt == 5)
                {
                    actionString = "a rogue attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " + lvl + "                 ";
                }
                else if (enemyRaceInt == 6)
                {
                    actionString = "an enchanter attacks you! (" + currentEnemy.dmg + "/" + currentEnemy.health + ") level " + lvl + "             ";
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

