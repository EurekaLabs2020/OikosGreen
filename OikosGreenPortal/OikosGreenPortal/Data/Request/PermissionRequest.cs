using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class PermissionRequest
    {
        public List<Permission> entities { get; set; }
        public Status status { get; set; }
    }

    public class Permission
    {
        public String user { get; set; }
        public String rol { get; set; }
        public String type { get; set; }
        public String url { get; set; }
        public String icono { get; set; }
        public String code { get; set; }
        public String option { get; set; }
        public String parent { get; set; }
        public Int32 state { get; set; }
        public String id { get; set; }
        public String idparent { get; set; }
        public String permission { get; set; }
    }

}
