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
        #region TipoProducto
        public static String urltipoproducto_getall { get { return urlbase + "tipoproducto/getall"; } } //GET
        public static String urltipoproducto_getbyid { get { return urlbase + "tipoproducto/getbyid"; } } //POST
        public static String urltipoproducto_insert { get { return urlbase + "tipoproducto/insert"; } } //POST
        public static String urltipoproducto_update { get { return urlbase + "tipoproducto/update"; } } //PATCH
        public static String urltipoproducto_inactive { get { return urlbase + "tipoproducto/inactive"; } } //PATCH
        #endregion

    }
}
