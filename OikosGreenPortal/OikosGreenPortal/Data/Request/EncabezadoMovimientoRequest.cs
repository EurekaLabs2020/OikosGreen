using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class EncabezadoMovimientosRequest
    {
        public List<EncabezadoMovimiento_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class EncabezadoMovimientoRequest
    {
        public EncabezadoMovimiento_data entity { get; set; }
        public Status status { get; set; }
    }

    public class EncabezadoMovimiento_data 
    {
        public Int64 id { get; set; }
        public Int64 iddocumento { get; set; }
        public Int64 idtercero { get; set; }
        public Int64 numberdocument { get; set; }
        public DateTime digitdate { get; set; }
        public DateTime date { get; set; }
        public String cashierid { get; set; }
        public String sellerid { get; set; }
        public Int64 cellarid { get; set; }
        public Int64 cellaroriginid { get; set; }
        public Int64 cellardestinationid { get; set; }
        public Int64? encabezamovimientoid { get; set; }
        public String namepc { get; set; }
        public String typemoviment { get; set; }
        public Int64 documentoid { get; set; }
        public Int64 terceroid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String namecashier { get; set; }
        public String lastnamecashier { get; set; }
        public String numberdoccashier { get; set; }
        public String nameseller { get; set; }
        public String lastnameseller { get; set; }
        public String numberdocseller { get; set; }
        public String codeceller { get; set; }
        public String nameceller { get; set; }
        public String codecellerorigin { get; set; }
        public String namecellerorigin { get; set; }
        public String codecellerdestination { get; set; }
        public String namecellerdestination { get; set; }
        public String typedocument { get; set; }
        public String codedocument { get; set; }
        public String namedocument { get; set; }
        public String numdocumenttercer { get; set; }
        public String nametercer { get; set; }
        public String lastnametercer { get; set; }
    }
}
