using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public abstract class CiudadesBase
    {
       public abstract DataSet GetCiudades(string IdEstados);
    }
}