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
        public static ObservableCollection<Product> products = new ObservableCollection<Product>();

        public ProductViewModel()
        {
        }

        public void LoadProducts()
        {
            products.Add(new Product("Koparka", Category.SHELF, 44.90f, 5, 5));
            products.Add(new Product("Koparka", Category.SHELF, 44.90f, 5, 5));
            products.Add(new Product("Koparka", Category.SHELF, 44.90f, 5, 5));
        }

        #region Data Management

        public static void add()
        {
            var dodaj = new NewProduct();

            if (dodaj.ShowDialog() == true)
                products.Add(new Product(dodaj.name, dodaj.category, dodaj.price, dodaj.amount, dodaj.amount));
        }

        public static void remove(Product product)
        {
            products.Remove(product);
        }

        public static void giveBack(int ID_T, int amount_T)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ID == ID_T)
                    products[i].amount += amount_T;
            }
        }

        public static void newTransaction(Product tmp)
        {
            var transakcja = new NewTransaction(tmp.amount);

            if (transakcja.ShowDialog() == true)
            {
                Transaction.TransactionViewModel.add(transakcja.customer, tmp.ID, tmp.name, transakcja.date, transakcja.amount, transakcja.ifReservation);

                if (!transakcja.ifReservation)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i].ID == tmp.ID)
                            products[i].amount -= transakcja.amount;
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
