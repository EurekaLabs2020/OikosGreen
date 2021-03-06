using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class ClaseDocumento
    {
        public ClaseDocumento()
        {

        }

        public List<String> clasesDocumentos()
        {
            List<String> retorno = new List<String>()
            { "X|NO APLICA", "C|COMPRA", "V|VENTA", "I|INTERCAMBIO", "A|AJUSTE"};
            return retorno;
        }
    }
}
