﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Shared
{
    public class TituloTabComponentBase : ComponentBase
    {
        [Parameter] public String _titulo { get; set; }
    }
}
