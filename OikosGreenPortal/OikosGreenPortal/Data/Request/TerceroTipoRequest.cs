using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class TercerosTipoRequest
    {
        public List<TerceroTipo_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class TerceroTipoRequest
    {
        public TerceroTipo_data entity { get; set; }
        public Status status { get; set; }
    }
    public class TerceroTipo_data
    {
        public Int64 id { get; set; }
        public Int64 idtercero { get; set; }
        public String type { get; set; }
        public Int64? terceroid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String numdocument { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        [NotMapped]
        public String nombrefull { get { return (name == null ? "" : name) + " " + (lastname == null ? "" : lastname); } }

    }
}
