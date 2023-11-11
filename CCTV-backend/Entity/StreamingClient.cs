using Microsoft.Extensions.Options;

namespace CCTV_backend.Entity;

public class StreamingClient
{
    private readonly HttpClient _client;
    private readonly StreamClientOptions _options;

    public StreamingClient(
        HttpClient client,
        IOptions<StreamClientOptions> options)
    {
        _client = client;
        _options = options.Value;
    }

    public async Task SendUrlAsync(string url)
    {
        var fullUrl = AddUrl(_options);
        var response = await _client.PostAsJsonAsync(fullUrl, new RtspStreamDto { RtspUrl = url });
    }

    public async Task StopAsync(string url)
    {
        var fullUrl = RemoveUrl(_options);
        var response = await _client.PostAsJsonAsync(fullUrl, new RtspStreamDto { RtspUrl = url });
    }

    private string AddUrl(StreamClientOptions options) =>
        string.Concat(options.UrlBase, "/", _options.AddUrl);

    private string RemoveUrl(StreamClientOptions options) =>
        string.Concat(options.UrlBase, "/", _options.RemoveUrl);
}
