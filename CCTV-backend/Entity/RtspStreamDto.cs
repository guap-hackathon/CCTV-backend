namespace CCTV_backend.Entity;

public record RtspStreamDto
{
    public required string RtspUrl { get; init; }
}
