using CCTV_backend.Db;
using CCTV_backend.Db.DbEntity;
using CCTV_backend.Entity;
using MongoDB.Driver;

namespace CCTV_backend.Services;

public class RtspService
{
    private readonly MongoStore _mongoStore;
    private readonly StreamingClient _streamingClient;

    public RtspService(
        MongoStore mongoStore,
        StreamingClient streamingClient)
    {
        _mongoStore = mongoStore;
        _streamingClient = streamingClient;
    }

    public async Task<bool> StartStreamAsync(string rtspUrl)
    {
        var filter = Builders<RtspStream>.Filter.Eq(stream => stream.Url, rtspUrl);
        var update = Builders<RtspStream>.Update.Set(stream => stream.IsReading, true);
        await _mongoStore.Streams.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

        await _streamingClient.SendUrlAsync(rtspUrl);
        return false;
    }

    public async Task<bool> StopStream(string rtspUrl)
    {
        await _streamingClient.StopAsync(rtspUrl);
        return false;
    }

    public async Task Init()
    {
        await Task.CompletedTask;
    }

    public void Stop()
    {
        var filter = Builders<RtspStream>.Filter.Empty;
        var update = Builders<RtspStream>.Update.Set(stream => stream.IsReading, false);
        _mongoStore.Streams.UpdateMany(filter, update);
    }
}
