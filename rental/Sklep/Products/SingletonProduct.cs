﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Products
{
    public class SingletonProduct
    {
        private static SingletonProduct _Instance = null;
        public ObservableCollection<Product> products;
        Data.SQLManager sqlUpdate = null;

        private SingletonProduct()
        {
            products = new ObservableCollection<Product>();
            sqlUpdate = new Data.SQLManager("SELECT * FROM Products");
        }

        public static SingletonProduct Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SingletonProduct(); ;

                return _Instance;
            }
        }

        public void add(Product tmp)
        {
            products.Add(tmp);

            DataRow dataRow = sqlUpdate.getDataRow();
            dataRow[0] = tmp.ID;
            dataRow[1] = tmp.name;
            dataRow[2] = tmp.categoryS;
            dataRow[3] = tmp.price;
            dataRow[4] = tmp.amount;
            dataRow[5] = tmp.available;

            sort();
            sqlUpdate.addToDB(dataRow, 6);
        }

        public void remove(Product tmp)
        {
            products.Remove(tmp);
            sqlUpdate.removeFromDB(0, tmp.ID);
        }

        public void loadData()
        {
            DataSet ds = sqlUpdate.getData();

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    int ID = Convert.ToInt32(row[0]);
                    string name = Convert.ToString(row[1]);
                    string kategoria = Convert.ToString(row[2]);
                    double tmp = Convert.ToDouble(row[3]);
                    float cena = (float)tmp;
                    int ilosc = Convert.ToInt32(row[4]);
                    int dostepne = Convert.ToInt32(row[5]);

                    products.Add(new Product(ID, name, kategoria, cena, ilosc, dostepne));
                    if(Product.GET_ID < ID)
                    Product.GET_ID = ID;
                }
            }
        }

        private void sort()
        {
            products.OrderBy(product => product.ID);
        }
    }
}
