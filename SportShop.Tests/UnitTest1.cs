using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using SportShop.Db;

namespace SportShop.Tests
{
    [TestClass]
    public class DbConnectionTests
    {
        [TestMethod]
        public void GetConnection_ReturnsOpenConnection()
        {
            // получение соединения
            using (NpgsqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                // проверка, что соединение открыто
                Assert.AreEqual(System.Data.ConnectionState.Open, connection.State);
            }
        }
    }
}
