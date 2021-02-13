using OikosGreenPortal.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Personal
{
    public class infoBrowser
    {
        public LoginRequest user { get; set; }
        public List<infoRoles> roles { get; set; }
        public List<infoMenu> menus { get; set; }
    }
}
