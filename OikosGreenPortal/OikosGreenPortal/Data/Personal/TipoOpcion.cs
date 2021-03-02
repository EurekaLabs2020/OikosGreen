using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoOpcion
    {
        public TipoOpcion()
        {
        }
        public List<String> tiposOpciones()
        {
            List<String> retorno = new List<String>()
            { "MENU", "OPCION"};
            return retorno;
        }
    }
}
