﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sklep.Transaction
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        TransactionViewModel viewModel = new TransactionViewModel();

        public TransactionView()
        {
            InitializeComponent();

            if(viewModel.transactions.transactions != null)
                ListViewTransaction.ItemsSource = viewModel.transactions.transactions;
        }
    }
}
