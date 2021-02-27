using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class TercerosRequest
    {
        public List<Tercero_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class TerceroRequest
    {
        public Tercero_data entity { get; set; }
        public Status status { get; set; }
    }
    public class Tercero_data
    {
        public Int64 id { get; set; }
        public Int64 iddocumento { get; set; }
        public String numdocument { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String cellphone { get; set; }
        public DateTime? birthdate { get; set; }
        public String email { get; set; }
        public Int64? documentoid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String typedocum { get; set; }
        public String codedocum { get; set; }
        public String namedocum { get; set; }
        [NotMapped]
        public String nombrefull { get { return (name == null ? "" : name) + " " + (lastname == null ? "" : lastname); } }
    }
}
