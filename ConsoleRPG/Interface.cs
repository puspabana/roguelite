using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogueLike
{



    class Interface
    {
    public static Interface temp;
    public List<Item> inventory = new List<Item>();
        public int itemIndex = 0;
        public Interface()
    {

            

        if (temp == null)
            temp = this;

    }

   }
    

}
