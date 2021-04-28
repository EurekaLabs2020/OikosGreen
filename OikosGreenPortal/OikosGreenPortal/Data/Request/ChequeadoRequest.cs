using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{

    public class ChequeadosRequest
    {
        public List<Chequeado_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class ChequeadoRequest
    {
        public Chequeado_data entity { get; set; }
        public Status status { get; set; }
    }

    public class Chequeado_data
    {
        public Int64 id { get; set; }
        public Int64 detallemovimientoid { get; set; }
        public String asignaid { get; set; }
        public String chequeaid { get; set; }
        public Decimal quantity { get; set; }
        public DateTime dateinitial { get; set; }
        public DateTime datefinal { get; set; }
        public Int64 conceptid { get; set; }

    }

}
