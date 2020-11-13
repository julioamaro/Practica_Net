using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public abstract class EstadosBase
    {
       public abstract DataSet GetEstados();
    }
}