using CCTV_backend.Services;

namespace CCTV_backend.Facades;

public class RtspFacade
{
    private readonly RtspService _rtspService;

    public RtspFacade(RtspService rtspService)
    {
        _rtspService = rtspService;
    }

    public async Task GetStreamAsync(string rtspUrl)
    {
        await _rtspService.GetStreamAsync(rtspUrl);
    }
}
