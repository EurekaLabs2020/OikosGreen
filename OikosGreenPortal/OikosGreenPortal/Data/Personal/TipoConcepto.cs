using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoConcepto
    {
        public TipoConcepto()
        {

        }

        public List<String> tiposConceptos()
        {
            List<String> retorno = new List<String>()
            { "LOGISTICA", "TRANSACCION"};
            return retorno;
        }
    }
}
