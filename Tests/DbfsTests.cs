using DatabaseWrapper;
using DatabaseWrapper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static IDbConnection _connection;
        private static ItemsContext _items;
        private static UserContext _users;

        [ClassInitialize]
        public static void DatabaseInitialise(TestContext _)
        {
            const string ConnectionString = @"
Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=DBFS;
Integrated Security=True;";

            _connection = new SqlConnection(ConnectionString);

            _users = new UserContext(_connection);
            _items = new ItemsContext(_connection);
        }

        [TestMethod, TestCategory("Integration"), DoNotParallelize]
        public void Item()
        {
            var user = _users.Create("Jim");
            var ball = _items.CreateBall(user, "/", "Red", 4);

            var itemMetadata = _items.ReadMetadata(user, "/").Single();

            var item = _items.Read<Ball>(itemMetadata);

            Assert.AreEqual(ball, item);
        }
    }
}