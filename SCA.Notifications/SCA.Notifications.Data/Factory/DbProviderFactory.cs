using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SCA.Notifications.Data.Options;
using SCA.Notifications.Domain.Interfaces.Factory;

namespace SCA.Notifications.Data.Factory
{
    public class DbProviderFactory : IDbProviderFactory, IDisposable
    {
        private readonly List<DbConnection> _connections;
        private readonly IConfigure _configure;

        public DbProviderFactory(IOptions<DbOptions> options, IConfigure configure)
        {
            _connections = new List<DbConnection>();
            _configure = configure;
        }

        public DbConnection CreateConnection()
        {
            var connection = _configure.GetConnection();
            return new SqlConnection(connection);
        }

        public DbConnection CreateScopedConnection()
        {
            var connection = CreateConnection();
            _connections.Add(connection);
            return connection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connections.ForEach(connection => connection.Dispose());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
