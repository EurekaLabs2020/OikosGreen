using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ConceptosRequest
    {
        public List<Concepto_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class ConceptoRequest
    {
        public Concepto_data entity { get; set; }
        public Status status { get; set; }
    }


    public class Concepto_data
    {
        public Int64 id { get; set; }
        public String type { get; set; }
        public String description { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime datemodify { get; set; }
        public Boolean active { get; set; }
    }

}
