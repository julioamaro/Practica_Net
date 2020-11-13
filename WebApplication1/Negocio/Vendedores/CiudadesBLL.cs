using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication13.Datos;

namespace WebApplication13.Negocio
{
    public class VendedoresBLL
    {
        public static DataSet GetVendedores(string IdCiudad)
        {
            try
            {
                return VendedoresDAL.getInstance().GetVendedores(IdCiudad);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}