using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public abstract class VendedoresBase
    {
       public abstract DataSet GetVendedores(string IdCiudades);
    }
}