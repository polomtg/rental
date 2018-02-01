using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Users
{
    public class User : INotifyPropertyChanged 
    {
        private string _name;
        private string _email;
        private Role _role;

        public User(string Tname, string Temail, Role Trole)
        {
            _name = Tname;
            _email = Temail;
            _role = Trole;
        }

        /// <summary>
        /// Gettery i Settery
        /// </summary>
        #region

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                RisePropertyChanged("name");
            }
        }

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                RisePropertyChanged("email");
            }
        }

        public string rolaS
        {
            get { return Convert.ToString(_role); }
        }

        public Role rolaE
        {
            get { return _role; }
            set
            {
                _role = value;
                RisePropertyChanged("rolaE");
            }
        }

        public IEnumerable<DataRow> Rows { get; internal set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
