﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class BodegasRequest
    {
        public List<Bodega_data> entities { get; set; }
        public Status status { get; set; }
    }
    public class BodegaRequest
    {
        public Bodega_data entity { get; set; }
        public Status status { get; set; }
    }
    public class Bodega_data
    {
        public Int64 id { get; set; }
        public Int64 idubicacion { get; set; }
        public String type { get; set; }
        public String code { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String cellphone { get; set; }
        public Int64? ubicacionid { get; set; }
        public String usercreate { get; set; }
        public DateTime datecreate { get; set; }
        public String usermodify { get; set; }
        public DateTime? datemodify { get; set; }
        public Boolean active { get; set; }
        public String ubicatype { get; set; }
        public String ubicacode { get; set; }
        public String ubicaname { get; set; }
    }
}

