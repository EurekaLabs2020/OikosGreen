using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class UsuariosRequest
    {
        public List<Usuario_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class UsuarioRequest
    {
        public Usuario_data entity { get; set; }
        public Status status { get; set; }
    }


    public class Usuario_data 
    { 
        public String id { get; set; }
        public String user { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String numdoc { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String typedoc { get; set; }
        public String namedoc { get; set; }
        public Boolean isactive { get; set; }
        public String password { get; set; }
        public String passwordconfirm { get; set; }
        public String passTMP { get; set; }
        public long? iddocument { get; set; }
        public Boolean state { get; set; }
    }

}
