using Npgsql;
using Telegram.Bots.Types;

namespace AutoriaProject;

public class DataBase
{
    public NpgsqlConnection con = new NpgsqlConnection(Constants.Connect);

    public async Task InsertIds(string id, long UserId)
    {
        var sql = "insert into public.\"FavId\"(\"Id\", \"UserId\")" + $"values (@Id, @UserId)";
        NpgsqlCommand comm = new NpgsqlCommand(sql, con);
        comm.Parameters.AddWithValue("Id", id);
        comm.Parameters.AddWithValue("UserID", UserId);
        await con.OpenAsync();
        await comm.ExecuteNonQueryAsync();
        await con.CloseAsync();
    }

    public async Task<List<string>> SelectIds(long UserId)
    {
        List<string> FavIds = new List<string>();
        await con.OpenAsync();
        var sql = "select \"Id\" from public.\"FavId\" where \"UserId\" = @UserId";
        NpgsqlCommand comm = new NpgsqlCommand(sql, con);
        comm.Parameters.AddWithValue("UserId", UserId);
        NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
        while (await npgsqlDataReader.ReadAsync())
        {
            FavIds.Add(npgsqlDataReader.GetString(0));
        }
        await con.CloseAsync();
        return FavIds;
    }

    public async Task DeleteIds(string Id, long UserId)
    {
        await con.OpenAsync();
        var sql = "delete from public.\"FavId\" where \"Id\" = @Id and \"UserId\" = @UserId";
        NpgsqlCommand comm = new NpgsqlCommand(sql, con);
        comm.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Text).Value = Id;
        comm.Parameters.Add("@UserId", NpgsqlTypes.NpgsqlDbType.Bigint).Value = UserId;
        await comm.ExecuteNonQueryAsync();
        await con.CloseAsync();
    }
}