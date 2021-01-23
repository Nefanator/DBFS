using DatabaseWrapper;
using DatabaseWrapper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
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
        public void WriteUser_WriteItem_ReadItem()
        {
            var user = _users.Create("Jim");
            var ball = _items.CreateBall(user, "/", "Red", 4);
            var ball1 = _items.CreateBall(user, "/foo/", "Red", 3);
            var ball2 = _items.CreateBall(user, "/foo/bar", "Purple", 4);

            var itemMetadata = _items.ReadMetadata(user, "/foo/").Single();

            _items.Delete(itemMetadata);

            var allItems = _items.ReadMetadata(user, "%");

            //_dir.Delete(user, "/SubFolder/");

            //var item = _items.Read<Ball>(itemMetadata);

            //Assert.AreEqual(ball, item);
        }
    }
}
