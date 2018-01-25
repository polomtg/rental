using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sklep.Products
{
    /// <summary>
    /// Interaction logic for Transkacja.xaml
    /// </summary>
    public partial class NewTransaction : Window
    {
        public NewTransaction(int amount_T)
        {
            InitializeComponent();
            GetCustomer.ItemsSource = Sklep.Cutomers.CustomerViewModel.customers;

            for (int i = 1; i <= amount_T; i++)
                AmountTxt.Items.Add(i);     
        }

        private string _customer;
        private DateTime _date;
        private int _amount;
        private bool _ifReservation;

        #region Gettery i Settery

        public string customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
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

        public bool ifReservation
        {
            get { return _ifReservation;}
            set { _ifReservation = value; }
        }

        #endregion

        private void DodajTranskacje_Click(object sender, RoutedEventArgs e)
        {
            _customer = GetCustomer.SelectedItem.ToString();
             _date = DateTxt.SelectedDate.Value;
            _amount = Int32.Parse(AmountTxt.SelectedItem.ToString());

            bool? tmp = ReservationBox.IsChecked;

            if (tmp == true)
                _ifReservation = true;
            else
                _ifReservation = false;

            DialogResult = true;
        }

        private void AnulujTranskacje_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

