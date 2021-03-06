using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class AfecteDocumento
    {
        public AfecteDocumento()
        {

        }

        public List<String> afectesDocumentos()
        {
            List<String> retorno = new List<String>()
            { "X|NO APLICA", "E|ENTRADA", "S|SALIDA"};
            return retorno;
        }

    }
}
