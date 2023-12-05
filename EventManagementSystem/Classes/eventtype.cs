using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Classes
{
    class eventtype
    {
        private string eventt;

        public string Eventtype
        {
            get { return eventt; }
            set { eventt = value; }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
