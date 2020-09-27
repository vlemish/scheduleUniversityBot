using DbLayer.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DbLayer.Tables
{
    //Subject scaffold:
    //Id INT PRIMARY KEY IDENTITY(1,1),
    //TeacherId INT FOREIGN KEY References Teachers(Id)
    //SubjectName NVARCHAR()
class SubjectsTable : DbTable<Subject>
    {
        //uses parent's connection string
        public SubjectsTable(SqlConnection sqlConnection)
          : base(sqlConnection) { }

        //TOADD: A new Record
        public override void AddOne(Subject obj)
        {
            var sql = $@"INSERT INTO Subjects VALUES (TeacherId = {obj.TeacherId}, SubjectName = '{obj.SubjectName}')";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TOADD: A list of new records
        public override void AddRange(List<Subject> list)
        {
            var listToQuery = string.Join(",", list.Select(i => $"(TeacherId = {i.TeacherId}, SubjectName = '{i.SubjectName}')"));

            var sql = $@"INSERT INTO Subjects VALUES" + listToQuery;
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();

        }

        //Creates tables to further work with it
        //NOTE: FIRST OF ALL YOU SHOULD CALL THIS Method, if you didn't call this method before using other methods you would have an error!
        public override void CreateTable()
        {
            var sql = $@"CREATE TABLE Subjects (Id INT PRIMARY KEY IDENTITY(1,1), TeacherId INT, TeacherName NVARCHAR(50), CONSTRAINT FK_TeacherSubject FOREIGN KEY TeacherId REFERENCES Teachers(Id))";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //Deletes the table
        public override void Delete()
        {
            var sql = $@"DROP TABLE Subjects;";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TOGET: All the records
        public override List<Subject> GetAll()
        {
            List<Subject> subjects = new List<Subject>();
            var sql = @"SELECT *FROM Subjects";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    subjects.Add(new Subject(int.Parse(string.Join("", sqlDataReader["Id"])), int.Parse(string.Join("", sqlDataReader["TeacherId"])), string.Join("", sqlDataReader["SubjectName"])));
                }
            }

            return subjects;
        }

        //TOGET: One record by its id
        public override Subject GetOne(int id)
        {
            var sql = $@"SELECT *FROM Subjects WHERE Id = {id}";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                return new Subject(int.Parse(string.Join("", sqlDataReader["Id"])), int.Parse(string.Join("", sqlDataReader["TeacherId"])), string.Join("", sqlDataReader["SubjectName"]));
            }

        }

        //TOGET: All the records which matches to the name
        public List<Subject> GetAllByName(string name)
        {
            List<Subject> subjects = new List<Subject>();
            var sql = $@"SELECT *FROM Subjects WHERE SubjectName = '{name}'";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    subjects.Add(new Subject(int.Parse(string.Join("", sqlDataReader["Id"])), int.Parse(string.Join("", sqlDataReader["TeacherId"])), string.Join("", sqlDataReader["SubjectName"])));
                }
            }

            return subjects;
        }

        //TODELETE: All the records
        public override void RemoveAll()
        {
            var sql = $@"DELETE FROM Subjects;";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: One record by its id
        public override void RemoveOne(int id)
        {
            var sql = $@"DELETE FROM Subjects WHERE Id = {id}";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }


        //TODELETE: All the records by id
        public override void RemoveRange(List<Subject> list)
        {
            var listToQuery = string.Join(" AND ", list.Select(i => $"Id = {i.Id}"));

            var sql = $@"DELETE FROM Subjects WHERE " + listToQuery;
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: All the records which matches to the name
        public void RemoveByName(string name)
        {
            var sql = $@"DELETE FROM Subjects WHERE SubjectName = '{name}'";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

    }
}
