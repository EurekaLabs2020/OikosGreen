using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class TransaccionRequest
    {
        public List<Transaccion_data> entities { get; set; }
        public Status  status { get; set; }

    }

    public class Transaccion_data
    {

    }

}
