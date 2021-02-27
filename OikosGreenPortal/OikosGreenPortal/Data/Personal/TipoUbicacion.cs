using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class TipoUbicacion
    {

        public TipoUbicacion()
        {
        }

        public List<String> tiposUbicaciones()
        {
            List<String> retorno = new List<String>()
            { "DEPARTAMENTO", "MUNICIPIO", "ZONA"};
            return retorno;
        }


    }
}
