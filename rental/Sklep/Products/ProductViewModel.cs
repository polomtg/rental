using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Products
{
    public class ProductViewModel
    {
        public SingletonProduct products = SingletonProduct.Instance;

        public ProductViewModel()
        {

        }

        public void LoadProducts()
        {
            products.loadData();
        }

        #region Data Management

        public void add()
        {
            var dodaj = new NewProduct();

            if (dodaj.ShowDialog() == true)
                products.add(new Product(dodaj.name, dodaj.category, dodaj.price, dodaj.amount, dodaj.amount));
        }

        public void remove(Product product)
        {
            products.remove(product);
        }

        public void giveBack(int ID_T, int amount_T)
        {
            for (int i = 0; i < products.products.Count; i++)
            {
                if (products.products[i].ID == ID_T)
                {
                    products.products[i].amount += amount_T;
                    var operation = products.products[i];
                    remove(products.products[i]);
                    products.add(operation);
                    break;
                }
            }
        }

        public void newTransaction(Product tmp)
        {
            var transakcja = new NewTransaction(tmp.amount);

            if (transakcja.ShowDialog() == true)
            {
                Transaction.TransactionViewModel tempT = new Transaction.TransactionViewModel();
                tempT.add(transakcja.customer, tmp.ID, tmp.name, transakcja.date, transakcja.amount, transakcja.ifReservation);

                if (!transakcja.ifReservation)
                {
                    for (int i = 0; i < products.products.Count; i++)
                    {
                        if (products.products[i].ID == tmp.ID)
                        {
                            products.products[i].amount -= transakcja.amount;
                            var operation = products.products[i];
                            remove(products.products[i]);
                            products.add(operation);
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region Commands

        public ICommand UpdateCommandProduct
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
        
        public ICommand startTransaction
        {
            get
            {
                return new UpdaterTransaction(newTransaction);
            }
        }

        #endregion
    }
}
