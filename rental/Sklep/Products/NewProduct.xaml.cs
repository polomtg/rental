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
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        private string _name;
        private Category _category;
        private float _price;
        private int _amount;

        public string name
        {
            get { return _name; }
        }

        public Category category
        {
            get { return _category; }
        }

        public float price
        {
            get { return _price; }
        }

        public int amount
        {
            get { return _amount; }
        }

        public NewProduct()
        {
            InitializeComponent();
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            _name = NameTxt.Text;
            _category =(Category) CategoryTxt.SelectedValue;
            _price = float.Parse(PriceTxt.Text);
            _amount = Int32.Parse(AmountTxt.Text);
            
            DialogResult = true;
        }

        private void AnalujBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
