using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class TransportadorasRequest
    {
        public List<Transportadora_Data> entities { get; set; }
        public Status status { get; set; }
    }

    public class TransportadoraRequest
    {
        public List<Transportadora_Data> entity { get; set; }
        public Status status { get; set; }
    }

    public class Transportadora_Data
    {
        public Int64 id { get; set; }
        public String type { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime datemodify { get; set; }
        public Boolean active { get; set; }
    }

}
