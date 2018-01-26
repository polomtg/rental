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

namespace Sklep.Cutomers
{
    /// <summary>
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        private string _name;
        private long _NIP;
        private string _adress;

        public NewCustomer()
        {
            InitializeComponent();
        }

        public NewCustomer(Customer customer)
        {
            InitializeComponent();
            _name = customer.name;
            _NIP = customer.NIP;
            _adress = customer.adress;

            int index = customer.name.IndexOf(" ");

            NameTxt.Text = _name.Substring(0, index);
            SurnameTxt.Text = _name.Substring(index + 1, _name.Length - index - 1);
            NIPTxt.Text = Convert.ToString(NIP);
            AdressTxt.Text = _adress;
        }

        public string name
        {
            get { return _name; }
        }

        public long NIP
        {
            get { return _NIP; }
        }

        public string adress
        {
            get { return _adress; }
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            _name = NameTxt.Text;
            _name += " ";
            _name += SurnameTxt.Text;
            _NIP = long.Parse(NIPTxt.Text);
            _adress = AdressTxt.Text;

            DialogResult = true;
        }

        private void AnalujBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
