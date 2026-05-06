using Microsoft.Data.SqlClient;
namespace SchoolEquipmentApp.Data;
public static class DbConnectionFactory
{
    // Измените строку подключения под ваш SQL Server
    public static string ConnectionString { get; set; } = "Server=.;Database=SchoolEquipmentDB;Trusted_Connection=True;TrustServerCertificate=True";
    public static SqlConnection Create() => new(ConnectionString);
}
