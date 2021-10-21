using System;
using System.Data;
using System.Data.SqlClient;
using Votacao.Infra.Settings;

namespace Votacao.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SqlServerConnection { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                SqlServerConnection = new SqlConnection(appSettings.ConnectionString);
                SqlServerConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (SqlServerConnection.State != ConnectionState.Closed) SqlServerConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}