using DbLayer.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbLayer.Tables
{
    //Subject scaffold:
    //Id INT PRIMARY KEY IDENTITY(1,1),
    //GroupId INT FOREIGN KEY REFERENCES Groups (Id),
    //FirstName NVARCHAR(),
    //LastName NVARCHAR().
    //Username NVARCHAR

    class UsersTable : DbTable<TelegramUser>
    {
        //uses parent's connection string
        public UsersTable(SqlConnection sqlConnection)
            :base(sqlConnection)
        {

        }

        //TOADD: A new Record
        public override void AddOne(TelegramUser obj)
        {
            var sql = $@"INSERT INTO Users VALUES (GroupId = '{obj.GroupId}', FirstName = '{obj.FirstName}', LastName = '{obj.LastName}', Username = '{obj.Username}' )";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TOGET: All the records
        public override List<TelegramUser> GetAll()
        {
            List<TelegramUser> users = new List<TelegramUser>();
            var sql = @"SELECT *FROM Users";
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    users.Add(new TelegramUser(int.Parse(string.Join("", sqlDataReader["Id"])), int.Parse(string.Join("", sqlDataReader["GroupId"])), string.Join("", sqlDataReader["FirstName"]), string.Join("", sqlDataReader["LastName"]), string.Join("", sqlDataReader["Username"])));
                }
            }

            return users;
        }

        //TOGET: One record by its id
        public override TelegramUser GetOne(int id)
        {
            var sql = $@"SELECT *FROM Users WHERE Id = {id}";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);

            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                return new TelegramUser(int.Parse(string.Join("", sqlDataReader["Id"])), int.Parse(string.Join("", sqlDataReader["GroupId"])), string.Join("", sqlDataReader["FirstName"]), string.Join("", sqlDataReader["LastName"]), string.Join("", sqlDataReader["Username"]));
            }
        }

        //Creates tables to further work with it
        //NOTE: FIRST OF ALL YOU SHOULD CALL THIS Method, if you didn't call this method before using other methods you would have an error!
        public override void CreateTable()
        {
            var sql = $@"CREATE TABLE Teachers
                    (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    GroupId INT,
                    FirstName NVARCHAR(20),
                    LastName NVARCHAR(20),
                    Username NVARCHAR(20),
                    CONSTRAINT FOREIGN KEY (GroupId) REFERENCES Groups (Id)
                    )";

            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //Deletes the table
        public override void Delete()
        {
            var sql = $@"DROP TABLE Users;";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: All the records
        public override void RemoveAll()
        {
            var sql = $@"DELETE FROM Users;";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //TODELETE: One record by its id
        public override void RemoveOne(int id)
        {
            var sql = $@"DELETE FROM Users WHERE Id = {id}";
            var sqlCommand = new SqlCommand(sql, _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        //There is no need for AddRange and RemoveRange because of specific work of the User Table
        public override void AddRange(List<TelegramUser> list)
        {
            throw new NotImplementedException();
        }


        public override void RemoveRange(List<TelegramUser> list)
        {
            throw new NotImplementedException();
        }
    }
}
