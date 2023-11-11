namespace CCTV_backend.Db;

public record MongoOptions
{
    public required string ConnectionString { get; init; }

    public required string DbName { get; init; }
}
