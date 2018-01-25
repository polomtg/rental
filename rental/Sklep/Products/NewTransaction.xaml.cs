using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public NewTransaction()
        {
            InitializeComponent();
            GetCustomer.ItemsSource = Sklep.Cutomers.CustomerViewModel.customers;
        }

        private string _customer;
        private DateTime _date;
        private int _amount;

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

        #endregion

        private void DodajTranskacje_Click(object sender, RoutedEventArgs e)
        {
            _customer = GetCustomer.SelectedItem.ToString();
             _date = DateTxt.SelectedDate.Value;
            _amount = 2;//Int32.Parse(AmountTxt.Text);

            DialogResult = true;
        }

        private void AnulujTranskacje_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

