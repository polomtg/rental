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

namespace Sklep.Users
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        private string _name;
        private string _email;
        private Role _rola = Role.USER;

        public NewUser()
        {
            InitializeComponent();
        }

        public string name
        {
            get { return _name; }
        }

        public string email
        {
            get { return _email; }
        }

        public Role rola
        {
            get { return _rola; }
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            _name = ImieTxt.Text;
            _email = EmailTxt.Text;
            _rola = Role.USER;

            DialogResult = true;
        }

        private void AnalujBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
