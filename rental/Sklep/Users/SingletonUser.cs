using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Users
{
    public class SingletonUser
    {
        private static SingletonUser _Instance = null;
        public ObservableCollection<User> users;
        Data.SQLManager sqlUpdate = null;

        private SingletonUser()
        {
            users = new ObservableCollection<User>();
            sqlUpdate = new Data.SQLManager("SELECT * FROM User");
        }

        public static SingletonUser Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SingletonUser(); ;

                return _Instance;
            }
        }

        public void add(User tmp)
        {
            users.Add(tmp);
            // sqlUpdate.addToDB(tmp);
        }

        public void remove(User tmp)
        {
            users.Remove(tmp);
            // sqlUpdate.removeFromDB(1, tmp.NIP);
        }

        public void loadData()
        {
            /* DataSet ds = sqlUpdate.getData();

             foreach (DataTable table in ds.Tables)
             {
                 foreach (DataRow row in table.Rows)
                 {
                     string name = Convert.ToString(row[0]);
                     int NIP = Convert.ToInt32(row[1]);
                     string adress = Convert.ToString(row[2]);

                     customers.Add(new Customer(name, NIP, adress));
                 }
             }*/
        }
    }
}
