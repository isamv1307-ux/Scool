using Microsoft.Data.SqlClient;
using SchoolEquipmentApp.Models;
namespace SchoolEquipmentApp.Services;
public class AuthService
{
    private readonly DatabaseService _db = new();
    public User? Login(string login, string password)
    {
        var t = _db.GetTable("SELECT TOP 1 * FROM Users WHERE Login=@l AND Password=@p",
            new SqlParameter("@l", login), new SqlParameter("@p", password));
        if (t.Rows.Count == 0) return null;
        var r = t.Rows[0];
        return new User { UserID = (int)r["UserID"], Login = r["Login"].ToString()!, FullName = r["FullName"].ToString()!, Password = r["Password"].ToString()! };
    }
}
