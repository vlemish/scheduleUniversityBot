using DbLayer.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DbLayer
{
    //Subject scaffold:
    //Id INT PRIMARY KEY IDENTITY(1,1),
    //TeacherName NVARCHAR()

    class TeachersTable : DbTable<Teacher>
    {
        //uses parent's connection string
        public TeachersTable(SqlConnection sqlConnection)
            : base(sqlConnection) { }

        //TOADD: A new Record
        public override void AddOne(Teacher obj)
        {
            var sql = $@"INSERT INTO Teachers VALUES (TeacherName = '{obj.TeacherName}')";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TOADD: A list of new records
        public override void AddRange(List<Teacher> list)
        {
            var listToQuery = string.Join(",", list.Select(i => $"(TeacherName = '{i.TeacherName}')"));

            var sql = $@"INSERT INTO Teachers VALUES" + listToQuery;
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

        }

        //Creates tables to further work with it
        //NOTE: FIRST OF ALL YOU SHOULD CALL THIS Method, if you didn't call this method before using other methods you would have an error!
        public override void CreateTable()
        {
            var sql = $@"CREATE TABLE Teachers(Id INT PRIMARY KEY IDENTITY(1,1), TeacherName NVARCHAR(50))";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //Deletes the table
        public override void Delete()
        {
            var sql = $@"DROP TABLE Teachers;";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TOGET: All the records
        public override List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();
            var sql = @"SELECT *FROM Teachers";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            
            using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    teachers.Add(new Teacher(int.Parse(string.Join("", sqlDataReader["Id"])), string.Join("", sqlDataReader["SubjectName"])));
                }
            }

            return teachers;
        }

        //TOGET: One record by its id
        public override Teacher GetOne(int id)
        {
            var sql = $@"SELECT *FROM Teachers WHERE Id = {id}";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                return new Teacher(int.Parse(string.Join("", sqlDataReader["Id"])), string.Join("", sqlDataReader["SubjectName"]));
            }

        }

        //TOGET: All the records which matches to the name
        public List<Teacher> GetAllByName(string name)
        {
            List<Teacher> teachers = new List<Teacher>();
            var sql = $@"SELECT *FROM Teachers WHERE TeacherName = '{name}'";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    teachers.Add(new Teacher(int.Parse(string.Join("", sqlDataReader["Id"])), string.Join("", sqlDataReader["SubjectName"])));
                }
            }

            return teachers;
        }

        //TODELETE: All the records
        public override void RemoveAll()
        {
            var sql = $@"DELETE FROM Teachers;";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: One record by its id
        public override void RemoveOne(int id)
        {
            var sql = $@"DELETE FROM Teachers WHERE Id = {id}";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: All the records by id
        public override void RemoveRange(List<Teacher> list)
        {
            var listToQuery = string.Join(" AND ", list.Select(i => $"Id = {i.Id}"));

            var sql = $@"DELETE FROM Teachers WHERE " + listToQuery;
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: All the records which matches to the name
        public void RemoveByName(string name)
        {
            var sql = $@"DELETE FROM Teachers WHERE TeacherName = '{name}'";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
