using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class PresentacionesRequest
    {
        public List<Presentacion_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class PresentacionRequest
    {
        public Presentacion_data entity { get; set; }
        public Status status { get; set; }
    }
    public class Presentacion_data
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
    }
}

