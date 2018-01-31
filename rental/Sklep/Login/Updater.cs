using System;
using System.Windows.Input;

namespace Sklep.Login
{
    public class Updater : ICommand
    {
        private Action commandTask;
        private Action<Login> taskParameter;

        public Updater(Action workToDo)
        {
            commandTask = workToDo;
        }

        public Updater(Action<Login> workToDo)
        {
            taskParameter = workToDo;
        }

        public bool CanExecute(object parameter)
        {
            if (commandTask != null)
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
                taskParameter(parameter as Login);
        }
    }
}
