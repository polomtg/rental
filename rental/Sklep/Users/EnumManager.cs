using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Users
{
    public class EnumManager
    {
        public static Array GetValue(Type Enumeration)
        {
            Array enumList = Enum.GetValues(Enumeration);

            return enumList;
        }
    }
}
