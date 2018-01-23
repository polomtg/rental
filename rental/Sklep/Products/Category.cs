using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Products
{
    public enum Category
    {
        [Description("CHAIR")]
        CHAIR,
        [Description("TABLE")]
        TABLE,
        [Description("SHELF")]
        SHELF
    }
}
