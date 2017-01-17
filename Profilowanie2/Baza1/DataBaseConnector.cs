using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza1
{
    public class DataBaseConnector
    {
        private static DataBaseConnector _connectorInstance;
        // Connection String
        private string _connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NJPO2;Integrated Security=True";
        // Provider (System.Data.SqlClient for Microsoft SQL Server)
        private string _provider = "System.Data.SqlClient";

        private DbProviderFactory _factory;

        private DataBaseConnector()
        {
            _factory = DbProviderFactories.GetFactory(_provider);
        }

        public static DataBaseConnector Instance
        {
            get { return _connectorInstance ?? new DataBaseConnector(); }
        }

        public DbDataReader Query(string query)
        {
            // Powoduje zamknięcie zasobu
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connection;
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = query;

                return command.ExecuteReader(); 
            }
        }

        public int NonQuery(string query)
        {
            // Powoduje zamknięcie zasobów
            using (DbConnection connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connection;
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = query;
                return command.ExecuteNonQuery();
            }
        }
    }
}
