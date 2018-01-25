using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Transaction
{
    public enum Type
    {
        REZERWACJA,
        WYNAJEM
    }

    public class Transaction
    {
        private string _customer;
        private string _product;
        private int _ID;
        private DateTime _date;
        private int _amount;
        Type _type;

        public Transaction(string customerT, int IDT, string productT, DateTime dateT, int amountT, bool ifReservationT)
        {
            _customer = customerT;
            _product = productT;
            _ID = IDT;
            _date = dateT;
            _amount = amountT;

            if (ifReservationT)
                _type = Type.REZERWACJA;
            else
                _type = Type.WYNAJEM;
        }

        #region Gettery i Settery

        public string customer
        {
            get { return _customer;}
            set
            {
                _customer = value;
            }
        }

        public string product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public int amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public Type type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string typeS
        {
            get { return _type.ToString(); }
        }

        #endregion
    }
}
