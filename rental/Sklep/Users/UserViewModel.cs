using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sklep.Users
{
    public class UserViewModel
    {
        public SingletonUser users = SingletonUser.Instance;

        public UserViewModel()
        {
        }

        public bool CheckUser(string LoginName)
        {
            if ( users.returnEmail(LoginName))
            {
                return true;
            }
            return false;
        }
      
        public void LoadUsers()
        {
            users.loadData();
        }

        #region Data Management

        public void add()
        {
            var dodaj = new NewUser();

            if (dodaj.ShowDialog() == true)
                users.add(new User(dodaj.name, dodaj.email, dodaj.rola));
        }

        public void remove(User user)
        {
            users.remove(user);
        }

        public void edit(User user)
        {
            var edytuj = new NewUser(user);

            if (edytuj.ShowDialog() == true)
            {
                remove(user);
                users.add(new User(edytuj.name, edytuj.email, edytuj.rola));
            }
        }

        #endregion

        #region Command

        public ICommand UpdateCommand
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
