using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Sklep.Login
{
    public class LoginViewModel
    {
        public void TryLogin()
        {
            
            Window2 sec = new Window2();
            Application.Current.Windows[0].Close();
            sec.ShowDialog();
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
