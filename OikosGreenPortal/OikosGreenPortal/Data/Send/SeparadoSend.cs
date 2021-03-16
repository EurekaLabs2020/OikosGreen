using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Send
{
    public class SeparadoSend
    {
        public Int64 id { get; set; }
        public Int64 detallemovimientoid { get; set; }
        public String asignaid { get; set; }
        public String separaid { get; set; }
        public Decimal quantity { get; set; }
        public DateTime dateinitial { get; set; }
        public DateTime datefinal { get; set; }
        public Int64 conceptid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime datemodify { get; set; }
        public Boolean active { get; set; }

    }
}
