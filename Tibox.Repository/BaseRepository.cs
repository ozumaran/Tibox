﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibox.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        protected readonly string _connectionString;

        public BaseRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["NorthwindConnectionString"]
                .ConnectionString;

        }

        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Delete(entity);
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                return connetion.GetAll<T>();
            }
        }

        public T GetEntityById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>(id);
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (bool)connection.Update(entity);
            }
        }
    }
}
