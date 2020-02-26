using System;

namespace rogueLike
{
    class NPC
    {

        public string name = "Rick";
        public string raceLetter;
        public int raceInt = 0; // 0=human,  1=goblin, 2=elf, 3=troll, 4=elf....
        public int ID;
        public string raceString = "N";
        public string floorString;
        public int xPos;
        public int yPos;

        public bool hasText = false;         //does this npc have something to say?
        public string textString = "hello stranger, a jolly good day!";  //press (e) to talk to me

        public bool hasQuestion = false;        //does this npc talk if u press (e)?
        public int answerInt = 2;               //how many answers has his question? 0 means it is just text..

        public string questionString = "My mother is sick and needs healing herbs, would you find some for us?";

        public string answer_A = "Yes of course, i`m on my way!";           //yes, positive
        public string answer_B = "No, remove yourself from my eyesight!";   //no, positive
        public string answer_C = "Maybe later";                             //undecided, neutral


        public NPC(int race, string racestring, int x, int y)
        {
            //name generator  -- add more female names
            string[] firstName = { "Matt", "Molly", "Johannes", "Bert", "Connor", "Luke", "Hans", "Jack", "Zoe", "Franz", "Oliver", "Nina", "Captain", "Rico", "Julian", "Claude", "Alice", "Olivia", "Lotte", "Ellen", "Lina", "Theresa", "Nina", "Helen" };
            string[] lastName = { "Meyer", "Weber", "Ferrera", "Colombo", "Johnson", "Williams", "Miller", "Taylor", "Walker", "Cook", "the village idiot", "Rogers", "Perry", "Brown", "Vasquez", "Hicks" };
            Random ran = new Random();
            name = firstName[ran.Next(0, 25)] + " " + lastName[ran.Next(0, 16)];

            string[] textGreeting = { "Hello stranger!", "Nice to see you!", "Hello Baby ;D", "How are things?", "Hi there", "Look what the cat dragged in!", "What have you been up to?", "Nice to meet you!", "What`s new?", "Who are you?", "Morning sir, how can I help you?", "Hey mate, what have you been up to?", "Who is that?", "Praise the gods!", "Burrp!", "By the gods..!" };
            string[] textRandom = { "I have a sword!!", "The weather is shit!", "Do you like my new dress?", "i saw a black cat..", "What happened? I want all the details!", "I have a cold, cough cough!", "If i were you i`d keep a low profile..", "I am envious of your armor!", "I am a silly person..", "What a nice day!", "We heard you do adventures now!", "", "Make sure you eat enough, my child..", "Check out my new shoes!", "The witch sells great potions!", "The forest is scary.." };

            textString = textGreeting[ran.Next(0, 16)] + " " + textRandom[ran.Next(0, 16)];




        }

        public void talk()
        {
            if (hasText == true)
            {
                // display textstring + readkey
                // if 


            }
        }

        //random name generator for your NPCs!
        public static void populateWithNPCs(int numberOfNPCs)
        {

            //Enemy list on emey.cs
            for (int i = 0; i < numberOfNPCs; i++)
            {
                string myFloor;
                int npcRaceInt = 0;
                Random random = new Random();
                npcRaceInt = random.Next(0, 6);

                int xpos;
                int ypos;
                xpos = random.Next(4, 50);
                ypos = random.Next(7, 20);

                string raceString = "";
                //is this a human? // 0=human,  1=elf, 2=dwarf, 3=Oger 
                if (npcRaceInt == 0) { raceString = "H"; }
                if (npcRaceInt == 1) { raceString = "E"; }
                if (npcRaceInt == 2) { raceString = "D"; }
                if (npcRaceInt == 3) { raceString = "O"; }



                NPC myNPC = new NPC(npcRaceInt, raceString, xpos, ypos);

                //myNPC.xPos = xpos;
                //myNPC.yPos = ypos;

                i++;
            }
        }


    }
}

