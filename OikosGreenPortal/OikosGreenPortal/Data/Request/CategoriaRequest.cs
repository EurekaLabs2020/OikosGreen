using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class CategoriasRequest
    {
        public List<Categoria_data> entities { get; set; }
        public Status status { get; set; }
    }

    public class CategoriaRequest
    {
        public Categoria_data entity { get; set; }
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
        public String nameparent { get; set; }
    }
}
