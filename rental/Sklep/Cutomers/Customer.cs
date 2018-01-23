using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Cutomers
{
    public class Customer
    {

        private string _name;
        private long _NIP;
        private string _adress;

        /// <summary>
        /// Gettery i Settery
        /// </summary>
        #region
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public long NIP
        {
            get { return _NIP; }
            set { _NIP = value; }
        }

        public string adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
        #endregion

    }
}
