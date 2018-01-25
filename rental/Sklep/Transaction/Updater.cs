using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Transaction
{
    public class Updater : ICommand
    {
        private Action commandTask;
        private Action<Transaction> taskParameter;

        public Updater(Action workToDo)
        {
            commandTask = workToDo;
        }

        public Updater(Action<Transaction> workToDo)
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

        public void Execute(object parameter)
        {
            if (parameter == null)
                commandTask();
            else
                taskParameter(parameter as Transaction);
        }
    }
}
