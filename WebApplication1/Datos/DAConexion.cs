using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public class DAConexion
    {
        private static SqlConnection instancia = null;
        private static readonly object padlock = new object();

        private DAConexion()
        {
           
        }

        public static SqlConnection Connexion
        {
            get
            {
                lock (padlock)
                {
                    if (instancia == null)
                    {
                        instancia = new SqlConnection();
                        instancia.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                    }
                    return instancia;
                }
            }
        }

        public static void Open()
        {
            if (instancia != null)
            {
                instancia.Open();
            }
        }

        public static void Close()
        {

            if (instancia != null)
            {
                instancia.Close();
            }
        }
    }
}