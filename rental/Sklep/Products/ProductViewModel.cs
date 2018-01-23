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
            LoadProducts();
        }

        public void LoadProducts()
        {
            products.Add(new Product("Koparka", Category.SHELF, 44.90f, 5));
            products.Add(new Product("Koparka", Category.SHELF, 44.90f, 5));
            products.Add(new Product("Koparka", Category.SHELF, 44.90f, 5));
        }

        public static void addProduct()
        {
            var dodaj = new NewProduct();

            if (dodaj.ShowDialog() == true)
                products.Add(new Product(dodaj.name, dodaj.category, dodaj.price, dodaj.amount));
        }

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
    }
}
