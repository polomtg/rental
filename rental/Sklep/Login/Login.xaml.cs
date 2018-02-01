using System.Windows;
using System.Windows.Controls;

namespace Sklep.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
         }

        public void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.LoginName =  LogName.Text;
            LoginViewModel.LoginPass = PassName.Password;
        }

    }
}
