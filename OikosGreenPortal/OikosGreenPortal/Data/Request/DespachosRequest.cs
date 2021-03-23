using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class vDespachosRequest
    {
        public List<vDespacho_data> entities { get; set; }
        public Status status { get; set; }
        public List<vDespacho_data> agrupa()
        {
            List<vDespacho_data> _dato = this.entities;
            List<vDespacho_data> retorno = new List<vDespacho_data>();
            retorno = _dato.GroupBy(g => new { docname = g.docname, numberdocument = g.numberdocument }).
                Select(s => new vDespacho_data
                {
                    numberdocument = s.Key.numberdocument,
                    docname = s.Key.docname,
                    date = s.First().date,
                    deliverdate = s.First().deliverdate,
                    cantdetalle = s.Sum(u => u.cantdetalle),
                    line = s.Count()
                }
                ).ToList();

            return retorno;
        }

    }

    public class DespachosRequest
    {
        public List<Despacho_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class DespachoRequest
    {
        public List<Despacho_data> entities { get; set; }
        public Status status { get; set; }
    }


    public class vDespacho_data
    {
        public Int64 idenca { get; set; }
        public String docname { get; set; }
        public String typemoviment { get; set; }
        public Int64 numberdocument { get; set; }
        public DateTime date { get; set; }
        public String bodname { get; set; }
        public Int64 iddet { get; set; }
        public Int32 line { get; set; }
        public String codeprod { get; set; }
        public String prodname { get; set; }
        public Decimal? cantdetalle { get; set; }
        public Decimal? unitvalue { get; set; }
        public Decimal? valueiva { get; set; }
        public Decimal? cantseparado { get; set; }
        public DateTime? sepfechaini { get; set; }
        public DateTime? sepfechafin { get; set; }
        public String asignadosep { get; set; }
        public String separadorsep { get; set; }
        public String concsepara { get; set; }
        public Decimal? cantdespachado { get; set; }
        public DateTime? chefechaini { get; set; }
        public DateTime? chefechafin { get; set; }
        public String asignadocheq { get; set; }
        public String chequeadorcheq { get; set; }
        public String concchequeo { get; set; }
        public String asignadesp { get; set; }
        public String mensajerodesp { get; set; }
        public String entregadordesp { get; set; }
        public String codetran { get; set; }
        public String trantype { get; set; }
        public String transname { get; set; }
        public Int64? numberpayroll { get; set; }
        public Int64? numberguide { get; set; }
        public Int32? numberboxes { get; set; }
        public Int32? numberbags { get; set; }
        public Decimal? weight { get; set; }
        public DateTime? dispatchdate { get; set; }
        public DateTime? deliverdate { get; set; }
        public String concdespacho { get; set; }
        public String concdelivery { get; set; }
        public String evidencedelivered { get; set; }

    }


    public class Despacho_data
    {
        public Int64 id { get; set; }
        public Int64 encabezadomovimientoid { get; set; }
        public String despachaid { get; set; }
        public String mensajeroid { get; set; }
        public String entregadorid { get; set; }
        public Int64 transporterid { get; set; }
        public Int64 numberpayroll { get; set; }
        public Int64 numberguide { get; set; }
        public Int32 numberboxes { get; set; }
        public Int32 numberbags { get; set; }
        public Decimal weight { get; set; }
        public DateTime dispatchdate { get; set; }
        public DateTime deliverdate { get; set; }
        public Int64 conceptoiddispatch { get; set; }
        public Int64 conceptoiddelivery { get; set; }
        public String evidencedelivered { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
    }



}
