using System;
using System.Collections.Generic;
using System.Text;

namespace DbLayer
{
    interface IEntity : IDisposable
    {
        string ConnectionString { get; }

        bool isConnected { get; }

        void CreateContext();

        void OpenConnection();

        void CloseConnection();


    }
}
