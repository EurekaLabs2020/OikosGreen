using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class TerceroPuntosRequest
    {
        public List<TerceroPunto_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class TerceroPuntoRequest
    {
        public TerceroPunto_data entity { get; set; }
        public Status status { get; set; }
    }
    public class TerceroPunto_data
    {
        public Int64 id { get; set; }
        public Int64 idtercero { get; set; }
        public String period { get; set; }
        public Decimal? previousbalance { get; set; }
        public Decimal? input { get; set; }
        public Decimal? output { get; set; }
        public Decimal? currentbalance { get; set; }
        public Int64? terceroid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String numdocument { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
    }
}
