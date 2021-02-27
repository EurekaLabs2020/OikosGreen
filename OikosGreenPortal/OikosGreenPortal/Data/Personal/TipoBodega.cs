using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoBodega
    {
        public TipoBodega()
        {
        }

        public List<String> tiposBodegas()
        {
            List<String> retorno = new List<String>()
            { "PRINCIPAL", "SUCURSAL", "SATELITE"};
            return retorno;
        }

    }
}
