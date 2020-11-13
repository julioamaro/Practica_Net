using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebApplication13.Datos
{
    public class Utilities
    {

        public static DbConnection CreateDbConnection()
        {
            // Assume failure.
            DbConnection connection = null;
            string providerName = "System.Data.SqlClient";

            string Conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            // Create the DbProviderFactory and DbConnection.
            if (Conexion != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = Conexion;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }

        public static DataSet GetDataSet(string commandText)
        {

            DbCommand command = CreateDbConnection().CreateCommand();
            command.CommandText = commandText;

            DbDataAdapter adapter = DbProviderFactories.GetFactory(CreateDbConnection()).CreateDataAdapter();

            adapter.SelectCommand = command;
            DataSet dataset = new DataSet();

            try
            {
                adapter.Fill(dataset);
            }
            catch (Exception e)
            {
                throw new Exception(
                          e.Message + "\r\n" +
                          "Command Text" + "\r\n" +
                          commandText, e);
            }

            try
            {
                return dataset;
            }
            finally
            {
                dataset.Dispose();
            }
        }
    }
}