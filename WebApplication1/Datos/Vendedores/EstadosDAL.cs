using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public class VendedoresDAL : VendedoresBase
    {
        private static VendedoresDAL instancia;
        public VendedoresDAL()
        {
            
        }
        public static VendedoresDAL getInstance()
        {
            if (instancia == null)
            {
                instancia = new VendedoresDAL();
            }

            return instancia;
        }


        public override DataSet GetVendedores(string IdCiudades)
        {
            try
            {
                string strSql = string.Empty;

                strSql = "SELECT v.IdCiudad, v.IdVendedor, f.IdFacturas "+
                            "FROM Vendedores  v "+
                            "INNER JOIN Facturas f on f.IdVendedor = v.IdVendedor " +
                            " WHERE v.IdCiudad = " + IdCiudades;

                return Utilities.GetDataSet(strSql);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}