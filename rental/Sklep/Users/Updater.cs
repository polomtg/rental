using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Users
{
    public class Updater : ICommand
    {

        public Updater()
        {
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }     
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
                UserViewModel.add();
            else
                UserViewModel.remove(parameter as User);
        }
    }
}
