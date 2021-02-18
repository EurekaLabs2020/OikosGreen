using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class UbicacionesRequest
    {
        public List<Ubicacion_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class UbicacionRequest
    {
        public Ubicacion_data entity { get; set; }
        public Status status { get; set; }
    }

    public class Ubicacion_data
    {
        public Int64 id { get; set; }
        public String type { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public Int64 parent { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String typeparent { get; set; }
        public String codeparent { get; set; }
        public String nameparent { get; set; }
    }


}
