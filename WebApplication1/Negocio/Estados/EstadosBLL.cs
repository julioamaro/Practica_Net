using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication13.Datos;

namespace WebApplication13.Negocio
{
    public class EstadosBLL
    {
        public static DataSet GetEstados()
        {
            try
            {
                return EstadosDAL.getInstance().GetEstados();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}