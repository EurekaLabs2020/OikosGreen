﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Data.Request
{
    public class ResponsRequest
    {
        public Boolean state { get; set; }
        public Status status { get; set; }
    }

    public class ResponsRequestBoolean
    {
        public Boolean entity { get; set; }
        public Status status { get; set; }
    }

    public class ResponsRequestLong
    {
        public Int64 entity { get; set; }
        public Status status { get; set; }
    }

}
