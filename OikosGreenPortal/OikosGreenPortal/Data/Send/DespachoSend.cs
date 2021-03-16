using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Send
{
    public class DespachoSend
    {
        public Int64 id { get; set; }
        public Int64 encabezadomovimientoid { get; set; }
        public String despachaid { get; set; }
        public String mensajeroid { get; set; }
        public String entregadorid { get; set; }
        public Int64 trasporterid { get; set; }
        public Int64 numberpayroll { get; set; }
        public Int64 numberguide { get; set; }
        public Int32 numberboxes { get; set; }
        public Int32 numberbags { get; set; }
        public Decimal weight { get; set; }
        public DateTime dispatchdate { get; set; }
        public DateTime deliverdate { get; set; }
        public Int64 conceptoiddispath { get; set; }
        public Int64 conceptoiddelivery { get; set; }
        public String evidencedelivered { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime datemodify { get; set; }
        public Boolean active { get; set; }
    }
}
