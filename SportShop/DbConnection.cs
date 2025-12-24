using Npgsql;
namespace SportShop.Db
{
    public static class DbConnection
    {
        private static string cs = "Host=localhost;Port=5432;Database=sportshop;Username=postgres;Password=123";
        public static NpgsqlConnection GetConnection() => new NpgsqlConnection(cs);
    }
}