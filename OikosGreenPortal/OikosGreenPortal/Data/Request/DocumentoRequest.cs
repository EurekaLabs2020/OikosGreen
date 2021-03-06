using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class DocumentosRequest
    {
        public List<Documento_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class DocumentoRequest
    {
        public Documento_data entity { get; set; }
        public Status status { get; set; }
    }

    public class Documento_data 
    {
        public Int64 id { get; set; }
        public Int64 idlist { get; set; }
        public String type { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public Int64 consecutive { get; set; }
        public String typeclass { get; set; }
        public String affect { get; set; }

        public String nature { get; set; }
        public Boolean hasthird { get; set; }
        public String thirdtype { get; set; }
        public Int64 typeproduct { get; set; }

        public Int32 copie { get; set; }
        public Int64? listid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String namelist { get; set; }
        public DateTime? startdatelist { get; set; }
        public DateTime? enddatelist { get; set; }
    }


}
