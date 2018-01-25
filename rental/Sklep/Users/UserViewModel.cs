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
        public static ObservableCollection<User> users = new ObservableCollection<User>();

        public UserViewModel()
        {
        }
      
        public void LoadUsers()
        { 
            users.Add( new User("Jan Kowalski", "kowalski@o2.pl", Users.Role.GUEST));
            users.Add(new User("Mr Nobody", "nobody@gmail.pl", Users.Role.ADMIN));
            users.Add(new User("Neo", "matrix@rm.pl", Users.Role.USER));
        }

        #region Data Management

        public static void add()
        {
            var dodaj = new NewUser();

            if (dodaj.ShowDialog() == true)
                users.Add(new User(dodaj.name, dodaj.email, dodaj.rola));
        }

        public static void remove(User user)
        {
            users.Remove(user);
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
