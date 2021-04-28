using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class RolOpcionesRequest
    {
        public List<RolOpcion_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class RolOpcionRequest
    {
        public RolOpcion_data entity { get; set; }
        public Status status { get; set; }
    }


    public class RolOpcion_data
    {
        public String rolid { get; set; }
        public Int64 opcionid { get; set; }
        public String permission { get; set; }
    }

}
