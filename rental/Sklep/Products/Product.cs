using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Products
{
    public class Product : INotifyPropertyChanged
    {
        static int GETID = 1010100;

        private int _ID;
        private string _name;
        private Category _category;
        private float _price;
        private int _amount;

        public Product(string nameT, Category categoryT, float priceT, int amountT)
        {
            _ID = GETID + 10;
            _name = nameT;
            _category = categoryT;
            _price = priceT;
            _amount = amountT;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }


        /// <summary>
        /// Gettery i Settery
        /// </summary>
        #region

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                RisePropertyChanged("name");
            }
        }

        public string categoryS
        {
            get { return Convert.ToString(_category); }
        }

        public Category categoryE
        {
            set
            {
                _category = value;
                RisePropertyChanged("categoryE");
            }
        }

        public float price
        {
            get { return _price; }
            set
            {
                _price = value;
                RisePropertyChanged("price");
            }
        }

        public int amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RisePropertyChanged("amount");
            }
        }
        #endregion
    }
}
