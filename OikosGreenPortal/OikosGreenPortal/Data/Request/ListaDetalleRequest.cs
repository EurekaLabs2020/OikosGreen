using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ListaDetallesRequest
    {
        public List<ListaDetalle_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class ListaDetalleRequest
    {
        public ListaDetalle_data entity { get; set; }
        public Status status { get; set; }
    }
    //public class ListaDetalle_data
    //{
    //    public Int64 id { get; set; }
    //    public Int64 idproducto { get; set; }
    //    public Int64 idlista { get; set; }
    //    public Int64 productid { get; set; }
    //    public Int64 listid { get; set; }
    //    public Decimal value { get; set; }
    //    public String usercreate { get; set; }
    //    public DateTime datecreate { get; set; }
    //    public String usermodify { get; set; }
    //    public DateTime? datemodify { get; set; }
    //    public Boolean active { get; set; }
    //    public String codeprod { get; set; }
    //    public String nameprod { get; set; }
    //    public Decimal? costprod { get; set; }
    //    public String namelist { get; set; }
    //}

    public class ListaDetalle_data
    {
        public Int64 id { get; set; }
        public Int64 idproducto { get; set; }
        public Int64 idlista { get; set; }
        public Int64 productid { get; set; }
        public Int64 listid { get; set; }
        public Decimal value { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String codeprod { get; set; }
        public String nameprod { get; set; }
        public Decimal costprod { get; set; }
        public String namelist { get; set; }
    }

}
