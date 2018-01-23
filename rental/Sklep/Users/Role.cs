using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Users
{
    public enum Role
    {
        [Description("ADMIN")]
        ADMIN,
        [Description("USER")]
        USER,
        [Description("GUEST")]
        GUEST
    }
}
