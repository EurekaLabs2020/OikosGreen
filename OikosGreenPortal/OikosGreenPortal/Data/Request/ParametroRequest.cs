using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ParametroRequest
    {
        public List<Parametro_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class ParametroData
    {
        public Parametro_data entity { get; set; }
        public Status status { get; set; }
    }
    public class Parametro_data
    {
        public Int64 id { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
    }
}
