using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Cutomers
{
    public class CustomerViewModel
    {
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>(); 

        public void LoadCustomer()
        {
            customers.Add(new Customer("Andrzej Kowalski", 321312323, "Wólka Dolna"));
            customers.Add(new Customer("Jan Sobieski", 23123232, "Siedmiogród"));
            customers.Add(new Customer("PJ", 23123213, "W1"));
        }

        #region Data Managment

        public static void add() //static
        {
            var dodaj = new NewCustomer();

            if (dodaj.ShowDialog() == true)
                customers.Add(new Customer(dodaj.name, dodaj.NIP, dodaj.adress));
        }
        
        public static void remove(Customer customer)//static
        {
            customers.Remove(customer);
        }

        #endregion

        #region Commands

        //private ICommand mUpdater;

        public ICommand addCommand
        {
            get
            {
                return new Updater(add);
            }
        }
        public ICommand removeCommand
        {
            get
            {
                return new Updater(remove);
            }
        }

        #endregion

    }
}
