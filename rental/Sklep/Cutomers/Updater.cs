using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Cutomers
{
    public class Updater : ICommand
    {
        private Action commandTask;
        private Action<Customer> taskParameter;


        public Updater(Action workToDo)
        {
            commandTask = workToDo;
        }

        public Updater(Action<Customer> workToDo)
        {
            taskParameter = workToDo;
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

      /*  public void Execute(object parameter)
        {
            if (parameter == null)
                CustomerViewModel.add();
            else
                CustomerViewModel.remove(parameter as Customer);
        }*/

        public void Execute(object parameter)
        {
            if (parameter == null)
                commandTask();
            else
                taskParameter(parameter as Customer);
        }
    }
}
