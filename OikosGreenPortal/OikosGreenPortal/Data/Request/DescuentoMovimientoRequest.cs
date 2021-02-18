using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class DescuentoMovimientoRequest
    {
        public List<DescuentoMovimiento_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class DescuentoMovimientoData
    {
        public DescuentoMovimiento_data entity { get; set; }
        public Status status { get; set; }
    }

    public class DescuentoMovimiento_data
    {
        public Int64 id { get; set; }
        public String type { get; set; }
        public String classdto { get; set; }
        public Int64 originid { get; set; }
        public Decimal value { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
    }
}
