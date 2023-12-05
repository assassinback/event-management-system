using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Classes
{
    class roomtype
    {
        private string room;

        public string Roomtype
        {
            get { return room; }
            set { room = value; }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
