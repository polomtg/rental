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

        public static void addCustomer() //static
        {
            var dodaj = new NewCustomer();

            if (dodaj.ShowDialog() == true)
                customers.Add(new Customer(dodaj.name, dodaj.NIP, dodaj.adress));
        }
        
        public static void removeCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        private ICommand mUpdater;

        public ICommand UpdateCommandProduct
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater(); //ref products

                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

    }
}
