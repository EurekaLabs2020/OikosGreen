using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class TransaccionRequest
    {
        public List<Transaccion_data> entities { get; set; }
        public Status  status { get; set; }

    }

    public class Transaccion_data
    {
        public Int64? idencabezado { get; set; }
        public Int64? numberdocument { get; set; }
        public DateTime date { get; set; }
        public String typemoviment { get; set; }
        public Int64 docid { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public String type { get; set; }
        public String typeclass { get; set; }
        public String affect { get; set; }
        public String cashierid { get; set; }
        public String cashiername { get; set; }
        public String cashierlastname { get; set; }
        public String sellerid { get; set; }
        public String sellername { get; set; }
        public String sellerlastname { get; set; }
        public Int64 cellarid { get; set; }
        public String cellartype { get; set; }
        public String cellarname { get; set; }
        public Int64 cellarorigid { get; set; }
        public String cellarorigtype { get; set; }
        public String cellarorigname { get; set; }
        public Int64? cellardestid { get; set; }
        public String cellardesttype { get; set; }
        public String cellardestname { get; set; }
        public Int64? encaorigin { get; set; }
        public Int64? encaorignumberdocument { get; set; }
        public DateTime? encaorigdate { get; set; }
        public String encaorigtypemovimient { get; set; }
        public String docorigcode { get; set; }
        public String docorigname { get; set; }
        public String docorigtype { get; set; }
        public String docorigtypeclass { get; set; }
        public String docorigaffect { get; set; }
        public Int64? terceroid { get; set; }
        public String tercname { get; set; }
        public String terclastname { get; set; }
        public String tercnumdocument { get; set; }
        public String docterccode { get; set; }
        public String doctercname { get; set; }
        public String tercphone { get; set; }
        public String terccellphone { get; set; }
        public Int64 detid { get; set; }
        public Int32 detline { get; set; }
        public Int64 prodid { get; set; }
        public String prodcode { get; set; }
        public String prodname { get; set; }
        public Int64 presentacionid { get; set; }
        public String prodtipname { get; set; }
        public String prodivacode { get; set; }
        public Decimal? prodivavalue { get; set; }
        public Decimal quantity { get; set; }
        public Decimal unitvaluebefore { get; set; }
        public Decimal unitvalue { get; set; }
        public Decimal costvalue { get; set; }
        public Decimal valueiva { get; set; }
        public Decimal points { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public String namepc { get; set; }

        [NotMapped]
        public String nombrefull { get { return (tercname == null ? "" : tercname) + " " + (terclastname == null ? "" : terclastname); } }

    }


}
