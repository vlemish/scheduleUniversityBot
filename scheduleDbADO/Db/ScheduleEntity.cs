using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer
{
    class ScheduleEntity : IEntity
    {
        public string ConnectionString => throw new NotImplementedException();

        public bool isConnected => throw new NotImplementedException();

        public void CloseConnection()
        {
            throw new NotImplementedException();
        }

        public void CreateContext()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}
