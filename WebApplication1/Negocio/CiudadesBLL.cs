using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication13.Datos;

namespace WebApplication13.Negocio
{
    public class CiudadesBLL
    {
        public static DataSet GetCiudades(string IdEstado)
        {
            try
            {
                return CiudadesDAL.getInstance().GetCiudades(IdEstado);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}