using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace TIBox.Repositorio
{
    public class BaseRepositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly string _conecctionString;

        public BaseRepositorio()
        {
            _conecctionString = ConfigurationManager
               .ConnectionStrings["NorthwindConnectionString"]
               .ConnectionString;
        }
        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.Delete(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.GetAll<T>();
            }
        }

        public T GetEntityById(int id)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.Get<T>(id);
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.Update(entity);
            }
        }
    }
}
