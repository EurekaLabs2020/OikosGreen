using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class Periodos
    {
        public Periodos()
        {

        }

        public List<String> listaPeriodos()
        {
            List<String> retorno = new List<String>();
            for(int anio = 2021; anio <= (DateTime.Now.Year + 2); anio++)
            {
                for(int mes = 1;mes<=12; mes++)
                {
                    retorno.Add($"{anio.ToString().Trim()}{mes.ToString("0#").Trim()}");

                }
            }
            return retorno;
        }
    }
}
