using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OikosGreenWeb.PersonalClass
{
    public static class General
    {
        public static String frase = "Eurek42020*+";
        //public static _userLogueado userLogueado { get; set; } = new _userLogueado();
        public static Estructuras._urls urls { get; set; } = new Estructuras._urls();
        //public static List<MenuRequest> Menu_User { get; set; } = new List<MenuRequest>();
        public enum estadoPedido { Ninguno = 0, Solicitado = 1, Separado = 2, Empacado = 3, Despachado = 4, Entregado = 5 };

        //[Inject] public static ILocalStorageService _sessionStorage { get; set; }
    }


    public static class MetodosGenerales
    {
        public static String nombreDia(int dia)
        {
            string retorno = "";
            switch (dia)
            {
                case 1: retorno = "Lunes"; break;
                case 2: retorno = "Martes"; break;
                case 3: retorno = "miercoles"; break;
                case 4: retorno = "jueves"; break;
                case 5: retorno = "Viernes"; break;
                case 6: retorno = "Sabado"; break;
                case 0: retorno = "Domingo"; break;
                default: retorno = "0"; break;
            }
            return retorno.ToUpper().Trim();
        }


        public static Boolean tienePermiso(String _permiso, String _accion)
        {
            Boolean retorno = false;
            if (_accion.Trim().ToUpper() == "CREATE" && _permiso.Substring(0, 1) == "1")
                retorno = true;
            if (_accion.Trim().ToUpper() == "UPDATE" && _permiso.Substring(1, 1) == "1")
                retorno = true;
            if (_accion.Trim().ToUpper() == "LIST" && _permiso.Substring(2, 1) == "1")
                retorno = true;
            if (_accion.Trim().ToUpper() == "INACTIVE" && _permiso.Substring(3, 1) == "1")
                retorno = true;
            return retorno;
        }

        public static String getEstadoPedido(Int32 _estado)
        {
            String retorno = "";
            switch (_estado)
            {
                case 0: retorno = "--NINGUNO---"; break;
                case 1: retorno = "INI.SEPARADO"; break;
                case 2: retorno = "FIN SEPARADO"; break;
                case 3: retorno = "INI.EMPACADO"; break;
                case 4: retorno = "FIN EMPACADO"; break;
                case 5: retorno = "-DESPACHADO-"; break;
                case 6: retorno = "-ENTREGADO--"; break;
            }
            return retorno;
        }


        public static T2 PostRest<T, T2>(T _datos, String _url, T2 _retorno, ref String _status, String _token = "")
        {
            try
            {
                var client = new RestClient(_url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                if (!String.IsNullOrEmpty(_token))
                    request.AddHeader("Authorization", "Bearer " + _token);
                request.AddJsonBody(_datos);
                IRestResponse response = client.Execute(request);
                _retorno = JsonConvert.DeserializeObject<T2>(response.Content);
            }
            catch (Exception ex)
            {
                _status = ex.Message;
            }
            return _retorno;
        }


        public static T PostRestEmpty<T>(String _url, T _retorno, ref String _status, String _token = "")
        {
            try
            {
                var client = new RestClient(_url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                if (!String.IsNullOrEmpty(_token))
                    request.AddHeader("Authorization", "Bearer " + _token);
                IRestResponse response = client.Execute(request);
                _retorno = JsonConvert.DeserializeObject<T>(response.Content);
                if (response.Content == "" || response.Content == null)
                    _status = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                _status = ex.Message;
            }
            return _retorno;
        }

        #region Exportar Excel
        public static void generateExcel<T>(IJSRuntime ijsRuntime, List<T> _datos, Int32 _columns = 1, String _namefile = "Informe")
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Hoja1");
                var tableBody = workSheet.Cells["A6:A6"].LoadFromCollection(from f in _datos select f, true);

                #region Titulo Empresa
                var titul1 = workSheet.Cells[2, 1, 2, 1].Value = "TITAN TOOLS S.AS.";
                var titul2 = workSheet.Cells[3, 1, 3, 1].Value = "Tel. 096-3444331, 314-8683201";
                var titul3 = workSheet.Cells[4, 1, 4, 1].Value = "TITANTOOLS@GMAIL.COM.CO".ToLower();

                var titul4 = workSheet.Cells[4, (_columns / 2) + 1, 4, (_columns / 2) + 1].Value = _namefile.ToUpper();
                #endregion

                #region Encabezado                               
                var header = workSheet.Cells[6, 1, 6, _columns];
                #endregion

                #region Estilo
                workSheet.DefaultColWidth = 25;
                tableBody.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                tableBody.Style.Fill.PatternType = ExcelFillStyle.Solid;
                tableBody.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                tableBody.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                header.Style.Font.Bold = true;
                header.Style.Font.Color.SetColor(Color.White);
                header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                header.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);

                workSheet.Cells[2, 1, 4, 1].Style.Font.Bold = true;
                workSheet.Cells[2, 1, 2, 1].Style.Font.Color.SetColor(Color.Red);
                workSheet.Cells[2, 1, 2, 1].Style.Font.Size = 16;
                //workSheet.Cells[2, 1, 2, 1].Style.Fill.PatternType = ExcelFillStyle.Solid; //workSheet.Cells[2, 1, 2, 1].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);

                workSheet.Cells[4, (_columns / 2) + 1, 4, (_columns / 2) + 1].Style.Font.Bold = true;
                workSheet.Cells[4, (_columns / 2) + 1, 4, (_columns / 2) + 1].Style.Font.Size = 12;

                #endregion
                //ijsRuntime.GuardarComo($"{_namefile}.xlsx", package.GetAsByteArray());
            }
        }
        #endregion

    }


    public static class ExcelPackageExtensions
    {
        public static List<T> ToList<T>(this ExcelPackage package)
        {
            DataTable table = new DataTable();
            try
            {
                //ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                {
                    table.Columns.Add(firstRowCell.Text);
                }

                for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                {
                    var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                    var newRow = table.NewRow();
                    //int i = 1;
                    foreach (var cell in row)
                    {
                        //if(!cell.Address.StartsWith( Char.ConvertFromUtf32(64+i)))
                        //{
                        //    newRow[cell.Start.Column - 1] = ".";
                        //    i++;
                        //}

                        newRow[cell.Start.Column - 1] = cell.Text == null || cell.Text.Trim().Length == 0 ? "." : cell.Text;
                        //i++;
                    }
                    //for(int i=1;i<= workSheet.Dimension.End.Column; i++)
                    //{
                    //    newRow[i-1] = row.Value[i + 1, i] .Value == null || row[i+1, i].Value.ToString().Trim().Length == 0 ? "." : row[i+1, i].Value;
                    //}
                    //foreach(var cell in row.va)

                    table.Rows.Add(newRow);
                }
            }
            catch (Exception ex) { }
            return ConvertDataTableToList<T>(table);
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }


}
