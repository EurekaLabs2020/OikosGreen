using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ConversionesRequest
    {
        public List<Conversion_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class ConversionRequest
    {
        public Conversion_data entity { get; set; }
        public Status status { get; set; }
    }

    public class Conversion_data
    {
        public Int64 id { get; set; }
        public Int64 unitoriginid { get; set; }
        public Int64 unitdestinationid { get; set; }
        public Decimal value { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String presorigin { get; set; }
        public String presdestination { get; set; }
    }

}
