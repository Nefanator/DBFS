using Dapper;
using DatabaseWrapper.Models;
using System.Collections.Generic;
using System.Data;

namespace DatabaseWrapper
{
    public class UserContext
    {
        private readonly IDbConnection _connection;

        public UserContext(IDbConnection connection)
        {
            _connection = connection;
        }

        public User Create(string name)
        {
            var id =
                _connection.QuerySingle<int>(
                    "CreateUser",
                    new { Name = name },
                    commandType: CommandType.StoredProcedure);

            return new User(id, name);
        }

        public IEnumerable<User> Read()
        {
            return _connection.Query<User>(
                "ReadUsers",
                commandType: CommandType.StoredProcedure);
        }

        public void Update(User user)
        {
            _connection.Execute(
                "UpdateUser",
                new { user.Id, user.Name },
                commandType: CommandType.StoredProcedure);
        }

        public void Delete(User user)
        {
            _connection.Execute(
                "DeleteUser",
                new { user.Id },
                commandType: CommandType.StoredProcedure);
        }
    }
}
