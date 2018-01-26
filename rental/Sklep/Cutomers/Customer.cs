using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Cutomers
{
    public class Customer : INotifyPropertyChanged
    {
        private string _name;
        private long _NIP;
        private string _adress;

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer(string nameT, long NIPT, string adressT)
        {
            _name = nameT;
            _NIP = NIPT;
            _adress = adressT;

        }

        private void RisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return name;
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

        public long NIP
        {
            get { return _NIP; }
            set
            {
                _NIP = value;
                RisePropertyChanged("NIP");
            }
        }

        public string adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
                RisePropertyChanged("adress");
            }
        }

        #endregion

    }
}
