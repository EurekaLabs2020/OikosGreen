using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoDocumento
    {
        public TipoDocumento()
        {

        }

        public List<String> tiposDocumentos()
        {
            List<String> retorno = new List<String>()
            { "PERSONA", "TRANSACCION"};
            return retorno;
        }
    }
}
