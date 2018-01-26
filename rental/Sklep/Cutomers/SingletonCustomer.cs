using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Cutomers
{
    public class SingletonCustomer
    {
        private static SingletonCustomer _Instance = null;
        public ObservableCollection<Customer> customers;
        Data.SQLManager sqlUpdate = null;

        private SingletonCustomer()
        {
            customers = new ObservableCollection<Customer>();
            sqlUpdate = new Data.SQLManager("SELECT * FROM Customers");
        }

        public static SingletonCustomer Instance
        {
            get
            {
                if(_Instance == null)
                    _Instance = new SingletonCustomer(); ;

                return _Instance;
            }
        }

        public void add(Customer tmp)
        {
            customers.Add(tmp);
            sqlUpdate.addToDB(tmp);
        }

        public void remove(Customer tmp)
        {
            customers.Remove(tmp);
            sqlUpdate.removeFromDB(1, tmp.NIP);
        }

        public void loadData()
        {     
            DataSet ds = sqlUpdate.getData();

            foreach(DataTable table in ds.Tables)
            {
                foreach(DataRow row in table.Rows)
                {
                    string name = Convert.ToString(row[0]);
                    int NIP = Convert.ToInt32(row[1]);
                    string adress = Convert.ToString(row[2]);

                    customers.Add(new Customer(name, NIP, adress));
                }
            }
        }

    }
}
