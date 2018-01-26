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
        private Role _rola;

        public NewUser()
        {
            InitializeComponent();
        }

        public NewUser(User user)
        {
            InitializeComponent();
            _name = user.name;
            _email = user.email;
            _rola = user.rolaE;

            int index = _name.IndexOf(" ");

            if (index != -1)
            {
                ImieTxt.Text = _name.Substring(0, index);
                NazwiskoTxt.Text = _name.Substring(index + 1, _name.Length - index - 1);
            }
            else
               ImieTxt.Text = _name;

            EmailTxt.Text = _email;
        }

        #region Gettery i Settery

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

        #endregion

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ImieTxt.Text != null && ImieTxt.Text != "")
                _name = ImieTxt.Text;
            if (ImieTxt.Text != null && ImieTxt.Text != "")
                _name += " ";
            if (ImieTxt.Text != null && ImieTxt.Text != "")
                _name += NazwiskoTxt.Text;

            _email = EmailTxt.Text;

            if(RolaTxt.SelectedValue != null)
                _rola = (Role)RolaTxt.SelectedValue;

            DialogResult = true;
        }

        private void AnalujBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
