using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Send
{
    public class ChangePassword
    {
        public String user { get; set; }
        public String password { get; set; }
        public String passwordconfirm { get; set; }
        public String passTMP { get; set; }
    }
}
