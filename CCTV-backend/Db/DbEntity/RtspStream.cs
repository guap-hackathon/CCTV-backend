namespace CCTV_backend.Db.DbEntity;

public record RtspStream
{
    public required string Url { get; init; }

    public required bool IsReading { get; set; }
}
