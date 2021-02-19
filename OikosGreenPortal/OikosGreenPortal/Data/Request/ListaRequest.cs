using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ListasRequest
    {
        public List<Lista_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class ListaRequest
    {
        public Lista_data entity { get; set; }
        public Status status { get; set; }
    }

    public class Lista_data
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }

    }
}
