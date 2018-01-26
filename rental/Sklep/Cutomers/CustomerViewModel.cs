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
        public SingletonCustomer customers = SingletonCustomer.Instance;

        public void LoadCustomer()
        {
            customers.loadData();
        }

        #region Data Managment

        public void add()
        {
            var dodaj = new NewCustomer();

            if (dodaj.ShowDialog() == true)
                customers.add(new Customer(dodaj.name, dodaj.NIP, dodaj.adress));     
        }
        
        public void remove(Customer customer)
        {
            customers.remove(customer);
        }

        public void edit(Customer customer)
        {
            var edytuj = new NewCustomer(customer);

            if(edytuj.ShowDialog() == true)
            {
                remove(customer);
                customers.add(new Customer(edytuj.name, edytuj.NIP, edytuj.adress));
            }
        }

        #endregion

        #region Commands

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
        public ICommand editCommand
        {
            get
            {
                return new Updater(edit);
            }
        }

        #endregion

    }
}
