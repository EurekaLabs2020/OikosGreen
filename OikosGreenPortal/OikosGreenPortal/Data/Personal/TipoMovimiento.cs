using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoMovimiento
    {

        public TipoMovimiento()
        {

        }

        public List<String> tiposMovimiento()
        {
            List<String> retorno = new List<String>()
            { "X|NO APLICA", "M|PRESENCIAL", "D|DOMICILIO", "W|PORTAL WEB"};
            return retorno;
        }

    }
}
