using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public class EstadosDAL: EstadosBase
    {
        private static EstadosDAL instancia;
        public EstadosDAL()
        {
            
        }
        public static EstadosDAL getInstance()
        {
            if (instancia == null)
            {
                instancia = new EstadosDAL();
            }

            return instancia;
        }


        public override DataSet GetEstados()
        {
            try
            {
                return Utilities.GetDataSet("spGetEstados");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}