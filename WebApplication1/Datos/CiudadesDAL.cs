using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public class CiudadesDAL: CiudadesBase
    {
        private static CiudadesDAL instancia;
        public CiudadesDAL()
        {
            
        }
        public static CiudadesDAL getInstance()
        {
            if (instancia == null)
            {
                instancia = new CiudadesDAL();
            }

            return instancia;
        }


        public override DataSet GetCiudades(string IdEstado)
        {
            try
            {
                string strSql = string.Empty;

                strSql = "SELECT * FROM Ciudades WHERE IdEstado =" + IdEstado;

                return Utilities.GetDataSet(strSql);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}