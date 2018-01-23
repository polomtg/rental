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
        public static ObservableCollection<Customer> products = new ObservableCollection<Customer>();

        public void LoadCustomer()
        {
            products.Add(new Customer("Andrzej Kowalski", 321312323, "Wólka Dolna"));
            products.Add(new Customer("Jan Sobieski", 23123232, "Siedmiogród"));
            products.Add(new Customer("PJ", 23123213, "Angel Beats"));
        }

        public static void addProduct()
        {
            var dodaj = new NewCustomer();

            if (dodaj.ShowDialog() == true)
                products.Add(new Customer(dodaj.name, dodaj.NIP, dodaj.adress));
        }

        private ICommand mUpdater;

        public ICommand UpdateCommandProduct
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();

                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

    }
}
