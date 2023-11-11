using CCTV_backend.Db;

namespace CCTV_backend.Services;

public class MongoInitializer : IHostedService
{
    private readonly MongoStore _mongoStore;

    public MongoInitializer(MongoStore mongoStore)
    {
        _mongoStore = mongoStore;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _mongoStore.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}