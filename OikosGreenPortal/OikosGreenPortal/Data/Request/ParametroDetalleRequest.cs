using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ParametroDetallesRequest
    {
        public List<ParametroDetalle_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class ParametroDetalleRequest 
    {
        public ParametroDetalle_data entity { get; set; }
        public Status status { get; set; }
    }

    public class ParametroDetalle_data 
    {
        public Int64 id { get; set; }
        public Int64 idparametro { get; set; }
        public Int64 parametroid { get; set; }
        public String value { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String codeparam { get; set; }
        public String nameparam { get; set; }
    }

}
