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
            if(commandTask != null)
                return true;

            if (parameter != null)
                return true;

            return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (parameter == null)
                commandTask();
            else
                taskParameter(parameter as Customer);
        }
    }
}
