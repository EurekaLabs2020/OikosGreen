using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class DetalleMovimientosRequest
    {
        public List<DetalleMovimiento_data> entities { get; set; }
        public Status status { get; set; }

    }
    public class DetalleMovimientoRequest
    {
        public DetalleMovimiento_data entity { get; set; }
        public Status status { get; set; }
    }

    public class DetalleMovimiento_data 
    {
        public Int64 id { get; set; }
        public Int64 idproducto { get; set; }
        public Int64 idpresentacion { get; set; }
        public Int64 idiva { get; set; }
        public Int64 idencabezadomovimiento { get; set; }
        public Int32 line { get; set; }
        public Decimal quantity { get; set; }
        public Decimal unitvaluebefore { get; set; }
        public Decimal unitvalue { get; set; }
        public Decimal costvalue { get; set; }
        public Decimal valueiva { get; set; }
        public Decimal points { get; set; }
        public Int64 encabezadomovimientoid { get; set; }
        public Int64 productoid { get; set; }
        public Int64 presentacionid { get; set; }
        public Int64 ivaid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String codedocument { get; set; }
        public String namedocument { get; set; }
        public Int64 numberdocument { get; set; }
        public DateTime dateencabezado { get; set; }
        public String codeprod { get; set; }
        public String nameprod { get; set; }
        public Decimal costprod { get; set; }
        public String namepresent { get; set; }
        public String codeiva { get; set; }
        public Decimal ivavalue { get; set; }
    }

}
