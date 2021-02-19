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
        public static String urltipoproducto_update { get { return urlbase + "tipoproducto/update"; } } //POST
        public static String urltipoproducto_inactive { get { return urlbase + "tipoproducto/inactive"; } } //POST
        #endregion

        #region Presentacion
        public static String urlpresentacion_getall { get { return urlbase + "presentacion/getall"; } } //GET
        public static String urlpresentacion_getbyid { get { return urlbase + "presentacion/getbyid"; } } //POST
        public static String urlpresentacion_insert { get { return urlbase + "presentacion/insert"; } } //POST
        public static String urlpresentacion_update { get { return urlbase + "presentacion/update"; } } //POST
        public static String urlpresentacion_inactive { get { return urlbase + "presentacion/inactive"; } } //POST
        #endregion

        #region Parametro
        public static String urlparametro_getall { get { return urlbase + "parametro/getall"; } } //GET
        public static String urlparametro_getbyid { get { return urlbase + "parametro/getbyid"; } } //POST
        public static String urlparametro_insert { get { return urlbase + "parametro/insert"; } } //POST
        public static String urlparametro_update { get { return urlbase + "parametro/update"; } } //POST
        public static String urlparametro_inactive { get { return urlbase + "parametro/inactive"; } } //POST
        #endregion

        #region GeneralIva
        public static String urlgeneraliva_getall { get { return urlbase + "generaliva/getall"; } } //GET
        public static String urlgeneraliva_getbyid { get { return urlbase + "generaliva/getbyid"; } } //POST
        public static String urlgeneraliva_insert { get { return urlbase + "generaliva/insert"; } } //POST
        public static String urlgeneraliva_update { get { return urlbase + "generaliva/update"; } } //POST
        public static String urlgeneraliva_inactive { get { return urlbase + "generaliva/inactive"; } } //POST
        #endregion

    }
}
