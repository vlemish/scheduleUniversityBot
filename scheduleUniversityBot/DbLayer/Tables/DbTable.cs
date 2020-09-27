using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using DbLayer.Types;

namespace DbLayer
{
    abstract class DbTable<T> where T : ITableEntity
    {

        public DbTable(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public DbTable() { }

        protected readonly SqlConnection _sqlConnection;

        abstract public void CreateTable();

        abstract public List<T> GetAll();

        abstract public T GetOne(int id);

        abstract public void AddOne(T obj);

        abstract public void AddRange(List<T> list);

        abstract public void RemoveOne(int id);

        abstract public void RemoveRange(List<T> list);

        abstract public void RemoveAll();

        abstract public void Delete();
    }
}
