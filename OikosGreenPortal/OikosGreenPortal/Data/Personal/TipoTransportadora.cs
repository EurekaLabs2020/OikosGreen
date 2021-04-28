using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoTransportadora
    {
        public TipoTransportadora()
        {

        }

        public List<String> tiposTransportadora()
        {
            List<String> retorno = new List<String>()
            { "PROPIA", "EXTERNA"};
            return retorno;
        }
    }
}
