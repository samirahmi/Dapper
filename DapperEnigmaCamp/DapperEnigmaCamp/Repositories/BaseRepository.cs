using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperEnigmaCamp.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected string connString = @"Server=DESKTOP-QEO3NAA\SQLEXPRESS;Database=ShippingDB;Trusted_Connection=True;";

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                .GetProperties()
                .Where(w => w.Name != "Id" && !w.PropertyType.GetTypeInfo().IsGenericType)
                .Select(w => w.Name);
        }

        public virtual void Insert(T entity)
        {
            var columns = GetColumns();
            var stringOfColums = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            
            var query = $"INSERT INTO {typeof(T).Name} ({stringOfColums}) VALUES ({stringOfParameters})";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual void Delete(T Entity)
        {
            var columns = GetColumns();
            var columnFields = string.Join(", ", columns);
            var arrColumns = columnFields.Split(',');
            string Id = arrColumns.First();

            var query = $"DELETE FROM {typeof(T).Name} WHERE {Id} = @Id";

            using(var connection = new SqlConnection(connString))
            {
                connection.Open();
                connection.Execute(query, Entity);
            }
        }

        public virtual void Update(T Entity)
        {
            var columns = GetColumns();
            var columnFields = string.Join(", ", columns);
            var arrColumns = columnFields.Split(',');
            string Id = arrColumns.First();
      
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"UPDATE {typeof(T).Name} SET {stringOfColumns} WHERE {Id} = @Id";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                connection.Execute(query, Entity);
            }
        }

        public virtual IEnumerable<T> Query(string where = null)
        {
            var query = $"SELECT * FROM {typeof(T).Name}";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var connection =  new SqlConnection(connString))
            {
                connection.Open();
                return connection.Query<T>(query);
            }
        }
    }
}
