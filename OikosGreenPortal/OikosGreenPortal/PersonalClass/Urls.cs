using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.PersonalClass
{
    public static class Urls
    {
        public static String urlbase { get; set; } = "http://201.236.221.195:8080/api/";
        public static String urllogin { get { return urlbase + "Account/Login"; } }
    }
}
