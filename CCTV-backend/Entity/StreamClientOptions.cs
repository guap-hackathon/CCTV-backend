namespace CCTV_backend.Entity;

public class StreamClientOptions
{
    public required string UrlBase { get; init; }

    public required string AddUrl { get; init; }

    public required string RemoveUrl { get; init; }
}
