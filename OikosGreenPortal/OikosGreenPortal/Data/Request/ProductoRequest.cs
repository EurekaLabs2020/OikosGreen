using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ProductosRequest
    {
        public List<Producto_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class ProductoRequest
    {
        public Producto_data entity { get; set; }
        public Status status { get; set; }
    }

    public class Producto_data
    {
        public Int64 id { get; set; }
        public Int64 idtypeproduct { get; set; }
        public Int64 idiva { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public Decimal cost { get; set; }
        public Int64 presentationid { get; set; }
        public Int64 unitsaleid { get; set; }
        public Int64 unitbuyid { get; set; }
        public Int64 unitinventoryid { get; set; }
        public Int64? typeproductid { get; set; }
        public Int64? ivaid { get; set; }
        public String imagepath { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String namepresentation { get; set; }
        public String nameunitsale { get; set; }
        public String nameunitbuy { get; set; }
        public String nameunitinventory { get; set; }
        public String nametypeproduct { get; set; }
        public String codeiva { get; set; }
        public Decimal? valueiva { get; set; }
    }
}
