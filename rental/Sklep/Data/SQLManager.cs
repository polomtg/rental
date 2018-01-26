using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklep.Data
{
    public class SQLManager
    {
        private SQLiteDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private DataTable dataTable = null;
        private SQLiteConnection connection = null;
        private SQLiteCommand command = null;
        private SQLiteCommandBuilder commandBuilder = null;
        private string queryS = null;

        public SQLManager(string query)
        {
            queryS = query;
            connection = new SQLiteConnection("Data Source=Rental.s3db");
            command = connection.CreateCommand();
            command.CommandText = query;
            dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
            commandBuilder = new SQLiteCommandBuilder(dataAdapter);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
        }

        private void connect()
        {
            connection = new SQLiteConnection("Data Source=Rental.s3db");
            command = connection.CreateCommand();
            command.CommandText = queryS;
            dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
            commandBuilder = new SQLiteCommandBuilder(dataAdapter);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
        }

        public void removeFromDB(int row, long ID)
        {
            connect();
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                var d = dataTable.Rows[i];
                int dt_ID = Convert.ToInt32(d[row]);

                if(ID == dt_ID)
                {          
                    dataTable.Rows[i].Delete();
                    break;
                }
            }

            dataAdapter.Update(dataSet);
        }

        public void addToDB(Cutomers.Customer customer)
        {
            connect();
            DataRow oDataRow = dataTable.NewRow();
            oDataRow[0] = customer.name;
            oDataRow[1] = customer.NIP;
            oDataRow[2] = customer.adress;
            dataTable.Rows.Add(oDataRow);
            dataAdapter.Update(dataSet);
        }

        public DataSet getData()
        {
            return dataSet;
        }
    }
}
