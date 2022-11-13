using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.BaseRepositorys
{
    public abstract class BaseRepository<T>
    {
        protected string connString =
            @"Host=localhost;Username=postgres;Password=sami;Database=Gudang;";

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
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            //var arr = stringOfColumns.Split(',');
            //string first = arr.First();

            var query = $"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters})";

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual void Delete(T entity)
        {
            var columns = GetColumns();
            var columnsFields = string.Join(", ", columns);
            var arrColumns = columnsFields.Split(',');
            string Id = arrColumns.First();

            var query = $"DELETE FROM {typeof(T).Name} WHERE {Id} = @Id";

            using(var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual void Update(T entity)
        {
            var columns = GetColumns();
            var columnsFields = string.Join(", ", columns);
            var arrColumns = columnsFields.Split(',');
            string Id = arrColumns.First();

            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $" UPDATE {typeof(T).Name} SET {stringOfColumns} WHERE {Id} = @Id";

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute(query, entity);
            }
        }

        public virtual IEnumerable<T> Query(string where = null)
        {
            var query = $"SELECT * FROM {typeof(T).Name}";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                return connection.Query<T>(query);
            }
        }
    }
}
