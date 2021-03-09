using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class SaldoProductosRequest
    {
        public List<SaldoProducto_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class SaldoProductoRequest
    {
        public SaldoProducto_data entity { get; set; }
        public Status status { get; set; }
    }
    public class SaldoProducto_data
    {
        public Int64 id { get; set; }
        public Int64 idproducto { get; set; }
        public Int64 productoid { get; set; }
        public Int64 cellarid { get; set; }
        public String cellarname { get; set; }
        public String period { get; set; }
        public Decimal initialbalance { get; set; }
        public Decimal initialvalue { get; set; }
        public Decimal inputquantity { get; set; }
        public Decimal inputvalue { get; set; }
        public Decimal outputquantity { get; set; }
        public Decimal outputvalue { get; set; }
        public Decimal balancequantity { get; set; }
        public Decimal balancevalue { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String codeprod { get; set; }
        public String nameprod { get; set; }
        public Decimal costprod { get; set; }

    }
}
