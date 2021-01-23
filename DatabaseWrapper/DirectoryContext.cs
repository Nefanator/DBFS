using Dapper;
using DatabaseWrapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseWrapper
{
    public class DirectoryContext
    {
        private readonly IDbConnection _connection;

        public DirectoryContext(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Update(User owner, string oldPath, string newPath)
        {
            _connection.Execute(
                "UpdatePath",
                new { OwenerId = owner.Id, OldPath = oldPath, NewPath = newPath },
                commandType: CommandType.StoredProcedure);
        }

        public void Delete(User owner, string path)
        {
            _connection.Execute(
                "DeletePath",
                new { OwnerId = owner.Id, Path = path },
                commandType: CommandType.StoredProcedure);
        }
    }
}
