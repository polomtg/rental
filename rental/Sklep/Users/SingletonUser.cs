using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

            DataRow dataRow = sqlUpdate.getDataRow();

            dataRow[0] = tmp.name;
            dataRow[1] = tmp.email;
            dataRow[2] = tmp.rolaS;

            sqlUpdate.addToDB(dataRow, 3);
        }

        public void remove(User tmp)
        {
            users.Remove(tmp);
            sqlUpdate.removeFromDB(1, tmp.email);
        }

        public void loadData()
        {
             DataSet ds = sqlUpdate.getData();

             foreach (DataTable table in ds.Tables)
             {
                 foreach (DataRow row in table.Rows)
                 {
                     string name = Convert.ToString(row[0]);
                     string email = Convert.ToString(row[1]);
                    string tmp = Convert.ToString(row[2]);
                     Role rola = (Role)Enum.Parse(typeof(Role), tmp);

                     users.Add(new User(name, email, rola));
                 }
             }
        }

        public bool returnEmail(string LoginName)
        {
            DataSet ds = sqlUpdate.getData();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    string email = Convert.ToString(row[1]);
                    if (email == LoginName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
