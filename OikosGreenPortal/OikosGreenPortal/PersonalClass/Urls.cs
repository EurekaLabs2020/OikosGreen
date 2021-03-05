using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.PersonalClass
{
    public static class Urls
    {
        public static String urlbase { get; set; } = "http://oikosgreen.com.co:82/api/";

        #region Login - Permisos
        public static String urllogin { get { return urlbase + "Account/Login"; } }
        public static String urlsentemail { get { return urlbase + "sentemail"; } }
        public static String urlchange_Pass { get { return urlbase + "changePassword"; } }

        public static String urlmenu { get { return urlbase + "permission/getbyuser"; } }
        public static String urlopcion_getall { get { return urlbase + "opcion/getall"; } }
        public static String urlopcion_insert { get { return urlbase + "opcion/insert"; } }
        public static String urlopcion_update { get { return urlbase + "opcion/update"; } }
        public static String urlopcion_inactive { get { return urlbase + "opcion/inactive"; } }
        public static String urlopcion_getbycode { get { return urlbase + "opcion/getbycode"; } }

        #endregion

        #region Bodega
        public static String urlbodega_getall { get { return urlbase + "bodega/getall"; } } //GET
        public static String urlbodega_getbyid { get { return urlbase + "bodega/getbyid"; } } //POST
        public static String urlbodega_getbycode { get { return urlbase + "bodega/getbycode"; } } //POST
        public static String urlbodega_insert { get { return urlbase + "bodega/insert"; } } //POST
        public static String urlbodega_update { get { return urlbase + "bodega/update"; } } //POST
        public static String urlbodega_inactive { get { return urlbase + "bodega/inactive"; } } //POST
        #endregion

        #region Categoria
        public static String urlcategoria_getall { get { return urlbase + "categoria/getall"; } } //GET
        public static String urlcategoria_getbyid { get { return urlbase + "categoria/getbyid"; } } //POST
        public static String urlcategoria_getbycode { get { return urlbase + "categoria/getbycode"; } } //POST
        public static String urlcategoria_insert { get { return urlbase + "categoria/insert"; } } //POST
        public static String urlcategoria_update { get { return urlbase + "categoria/update"; } } //POST
        public static String urlcategoria_inactive { get { return urlbase + "categoria/inactive"; } } //POST
        #endregion

        #region Conversion
        public static String urlconversion_getall { get { return urlbase + "conversion/getall"; } } //GET
        public static String urlconversion_getbyid { get { return urlbase + "conversion/getbyid"; } } //POST
        public static String urlconversion_getbycode { get { return urlbase + "conversion/getbycode"; } } //POST
        public static String urlconversion_insert { get { return urlbase + "conversion/insert"; } } //POST
        public static String urlconversion_update { get { return urlbase + "conversion/update"; } } //POST
        public static String urlconversion_inactive { get { return urlbase + "conversion/inactive"; } } //POST
        #endregion

        #region Descuento Movimiento
        public static String urldescuentomovimiento_getall { get { return urlbase + "descuentomovimiento/getall"; } } //GET
        public static String urldescuentomovimiento_getbyid { get { return urlbase + "descuentomovimiento/getbyid"; } } //POST
        public static String urldescuentomovimiento_insert { get { return urlbase + "descuentomovimiento/insert"; } } //POST
        public static String urldescuentomovimiento_update { get { return urlbase + "descuentomovimiento/update"; } } //POST
        public static String urldescuentomovimiento_inactive { get { return urlbase + "descuentomovimiento/inactive"; } } //POST
        #endregion

        #region Detalle Movimiento
        public static String urldetallemovimiento_getall { get { return urlbase + "detallemovimiento/getall"; } } //GET
        public static String urldetallemovimiento_getbyid { get { return urlbase + "detallemovimiento/getbyid"; } } //POST
        public static String urldetallemovimiento_insert { get { return urlbase + "detallemovimiento/insert"; } } //POST
        public static String urldetallemovimiento_update { get { return urlbase + "detallemovimiento/update"; } } //POST
        public static String urldetallemovimiento_inactive { get { return urlbase + "detallemovimiento/inactive"; } } //POST
        public static String urlcreatetransacc { get { return urlbase + "detallemovimiento/createtransacc"; } } //POST

        #endregion

        #region Documento
        public static String urldocumento_getall { get { return urlbase + "documento/getall"; } } //GET
        public static String urldocumento_getbyid { get { return urlbase + "documento/getbyid"; } } //POST
        public static String urldocumento_getbycode { get { return urlbase + "documento/getbycode"; } } //POST
        public static String urldocumento_insert { get { return urlbase + "documento/insert"; } } //POST
        public static String urldocumento_update { get { return urlbase + "documento/update"; } } //POST
        public static String urldocumento_inactive { get { return urlbase + "documento/inactive"; } } //POST
        #endregion
         
        #region Encabezado Movimiento
        public static String urlencabezadomovimiento_getall { get { return urlbase + "encabezadomovimiento/getall"; } } //GET
        public static String urlencabezadomovimiento_getbyid { get { return urlbase + "encabezadomovimiento/getbyid"; } } //POST
        public static String urlencabezadomovimiento_insert { get { return urlbase + "encabezadomovimiento/insert"; } } //POST
        public static String urlencabezadomovimiento_update { get { return urlbase + "encabezadomovimiento/update"; } } //POST
        public static String urlencabezadomovimiento_inactive { get { return urlbase + "encabezadomovimiento/inactive"; } } //POST
        #endregion

        #region GeneralIva
        public static String urlgeneraliva_getall { get { return urlbase + "generaliva/getall"; } } //GET
        public static String urlgeneraliva_getbyid { get { return urlbase + "generaliva/getbyid"; } } //POST
        public static String urlgeneraliva_insert { get { return urlbase + "generaliva/insert"; } } //POST
        public static String urlgeneraliva_update { get { return urlbase + "generaliva/update"; } } //POST
        public static String urlgeneraliva_inactive { get { return urlbase + "generaliva/inactive"; } } //POST
        #endregion

        #region Lista
        public static String urllista_getall { get { return urlbase + "lista/getall"; } } //GET
        public static String urllista_getbyid { get { return urlbase + "lista/getbyid"; } } //POST
        public static String urllista_insert { get { return urlbase + "lista/insert"; } } //POST
        public static String urllista_update { get { return urlbase + "lista/update"; } } //POST
        public static String urllista_inactive { get { return urlbase + "lista/inactive"; } } //POST
        #endregion

        #region Lista Detalle
        public static String urllistadetalle_getall { get { return urlbase + "listadetalle/getall"; } } //GET
        public static String urllistadetalle_getbyid { get { return urlbase + "listadetalle/getbyid"; } } //POST
        public static String urllistadetalle_insert { get { return urlbase + "listadetalle/insert"; } } //POST
        public static String urllistadetalle_update { get { return urlbase + "listadetalle/update"; } } //POST
        public static String urllistadetalle_inactive { get { return urlbase + "listadetalle/inactive"; } } //POST
        #endregion

        #region Observacion Movimiento
        public static String urlobservacionmovimiento_getall { get { return urlbase + "observacionmovimiento/getall"; } } //GET
        public static String urlobservacionmovimiento_getbyid { get { return urlbase + "observacionmovimiento/getbyid"; } } //POST
        public static String urlobservacionmovimiento_insert { get { return urlbase + "observacionmovimiento/insert"; } } //POST
        public static String urlobservacionmovimiento_update { get { return urlbase + "observacionmovimiento/update"; } } //POST
        public static String urlobservacionmovimiento_inactive { get { return urlbase + "observacionmovimiento/inactive"; } } //POST
        #endregion

        #region Parametro
        public static String urlparametro_getall { get { return urlbase + "parametro/getall"; } } //GET
        public static String urlparametro_getbyid { get { return urlbase + "parametro/getbyid"; } } //POST
        public static String urlparametro_getbycode { get { return urlbase + "parametro/getbycode"; } } //POST
        public static String urlparametro_insert { get { return urlbase + "parametro/insert"; } } //POST
        public static String urlparametro_update { get { return urlbase + "parametro/update"; } } //POST
        public static String urlparametro_inactive { get { return urlbase + "parametro/inactive"; } } //POST
        #endregion

        #region Parametro Detalle
        public static String urlparametrodetalle_getall { get { return urlbase + "parametrodetalle/getall"; } } //GET
        public static String urlparametrodetalle_getbyid { get { return urlbase + "parametrodetalle/getbyid"; } } //POST
        public static String urlparametrodetalle_getbycode { get { return urlbase + "parametrodetalle/getbycode"; } } //POST
        public static String urlparametrodetalle_insert { get { return urlbase + "parametrodetalle/insert"; } } //POST
        public static String urlparametrodetalle_update { get { return urlbase + "parametrodetalle/update"; } } //POST
        public static String urlparametrodetalle_inactive { get { return urlbase + "parametrodetalle/inactive"; } } //POST
        #endregion

        #region Presentacion
        public static String urlpresentacion_getall { get { return urlbase + "presentacion/getall"; } } //GET
        public static String urlpresentacion_getbyid { get { return urlbase + "presentacion/getbyid"; } } //POST
        public static String urlpresentacion_getbycode { get { return urlbase + "presentacion/getbycode"; } } //POST
        public static String urlpresentacion_insert { get { return urlbase + "presentacion/insert"; } } //POST
        public static String urlpresentacion_update { get { return urlbase + "presentacion/update"; } } //POST
        public static String urlpresentacion_inactive { get { return urlbase + "presentacion/inactive"; } } //POST
        #endregion

        #region Producto
        public static String urlproducto_getall { get { return urlbase + "producto/getall"; } } //GET
        public static String urlproducto_getbyid { get { return urlbase + "producto/getbyid"; } } //POST
        public static String urlproducto_insert { get { return urlbase + "producto/insert"; } } //POST
        public static String urlproducto_update { get { return urlbase + "producto/update"; } } //POST
        public static String urlproducto_inactive { get { return urlbase + "producto/inactive"; } } //POST
        public static String urlproducto_getbycode { get { return urlbase + "producto/getbycode"; } } //POST
        #endregion

        #region Producto Categoria
        public static String urlproductocategoria_getall { get { return urlbase + "productocategoria/getall"; } } //GET
        public static String urlproductocategoria_getbyid { get { return urlbase + "productocategoria/getbyid"; } } //POST
        public static String urlproductocategoria_insert { get { return urlbase + "productocategoria/insert"; } } //POST
        public static String urlproductocategoria_update { get { return urlbase + "productocategoria/update"; } } //POST
        public static String urlproductocategoria_inactive { get { return urlbase + "productocategoria/inactive"; } } //POST
        public static String urlproductocategoria_getbycode { get { return urlbase + "productocategoria/getbycode"; } } //POST
        #endregion

        #region Saldo Producto
        public static String urlsaldoproducto_getall { get { return urlbase + "saldoproducto/getall"; } } //GET
        public static String urlsaldoproducto_getbyid { get { return urlbase + "saldoproducto/getbyid"; } } //POST
        public static String urlsaldoproducto_insert { get { return urlbase + "saldoproducto/insert"; } } //POST
        public static String urlsaldoproducto_update { get { return urlbase + "saldoproducto/update"; } } //POST
        public static String urlsaldoproducto_inactive { get { return urlbase + "saldoproducto/inactive"; } } //POST
        #endregion

        #region Tercero
        public static String urltercero_getall { get { return urlbase + "tercero/getall"; } } //GET
        public static String urltercero_getbyid { get { return urlbase + "tercero/getbyid"; } } //POST
        public static String urltercero_getbycode { get { return urlbase + "tercero/getbycode"; } } //POST
        public static String urltercero_insert { get { return urlbase + "tercero/insert"; } } //POST
        public static String urltercero_update { get { return urlbase + "tercero/update"; } } //POST
        public static String urltercero_inactive { get { return urlbase + "tercero/inactive"; } } //POST
        #endregion
        
        #region Tercero Punto
        public static String urlterceropunto_getall { get { return urlbase + "terceropunto/getall"; } } //GET
        public static String urlterceropunto_getbyid { get { return urlbase + "terceropunto/getbyid"; } } //POST
        public static String urlterceropunto_getbycode { get { return urlbase + "terceropunto/getbyperiodo"; } } //POST
        public static String urlterceropunto_insert { get { return urlbase + "terceropunto/insert"; } } //POST
        public static String urlterceropunto_update { get { return urlbase + "terceropunto/update"; } } //POST
        public static String urlterceropunto_inactive { get { return urlbase + "terceropunto/inactive"; } } //POST
        #endregion

        #region Tercero Tipo
        public static String urltercerotipo_getall { get { return urlbase + "tercerotipo/getall"; } } //GET
        public static String urltercerotipo_getbyid { get { return urlbase + "tercerotipo/getbyid"; } } //POST
        public static String urltercerotipo_getbytipo { get { return urlbase + "tercerotipo/getbytipo"; } } //POST
        public static String urltercerotipo_insert { get { return urlbase + "tercerotipo/insert"; } } //POST
        public static String urltercerotipo_update { get { return urlbase + "tercerotipo/update"; } } //POST
        public static String urltercerotipo_inactive { get { return urlbase + "tercerotipo/inactive"; } } //POST
        #endregion

        #region TipoProducto
        public static String urltipoproducto_getall { get { return urlbase + "tipoproducto/getall"; } } //GET
        public static String urltipoproducto_getbyid { get { return urlbase + "tipoproducto/getbyid"; } } //POST
        public static String urltipoproducto_insert { get { return urlbase + "tipoproducto/insert"; } } //POST
        public static String urltipoproducto_update { get { return urlbase + "tipoproducto/update"; } } //POST
        public static String urltipoproducto_inactive { get { return urlbase + "tipoproducto/inactive"; } } //POST
        public static String urltipoproducto_getbycode { get { return urlbase + "tipoproducto/getbycode"; } } //POST
        #endregion    

        #region Ubicacion
        public static String urlubicacion_getall { get { return urlbase + "ubicacion/getall"; } } //GET
        public static String urlubicacion_getbyid { get { return urlbase + "ubicacion/getbyid"; } } //POST
        public static String urlubicacion_getbycode { get { return urlbase + "ubicacion/getbycode"; } } //POST
        public static String urlubicacion_insert { get { return urlbase + "ubicacion/insert"; } } //POST
        public static String urlubicacion_update { get { return urlbase + "ubicacion/update"; } } //POST
        public static String urlubicacion_inactive { get { return urlbase + "ubicacion/inactive"; } } //POST
        #endregion

        #region Transaccion
        public static String urltransaccion_gettransacc { get { return urlbase + "detallemovimiento/gettransaccc"; } } //GET
        public static String urltransaccion_gettransaccbyitem { get { return urlbase + "detallemovimiento/gettransaccbyitem"; } } //POST
        #endregion


    }
}
