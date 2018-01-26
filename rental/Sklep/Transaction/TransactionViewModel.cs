using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sklep.Transaction
{

    public class TransactionViewModel
    {
        public SingletonTransaction transactions = SingletonTransaction.Instance;

        public void LoadTransaction()
        {

        }

        #region Data Managment

        public void add(string customer, int ID, string product, DateTime date, int amount, bool ifReservation)
        {
            transactions.add(new Transaction(customer, ID, product, date, amount, ifReservation));
        }

        public void remove(Transaction transaction)
        {
            int amount = transaction.amount;
            if (transaction.type == Type.REZERWACJA)
                amount = 0;

            Products.ProductViewModel p = new Products.ProductViewModel();

            p.giveBack(transaction.ID, amount);
            transactions.remove(transaction);
        }

        #endregion

        #region Commands

        public ICommand getBack
        {
            get
            {
                return new Updater(remove);
            }
        }

        #endregion

    }
}

