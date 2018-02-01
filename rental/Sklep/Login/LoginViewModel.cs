using System;
using System.Windows.Input;
using System.Windows;

namespace Sklep.Login
{
    public class LoginViewModel
    {
        static public string LoginName;
        static public string LoginPass;

        public Sklep.Users.UserViewModel userToCheck = new Sklep.Users.UserViewModel();

        public void TryLogin()
        {
            //Console.WriteLine(LoginName);
            //Console.WriteLine(LoginPass);
            if (userToCheck.CheckUser(LoginName))
            {
                Window2 sec = new Window2();
                Application.Current.Windows[0].Close();
                sec.ShowDialog();
            }
        }

        public ICommand SendTryLogin
        {
            get
            {
                return new Updater(TryLogin);
                
            }
        }

    }
}
