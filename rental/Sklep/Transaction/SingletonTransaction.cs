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

            DataRow dataRow = sqlUpdate.getDataRow();

            dataRow[0] = tmp.customer;
            dataRow[1] = tmp.product;
            dataRow[2] = tmp.ID;
            dataRow[3] = tmp.date;
            dataRow[4] = tmp.amount;
            dataRow[5] = true;

            if (tmp.type == Type.WYNAJEM)
                dataRow[5] = false;

            sqlUpdate.addToDB(dataRow, 6);
        }

        public void remove(Transaction tmp)
        {
            transactions.Remove(tmp);
            sqlUpdate.removeFromDB(2, tmp.ID, tmp.customer);
        }

        public void loadData()
        {
            DataSet ds = sqlUpdate.getData();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    string customer = Convert.ToString(row[0]);
                    string product = Convert.ToString(row[1]);
                    int ID = Convert.ToInt32(row[2]);
                    DateTime date = Convert.ToDateTime(row[3]);
                    int amount = Convert.ToInt32(row[4]);
                    bool reservation = Convert.ToBoolean(row[5]);

                    transactions.Add(new Transaction(customer, ID, product, date, amount, reservation ));
                }
            }
        }
    }
}
