using System;
using System.Data;
using System.Data.SqlClient;
using PalomaStore.Shared;

namespace PalomaStore.Infra.DataContext
{
    public class PalomaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public PalomaDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}