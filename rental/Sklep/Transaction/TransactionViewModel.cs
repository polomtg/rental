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
        public static ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

        #region Data Managment

        public static void add(string customer, int ID, string product, DateTime date, int amount, bool ifReservation)
        {
            transactions.Add(new Transaction(customer, ID, product, date, amount, ifReservation));

        }

        public static void remove(Transaction transaction)
        {
            int amount = transaction.amount;
            if (transaction.type == Type.REZERWACJA)
                amount = 0;

            Products.ProductViewModel.giveBack(transaction.ID, amount);
            transactions.Remove(transaction);
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

