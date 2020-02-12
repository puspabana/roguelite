using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Timers;

namespace ConsoleRPG
{
    class Enemy
    {
        public string name = "ork";
        public int health = 15;
        public int maxHealth = 15;

        public int att = 1;
        public int def = 1;

        public int DEX = 5;
        public int STR = 5;
        public int CON = 5;
        public int INT = 5;
        public int speed = 120;  //100 very fast 1000 very sluggish!
        public int dmg = 2;
        public int targetPosX;
        public int targetPosY;

        public int xPos;
        public int yPos;

        public string raceLetter;
        public int raceInt = 0; // 0=snake,  1=wolf, 2=goblin, 3=troll,....
        public string raceString;
        public string floorString;
        public string attackString;

        public bool dead = false;
        public bool ready = true;
        public int movementInt;
        //public Random random = new Random();
        //public string[,] mapArray;

        private static System.Timers.Timer aTimer;


        public Enemy(int race, int x, int y, int health)
        {


            // is this a snake?
            if (race == 0) { STR = 3; CON = 2; DEX = 8; INT = 1; maxHealth = 12; attackString = ","; raceString = "snake"; dmg =  (DEX /4 + STR / 4); }
            // is this a rabid wolf?
            else if (race == 1) { STR = 4; CON = 3; DEX = 2; INT = 2; maxHealth = 16; attackString = "‼"; raceString = "wolf"; dmg =  (STR / 4 + CON / 4); }
            //is this a goblin?
            else if (race == 2) { STR = 3; CON = 2; DEX = 2; INT = 2; maxHealth = 20; attackString = "→"; raceString = "goblin"; dmg =  (DEX / 4 + STR / 4); }
            //is this a troll?
            else if (race == 3) { STR = 5; CON = 3; DEX = 2; INT = 3; maxHealth = 35; attackString = "┭"; raceString = "troll"; dmg = 2 * (CON / 4 + STR / 4); }
            //is this a knight?
            else if (race == 3) { STR = 9; CON = 5; DEX = 2; INT = 1; maxHealth = 35; attackString = "†"; raceString = "knight"; dmg = 2 * (STR / 4 + CON / 4); }
            //is this a rogue?
            else if (race == 3) { STR = 4; CON = 2; DEX = 10; INT = 2; maxHealth = 35; attackString = "→"; raceString = "rogue"; dmg = 2 * (DEX / 4 + STR / 4); }
            //is this an enchanter?
            else if (race == 3) { STR = 2; CON = 2; DEX = 4; INT = 10; maxHealth = 35; attackString = "Ґ"; raceString = "enchanter"; dmg = 2*( INT /4 + DEX / 4); }

            health = maxHealth;

            if (dmg < 1)
                dmg = 1;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //mapArray = MapArray;

            // change to maparray 1
        }

        public void takeDamage(int damage)
        {
            health -= damage;

        }

        /* private static void TimerCallback(Object o)
         {
             // Display the date/time when this method got called.
             Console.WriteLine("In TimerCallback: " + DateTime.Now);
             // Force a garbage collection to occur for this demo.
             GC.Collect();
         }*/




        public void attack(int playerHealth)
            {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (dead == false)
            {
                Console.SetCursorPosition(targetPosX, targetPosY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(attackString);  // angriffbildchen? 
                Thread.Sleep(200);
                Console.SetCursorPosition(targetPosX, targetPosY);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("●");  // blutstropfen
                Console.ForegroundColor = ConsoleColor.White;

            //moveEnemy(xPos,yPos, mapArray[yPos,xPos],"e");

            //Thread.Sleep(450);

            
            }
            
            
            
            return;
        }

        public void move()
        {

        }

        public void Update()
        {
            if (health <= 0)
            {
                dead = true;
            }
            if (dead == true)
            {
            }
        }
       

    }

   
    }
