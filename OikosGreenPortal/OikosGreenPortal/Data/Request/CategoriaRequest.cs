using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class CategoriaRequest
    {
        public List<Categoria_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class vCategoriaRequest
    {
        public List<vCategoria_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class CategoriaData
    {
        public Categoria_data entity { get; set; }
        public Status status { get; set; }
    }
    public class vCategoriaData
    {
        public vCategoria_data entity { get; set; }
        public Status status { get; set; }
    }
    public class Categoria_data
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public Int64 parent { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
    }
    public class vCategoria_data : Categoria_data
    {
        public String nameparent { get; set; }
    }
}
