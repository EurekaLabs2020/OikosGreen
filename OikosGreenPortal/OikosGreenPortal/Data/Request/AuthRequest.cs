using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class AuthRequest
    {
        public LoginRequest responseLogin { get; set; }
        public Status status { get; set; }
    }

    public class LoginRequest 
    {
        public String token { get; set; }
        public DateTime expiration { get; set; }
        public String user { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String typedoc { get; set; }
        public String numdoc { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String iduser { get; set; }

        [NotMapped]
        public virtual String nombrefull { get { return name.Trim().ToUpper() + " " + lastname.Trim().ToUpper(); } }
    }

}
