using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoTerceroTipo
    {
        public TipoTerceroTipo()
        {

        }

        public List<String> tiposTerceroTipo()
        {
            List<String> retorno = new List<String>()
            { "PROVEEDOR", "CLIENTE"};
            return retorno;
        }

    }
}
