using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class RolesRequest
    {
        public List<Rol_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class RolRequest
    {
        public Rol_data entity { get; set; }
        public Status status { get; set; }
    }


    public class Rol_data
    { 
        public String id { get; set; }
        public String name { get; set; }
    }
}
