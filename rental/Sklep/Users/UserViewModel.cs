using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public static ObservableCollection<User> users = new ObservableCollection<User>();

        public UserViewModel()
        {
        }
      
        public void LoadUsers()
        { 
            users.add( new User("Jan Kowalski", "kowalski@o2.pl", Users.Role.GUEST));
            users.add(new User("Mr Nobody", "nobody@gmail.pl", Users.Role.ADMIN));
            users.add(new User("Neo", "matrix@rm.pl", Users.Role.USER));
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

        #endregion
    }
}
