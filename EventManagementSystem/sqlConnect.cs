using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EventManagementSystem
{
    class sqlConnect
    {

        public SqlConnection con1()
        {
            SqlConnection con;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-AQH34LE;Initial Catalog=EventManagementSystem;Integrated Security=True");
                return con;
            }
            catch(System.Exception)
            {

            }
            return null;
        }
        public bool deleteBookedRoomUser(string roomid)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Delete from roominfo where roomid="+roomid, con);
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool updateBookedRoomUser(string roomid,string roomtype,string nbpeople,string roomsize,string eventtype,string Nbrooms,string bookingdate,string totalprice)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("update roominfo set roomtype='"+roomtype+"', nbpeople='"+nbpeople+"',roomsize='"+roomsize+"',eventtype='"+eventtype+"',Nbrooms='"+Nbrooms+"',bookingdate='"+bookingdate+"',totalprice="+totalprice+" where roomid="+roomid, con);
                command.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public DataTable ViewBookedRoomsUser(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from roominfo where id="+id,con);
                using (command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    return dt;
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public void finishBooking()
        {
            try
            {
                List<Classes.roominfo> ids = new List<Classes.roominfo>();
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("select * from roominfo",con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        //7
                        DateTime x=reader.GetDateTime(7);
                        if(x.ToShortDateString()==DateTime.Now.ToShortDateString())
                        {
                            
                            //ids.Add(reader.GetInt32(1));
                            Classes.roominfo info = new Classes.roominfo();
                            info.Id = reader.GetInt32(0);
                            info.Roomid = reader.GetInt32(1);
                            info.Roomtype = reader.GetString(2);
                            info.Nbpeople = reader.GetString(3);
                            info.Roomsize = reader.GetString(4);
                            info.Eventtype = reader.GetString(5);
                            info.Nbrooms1 = reader.GetString(6);
                            info.Bookingdate = reader.GetDateTime(7);
                            info.Totalprice = reader.GetInt32(8);
                            ids.Add(info);
                        }
                    }
                }
                reader.Close();
                foreach(Classes.roominfo x in ids)
                {
                    command = new SqlCommand("Delete from roominfo where roomid="+x.Roomid, con);
                    command.ExecuteNonQuery();
                }
                foreach (Classes.roominfo x in ids)
                {
                    command = new SqlCommand("insert into clearance(id,roomid,roomtype,nbpeople,roomsize,eventtype,nbrooms,bookingdate,totalprice) values("+x.Id+","+x.Roomid+",'"+x.Roomtype+"','"+x.Nbpeople+"','"+x.Roomsize+"','"+x.Eventtype+"','"+x.Nbrooms1+"','"+x.Bookingdate.ToShortDateString()+"',"+x.Totalprice+")", con);
                    command.ExecuteNonQuery();
                }

            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool updatePrices(string eventtype,int price1,string nbroomsinfo,int price2,string roomsize,int price3,string roomtype,int price4)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("update eventtypeinfo set price="+price1+" where eventtype='"+eventtype+"'", con);
                command.ExecuteNonQuery();
                command = new SqlCommand("update nbroomsinfo set price=" + price2 + " where nbrooms=" + nbroomsinfo + "", con);
                command.ExecuteNonQuery();
                command = new SqlCommand("update roomsleft set price=" + price3 + " where roomtype='" + roomsize + "'", con);
                command.ExecuteNonQuery();
                command = new SqlCommand("update roomtypeinfo set price=" + price1 + " where roomtype='" + roomtype + "'", con);
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public Tuple<Classes.eventtype[],Classes.nbroomsinfo[],Classes.roomsize[],Classes.roomtype[]> setPricesinfo()
        {
            try
            {
                int i = 0;
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from eventtypeinfo",con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    i++;
                }
                reader.Close();
                reader = command.ExecuteReader();
                Classes.eventtype[] eventtype = new Classes.eventtype[i];
                i = 0;
                while(reader.Read())
                {
                    
                    eventtype[i] = new Classes.eventtype();
                    eventtype[i].Eventtype = reader.GetString(1);
                    eventtype[i].Price = reader.GetInt32(2);
                    i++;
                }
                reader.Close();
                command = new SqlCommand("Select * from nbroomsinfo", con);
                reader = command.ExecuteReader();
                i = 0;
                while (reader.Read())
                {
                    i++;
                }
                reader.Close();
                reader = command.ExecuteReader();
                
                Classes.nbroomsinfo[] nbroom = new Classes.nbroomsinfo[i];
                i = 0;
                while(reader.Read())
                {
                    nbroom[i] = new Classes.nbroomsinfo();
                    nbroom[i].Rooms = reader.GetInt16(1)+"";
                    nbroom[i].Price = reader.GetInt32(2);
                    i++;
                }
                reader.Close();
                
                command = new SqlCommand("Select * from roomsleft", con);
                reader = command.ExecuteReader();
                i = 0;
                while (reader.Read())
                {
                    i++;
                }
                reader.Close();
                reader = command.ExecuteReader();
                
                Classes.roomsize[] roomsize = new Classes.roomsize[i];
                i = 0;
                while(reader.Read())
                {
                    roomsize[i] = new Classes.roomsize();
                    roomsize[i].Size = reader.GetString(1);
                    roomsize[i].Price = reader.GetInt32(3);
                    i++;
                }
                
                reader.Close();
                command = new SqlCommand("Select * from roomtypeinfo", con);
                reader = command.ExecuteReader();
                i = 0;
                while (reader.Read())
                {
                    i++;
                }
                reader.Close();
                reader = command.ExecuteReader();
                
                Classes.roomtype[] roomtype = new Classes.roomtype[i];
                i = 0;
                while(reader.Read())
                {
                    roomtype[i] = new Classes.roomtype();
                    roomtype[i].Roomtype = reader.GetString(1);
                    roomtype[i].Price = reader.GetInt32(2);
                    i++;
                }
                return Tuple.Create(eventtype, nbroom, roomsize, roomtype);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create(new Classes.eventtype[5], new Classes.nbroomsinfo[5], new Classes.roomsize[5], new Classes.roomtype[5]);
        }
        public Tuple<string,string,string> getEditNbRoomsLeft()
        {
            try
            {
                string[] data = new string[3];
                int i = 0;
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from roomsleft", con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        data[i] = reader.GetString(2);
                        i++;
                    }
                    
                }
                return Tuple.Create(data[2], data[1], data[0]);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create("", "", "");
        }
        public bool updatenbroomsleft(string small,string meduim,string large)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Update roomsleft set nbrooms='"+small+"' where roomtype='Small'", con);
                command.ExecuteNonQuery();
                command = new SqlCommand("Update roomsleft set nbrooms='" + meduim+ "' where roomtype='Meduim'", con);
                command.ExecuteNonQuery();
                command = new SqlCommand("Update roomsleft set nbrooms='" + large+ "' where roomtype='Large'", con);
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool adminLogin(string user,string pw)
        {
            try 
            {
                SqlConnection con = con1();
                SqlCommand cmd = new SqlCommand("Select * from admininfo",con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        //MessageBox.Show("here");
                        if(reader.GetString(1)==user&&reader.GetString(2)==pw)
                        {
                            return true;
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public Tuple<string,string,string> getNbRoomsLeft()
        {
            try
            {
                int i = 0;
                string[] data = new string[3];
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from roomsleft",con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        data[i] = reader.GetString(1)+" Rooms Left: "+reader.GetString(2);
                        i++;
                    }
                }
                return Tuple.Create(data[0], data[1], data[2]);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create("", "", "");
        }
        public bool userRegister(string username,string password,string email,string phone)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command1 = new SqlCommand("Select username from userinfo where username='"+username+"'",con);
                SqlDataReader reader = command1.ExecuteReader();
                
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        
                        return false;
                    }
                }
                reader.Close();
                SqlCommand command = new SqlCommand("Insert into userinfo(username,pass,email,phone,roomsbooked) values('"+username+"','"+password+"','"+email+"','"+phone+"','0')", con);
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool updateBookedRoom(string id,string roomtype,string nbpeople,string roomsize,string sofa,string eventtype)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Update roominfo set roomtype='"+roomtype+"',nbpeople='"+nbpeople+"',roomsize='"+roomsize+"',sofa='"+sofa+"',eventtype='"+eventtype+"' where roomid="+id,con);
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception)
            {

            }
            return false;
        }
        public Tuple<bool,DataTable> searchUser(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from userinfo where id="+id,con);
                using(command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    return Tuple.Create(true, dt);
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create(false,dt);
        }
        public Tuple<bool,DataTable> findRoom(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from roominfo where id="+id,con);
                using(command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    return Tuple.Create(true, dt);
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create(false, dt);
        }
        public bool deleteBookedRoom(string id)
        {
            try
            {
                SqlConnection con = con1();
                SqlCommand command = new SqlCommand("delete from roominfo where roomid="+id,con);
                con.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public DataTable bookedroomsInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = con1();
                SqlCommand command = new SqlCommand("Select * from roominfo", con);
                con.Open();
                using(command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public DataTable userinfoSearch(string id)
        {
            DataTable dt=new DataTable();
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from userinfo where id="+id,con);
                using (command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public DataTable userinfo()
        {
            DataTable dt= new DataTable(); ;
            try
            {
                
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from userinfo", con);
                using(command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    
                    dt.Load(reader);
                    
                }
            }
            catch(System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dt;
        }
        public bool updateUserAdmin(string id,string username,string password,string email,string phone,string roomsbooked)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                //SqlCommand com = new SqlCommand("Select username,pass from userinfo where id=" + id,con);
                //SqlDataReader reader = com.ExecuteReader();
                //while(reader.Read())
                //{
                //    if(reader.HasRows)
                //    {
                //        MessageBox.Show("username already exists");
                //        return false;
                //    }
                //}
                string query="UPDATE userinfo SET username='"+username+"',pass='"+password+"',email='"+email+"',phone='"+phone+"',roomsbooked='"+roomsbooked+"' where id="+id;
                SqlCommand command = new SqlCommand(query,con);
                
                //MessageBox.Show("here1");
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool updateUserAdminSearch(string id,string email,string phone,string roomsbooked)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("update userinfo set email='"+email+"',phone='"+phone+"',roomsbooked='"+roomsbooked+"' where id="+id, con);
                command.ExecuteNonQuery();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool deleteUserAdmin(string id)
        {
            try
            {
                SqlConnection con = con1();
                SqlCommand command = new SqlCommand("Delete from userinfo where id="+id,con);
                con.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public Tuple<bool,string[]> searchUserAdmin(string username)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from userinfo where username='"+username+"'", con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        string[] z={reader.GetInt32(0) + "", reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)};
                        return Tuple.Create(true, z);
                    }

                }
                MessageBox.Show("Username not found");
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create(false, new string[5]);
        }
        public DataTable viewpastrooms(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from clearance where id="+id,con);
                using(command)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    return dt;
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public Tuple<string,string,string,string> updateUseruser(int id)
        {
            try
            {
                SqlConnection con = con1();
                con.Open();
                SqlCommand command = new SqlCommand("Select * from userinfo where id="+id,con);
                SqlDataReader reader = command.ExecuteReader();
                MessageBox.Show("here");
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        return Tuple.Create(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create("", "", "", "");
        }
        public Tuple<bool,int> userlogin(string user,string pw)
        {
            try
            {
                SqlConnection con = con1();
                SqlCommand cmd = new SqlCommand("Select * from userinfo where username='"+user+"' and pass='"+pw+"'",con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    if(reader.HasRows)
                    {
                        return Tuple.Create(true,reader.GetInt32(0));
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create(false,0);
        }
    }
}
