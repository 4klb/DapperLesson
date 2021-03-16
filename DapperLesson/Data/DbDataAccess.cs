using DapperLesson.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DapperLesson.Data
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;

        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("DapperLessonProvider");

            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["DataAccessConnectionString"];
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
