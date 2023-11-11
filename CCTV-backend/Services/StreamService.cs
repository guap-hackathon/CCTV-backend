namespace CCTV_backend.Services;

public class StreamService : IHostedService
{
    private readonly RtspService _rtspService;

    public StreamService(RtspService rtspService)
    {
        _rtspService = rtspService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _rtspService.Init();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _rtspService.Stop();
        return Task.CompletedTask;
    }
}
