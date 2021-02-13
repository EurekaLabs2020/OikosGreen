using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.PersonalClass
{
    public static class Urls
    {
        public static String urlbase { get; set; } = "http://oikosgreen.com.co:82/api/";
        public static String urllogin { get { return urlbase + "Account/Login"; } }
        public static String urlmenu { get { return urlbase + "permission/getbyuser"; } }


    }
}
