using CCTV_backend.Db.DbEntity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CCTV_backend.Db;

public class MongoStore
{
    private readonly MongoOptions _mongoOptions;

    public IMongoCollection<RtspStream> Streams { get; private set; } = null!;

    public MongoStore(IOptions<MongoOptions> options)
    {
        _mongoOptions = options.Value;
    }

    public void Start()
    {
        var client = new MongoClient(_mongoOptions.ConnectionString);
        var db = client.GetDatabase(_mongoOptions.DbName);
        Streams = db.GetCollection<RtspStream>("Streams");
    }
}
