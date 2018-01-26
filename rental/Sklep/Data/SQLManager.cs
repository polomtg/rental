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

        public void removeFromDB(int row, string text)
        {
            connect();
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                var d = dataTable.Rows[i];
                string dt_ID = Convert.ToString(d[row]);

                if (text == dt_ID)
                {
                    dataTable.Rows[i].Delete();
                    break;
                }
            }

            dataAdapter.Update(dataSet);
        }

        public void removeFromDB(int row, int ID, string customer)
        {
            connect();
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                var d = dataTable.Rows[i];
                string klient = Convert.ToString(d[0]);

                if (customer == klient)
                {
                    int ID_T = Convert.ToInt32(d[row]);
                    if (ID_T == ID)
                    {
                        dataTable.Rows[i].Delete();
                        break;
                    }
                }
            }

            dataAdapter.Update(dataSet);
        }

        public void addToDB(DataRow dataRow, int columns)
        {
            connect();
            DataRow data = dataTable.NewRow();

            for (int i = 0; i < columns; i++)
                data[i] = dataRow[i];

            dataTable.Rows.Add(data);
            dataAdapter.Update(dataSet);
        }

        public DataSet getData()
        {
            return dataSet;
        }

        public DataRow getDataRow()
        {
            return dataTable.NewRow();
        }
    }
}
