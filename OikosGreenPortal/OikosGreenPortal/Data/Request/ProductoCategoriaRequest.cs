using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ProductoCategoriasRequest
    {
        public List<ProductoCategoria_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class ProductoCategoriaRequest
    {
        public ProductoCategoria_data entity { get; set; }
        public Status status { get; set; }
    }

    public class ProductoCategoria_data
    {
        public Int64 id { get; set; }
        public Int64 idproduct { get; set; }
        public Int64 idcategory { get; set; }
        public Int64 productid { get; set; }
        public Int64 categoryid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String codeprod { get; set; }
        public String nameprod { get; set; }
        public Decimal? costprod { get; set; }
        public String namecateg { get; set; }
    }
}
