using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class GeneralIvaRequest
    {
        public List<GeneralIva_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class GeneralIvaData 
    {
        public GeneralIva_data entity { get; set; }
        public Status status { get; set; }
    }

    public class GeneralIva_data 
    {
        public Int64 id { get; set; }
        public String code { get; set; }
        public Decimal value { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
    }


}
