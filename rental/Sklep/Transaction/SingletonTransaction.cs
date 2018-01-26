using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Transaction
{
    public class SingletonTransaction
    {
        private static SingletonTransaction _Instance = null;
        public ObservableCollection<Transaction> transactions;
        Data.SQLManager sqlUpdate = null;

        private SingletonTransaction()
        {
            transactions = new ObservableCollection<Transaction>();
            sqlUpdate = new Data.SQLManager("SELECT * FROM Trasaction");
        }

        public static SingletonTransaction Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SingletonTransaction(); ;

                return _Instance;
            }
        }

        public void add(Transaction tmp)
        {
            transactions.Add(tmp);
           // sqlUpdate.addToDB(tmp);
        }

        public void remove(Transaction tmp)
        {
            transactions.Remove(tmp);
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
