﻿using System;
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
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        private string _name;
        private Category _category;
        private float _price;
        private int _amount;
        private int _ID;

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

        public int ID
        {
            get { return _ID; }
        }

        public NewProduct()
        {
            InitializeComponent();
        }

        public NewProduct(Product product)
        {
            InitializeComponent();

            _name = product.name;
            _category = product.categoryE;
            _price = product.price;
            _amount = product.amount;
            _ID = product.ID;

            NameTxt.Text = _name;
            PriceTxt.Text = _price.ToString();
            AmountTxt.Text = _amount.ToString();
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            _name = NameTxt.Text;

            if(CategoryTxt.SelectedValue != null)
                _category =(Category) CategoryTxt.SelectedValue;

            _price = float.Parse(PriceTxt.Text, System.Globalization.CultureInfo.InvariantCulture);
            _amount = Int32.Parse(AmountTxt.Text);
            
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

        private void NumberValidationFloat(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9.]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

    }
}
