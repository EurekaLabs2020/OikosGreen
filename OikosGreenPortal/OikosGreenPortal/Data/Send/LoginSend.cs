using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Send
{
    public class LoginSend
    {
        public String user { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String numdoc { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String password { get; set; }
        public long? iddocument { get; set; }
    }
}
