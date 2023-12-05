using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Classes
{
    class roominfo
    {
        private int id, roomid, totalprice;

        public int Totalprice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }

        public int Roomid
        {
            get { return roomid; }
            set { roomid = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string roomtype, nbpeople, roomsize, eventtype, Nbrooms;
        private DateTime bookingdate;

        public DateTime Bookingdate
        {
            get { return bookingdate; }
            set { bookingdate = value; }
        }
        

        public string Nbrooms1
        {
            get { return Nbrooms; }
            set { Nbrooms = value; }
        }

        public string Eventtype
        {
            get { return eventtype; }
            set { eventtype = value; }
        }

        public string Roomsize
        {
            get { return roomsize; }
            set { roomsize = value; }
        }

        public string Nbpeople
        {
            get { return nbpeople; }
            set { nbpeople = value; }
        }

        public string Roomtype
        {
            get { return roomtype; }
            set { roomtype = value; }
        }
    }
}
