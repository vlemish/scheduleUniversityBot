using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer.Types
{
    class TelegramUser : ITableEntity
    {
        public TelegramUser(int groupId, string username)
        {
            Username = username;
            GroupId = groupId;
        }

        public TelegramUser(int groupId, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            GroupId = groupId;
        }

        public TelegramUser(int groupId, string firstName, string lastName, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            GroupId = groupId;
        }

        public TelegramUser(int id, int groupId, string firstName, string lastName, string username)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            GroupId = groupId;
        }

        public TelegramUser()
        {

        }


        public int Id { get; set; }

        public int GroupId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
    }
}
