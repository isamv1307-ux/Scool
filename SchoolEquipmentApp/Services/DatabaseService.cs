using System.Data;
using Microsoft.Data.SqlClient;
using SchoolEquipmentApp.Data;
namespace SchoolEquipmentApp.Services;
public class DatabaseService
{
    public DataTable GetTable(string sql, params SqlParameter[] parameters)
    {
        using var con = DbConnectionFactory.Create();
        using var cmd = new SqlCommand(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        using var da = new SqlDataAdapter(cmd);
        var table = new DataTable(); da.Fill(table); return table;
    }
    public int Execute(string sql, params SqlParameter[] parameters)
    {
        using var con = DbConnectionFactory.Create(); con.Open();
        using var cmd = new SqlCommand(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteNonQuery();
    }
    public object? Scalar(string sql, params SqlParameter[] parameters)
    {
        using var con = DbConnectionFactory.Create(); con.Open();
        using var cmd = new SqlCommand(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteScalar();
    }
}
