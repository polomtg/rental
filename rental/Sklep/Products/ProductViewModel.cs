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

        #endregion

        #region Commands

        private ICommand mUpdater;

        public ICommand UpdateCommandProduct
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Products.Updater();

                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        #endregion
    }
}
