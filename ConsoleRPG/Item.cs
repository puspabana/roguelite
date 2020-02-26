using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogueLike
{
    class Item
    {
        public string name = "item";
        public int price = 1;
        public int itemType = 0;            //0 = weapon, 1 = armor, 2= tool, 3 = consumable
        public string itemIcon;
        public int dmg;
        public int def;
        public int itemSubType = 0;            //differs for all itemTypes..
        public int itemDefiningType = 0;
        public Item()
        {
        }

        public Item(string Name, int Price, int ItemType, int ItemDefiningType, string ItemIcon, int ItemSubType)
        {
            name = Name;
            price = Price;
            itemType = ItemType;
            itemIcon = ItemIcon;
            itemDefiningType = ItemDefiningType;
            itemSubType = ItemSubType;
        }
    }

    class Weapon : Item
    {
       
        
        public Weapon()
        {
        }
        public Weapon(string Name, int Price, int ItemType, int ItemDefiningType, string ItemIcon, int ItemSubType)
        {
            name = Name;
            price = Price;
            itemType = ItemType;
            itemIcon = ItemIcon;
            itemDefiningType = ItemDefiningType;
            itemSubType = ItemSubType;

        }

    }

    /*
    class  Weapon: Item
    {
      

        public int WeaponType = 0;        //0=sword,1=dagger,2=hammer,3=staff
        public int Subtype = 0;
        public int Grade = 0;       //common, rare and epic
        public string WeaponString = "Ƭ";
        public int DamageType = 0;  // 0=normal, 1=electric, 2=holy, 3=unholy, 4=fire, 5=air, 5=water, 6=earth

        public int dmg = 2;
        public int def = 0;


        //swords    -     subtypes:     1=longsword (†), 2=katana (Ϯ), 3=broadSword (ϯ), 4=rapier(ƪ)                           
        //daggers   -     subtypes:     1=shiv (←), 2=sai (⫛), 3=dagger (ƭ)
        //hammers   -     subtypes:     1=warhammer (┮), 2=mace (ϙ), 3=morningstar (✸), 4=warplow (ӷ), 5= reaper (┶)                       
        //staves    -     subtypes:     1=staff (/), 2=trident (∈), 3=treebranch (ϡ), 4=warstaff (Ґ), sceptre (⥉)
        //axes      -     subtypes:     1=executioner (Ƿ), 2= doublebearded axe (ȹ), 3=pickaxe (Ƭ)

        //offhand weapons for left hand

        //offhand shield        -       1= studded shield (■), 2=buckler (●), 3=mirrorshield  (⧫) 
        //offhand bows          -       1= longbow(❫), 2= recurve (❵), compoundbow (❱)
        //offhand discus        -       1= spiked chakram (⛭), 3= discus (○) 
        //offhand musket        -       1= flintlock (Į), 2= pistol (⌐), 3= musket (⥖)
        //offhand wand          -       1= wand (⫯), 2= szepter (⫰) 3= danda (ı) 
        //offhand torturedevice -       1= thumbscrews (≚), 2= garotte (ю)
        //offhand pushdagger    -       1= pushdagger (Џ) 


        public Weapon(string Name, int weapontype, int subType, int damageType)
        {
            //make an enum !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            DamageType = damageType;
            WeaponType = weapontype;
            Subtype = subType;

            //    enum damageType { normal, electric, light, unholy, fire, air, water, earth };
            string nameAspect="";
            if (DamageType == 0) { nameAspect = "iron "; }          //light gray
            if (DamageType == 1) { nameAspect = "shining "; }       //white, light
            if (DamageType == 2) { nameAspect = "unholy "; }        //grey, unholy [inquisitor/necromancer]
            if (DamageType == 4) { nameAspect = "flaming "; }       //red, fire element
            if (DamageType == 5) { nameAspect = "electric "; }      //darkyellow, air-element
            if (DamageType == 6) { nameAspect = "silver "; }        //darkcyan, water-element
            if (DamageType == 7) { nameAspect = "twisted "; }       //green, earth-element

            //swords    -     subtypes:     1=longsword (†), 2=katana (Ϯ), 3=broadSword (ϯ), 4=rapier(ƪ)                           
            //daggers   -     subtypes:     1=shiv (←), 2=sai (⫛), 3=dagger (ƭ), 4= knuckles (Ͽ)
            //hammers   -     subtypes:     1=warhammer (┮), 2=mace (ϙ), 3=morningstar (✸), 4=warplow (ӷ)                       
            //staves    -     subtypes:     1=staff (/), 2=trident (∈), 3=treebranch (ϡ), 4=warstaff (Ґ)
            //axes      -     subtypes:     1=cleaver (Ƿ), 2= doublebearded axe (ȹ), 3=tomahawk (Ƭ)

            //primary weapons for right hand

                // daggers
                if (weapontype == 0)
                {
                    if (Subtype == 0)
                    {
                        name = nameAspect + " shiv";
                        WeaponString = "←";
                    }
                    else if (Subtype == 1)
                    {
                        name = nameAspect + " sai";
                        WeaponString = "⫛";

                    }
                    else if (Subtype == 2)
                    {
                        name = nameAspect + " dagger";
                        WeaponString = "ƭ";
                    }
                    else if (Subtype == 3)
                    {
                        name = nameAspect + " knuckles";
                        WeaponString = "Ͽ";
                    }
                }
                // swords
                else if (weapontype == 1)
                {
                    if (Subtype == 0)
                    {
                        name = nameAspect + " longsword";
                        WeaponString = "†";
                    }
                    else if (Subtype == 1)
                    {
                        name = nameAspect + " kodachi";
                        WeaponString = "Ϯ";

                    }
                    else if (Subtype == 2)
                    {
                        name = nameAspect + " katana";
                        WeaponString = "ϯ";
                    }
                    else if (Subtype == 3)
                    {
                        name = nameAspect + " rapier";
                        WeaponString = "ƪ";
                    }
                }
                // hammers
                else if (weapontype == 2)
                {
                    if (Subtype == 0)
                    {
                        name = nameAspect + " hammer";
                        WeaponString = "←";
                    }
                    else if (Subtype == 1)
                    {
                        name = nameAspect + " mace";
                        WeaponString = "ϙ";

                    }
                    else if (Subtype == 2)
                    {
                        name = nameAspect + " morning star";
                        WeaponString = "✸";
                    }
                    else if (Subtype == 3)
                    {
                        name = nameAspect + " warplow";
                        WeaponString = "ӷ";
                    }
                }
                // staves
                else if (weapontype == 3)
                {
                    if (Subtype == 0)
                    {
                        name = nameAspect + " staff";
                        WeaponString = "/";
                    }
                    else if (Subtype == 1)
                    {
                        name = nameAspect + " warstaff";
                        WeaponString = "Ґ";

                    }
                    else if (Subtype == 2)
                    {
                        name = nameAspect + " sprig";
                        WeaponString = "ϡ";
                    }
                    else if (Subtype == 3)
                    {
                        name = nameAspect + " trident";
                        WeaponString = "∈";
                    }
                }
                // axes
                else if (weapontype == 4)
                {
                    if (Subtype == 0)
                    {
                        name = nameAspect + " battleaxe";
                        WeaponString = "Ƿ";
                    }
                    else if (Subtype == 1)
                    {
                        name = nameAspect + " Halberd";
                        WeaponString = "ŧ";

                    }
                    else if (Subtype == 2)
                    {
                        name = nameAspect + " cleaver";
                        WeaponString = "ȹ";
                    }
                    else if (Subtype == 3)
                    {
                        name = nameAspect + " tomahawk";
                        WeaponString = "Ƭ";
                    }
                }
           


            //Console.OutputEncoding = System.Text.Encoding.UTF8;

        }
        // alternative weapon icons  --   (↡ ⥉ ⥖ ⫰ ← ⋲ џ ┮ Ґ ԇ  ∫ ҁ ӷ ϟ Ϡ ϡ  Ψ ϙ  ϟ  ϯ  Ƿ  Ͽ  ȹ  Ͳ  Ƭ ͳ Ϯ Ԇ ſ ƪ 

    }


    class Armor : Item
    {
      

        public int ArmorType = 0;        // 0=armor,1=helmet,2=gloves,3=boots,4=ring
        public Item(int itemType)
        {

            ArmorType = itemType;
            if (ArmorType == 0) { } //armor
            else if (ArmorType == 1) { } //helmet
            else if (ArmorType == 2) { } //gloves
            else if (ArmorType == 3) { } //boots
            else if (ArmorType == 4) { } //ring

        }

        //armor is not visible, but the torso armor decides the COLOR of your character!!
        //in the beginning you have a basic armor which COLORS your @ avatar
    }
    class Tool : Item
    {
          
        //offhand weapons and items

        public int ToolType = 0;        // 0=shield,1=shovel,2=handgun,3=bow,4=wand,5=hookshot,6=firekit,7=magnet,8=discus


            //offhand weapons for left hand

            //offhand shield        -       1= studded shield (■), 2=buckler (●), 3=mirrorshield  (⧫) 
            //offhand bows          -       1= longbow(❫), 2= recurve (❵), compoundbow (❱)
            //offhand discus        -       1= spiked chakram (⛭), 3= discus (○) 
            //offhand musket        -       1= flintlock (Į), 2= pistol (⌐), 3= musket (⥖)
            //offhand wand          -       1= wand (⫯), 2= szepter (⫰) 3= branch (ԇ) 
            //offhand torturedevice -       1= thumbscrews (≚), 2= garotte (ю)
            //offhand pushdagger    -       1= pushdagger (Џ) 

            // alternative weapon icons  --   (↡ ⥉ ⥖ ⫰ ← ⋲ џ ┮ Ґ ԇ  ∫ ҁ ӷ ϟ Ϡ ϡ  Ψ ϙ  ϟ  ϯ  Ƿ  Ͽ  ȹ  Ͳ  Ƭ ͳ Ϯ Ԇ ſ ƪ 


            //other tools

            //

            // shovel       @♠
            // firekit      @▲
            // magnet       @∩
            // bomb         @●       
            // bow          @)→
            // hookshot     @--->
            // lockpick     @-
            // destiller
        }

        class Consumable : Item
    {
       
        public int type = 0;        // 0=rations,1=herbs,2=potions,3=arrows,4=blackpoweder,5=bombs,6=wood,7=fur,8=leather,9=iron,10=silver,11=gold,12=copper,13=ruby,14=emerald,15=sapphire,16=diamond
        public int stack = 0;       // how many?
    }

*/
}
