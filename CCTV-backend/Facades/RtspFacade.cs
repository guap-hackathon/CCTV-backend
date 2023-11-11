using CCTV_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCTV_backend.Facades;

public class RtspFacade
{
    private readonly RtspService _rtspService;

    public RtspFacade(RtspService rtspService)
    {
        _rtspService = rtspService;
    }

    public async Task<IActionResult> ListenNewUrl(string rtspUrl)
    {
        var success = await _rtspService.StartStreamAsync(rtspUrl);
        IActionResult result = success ? new OkResult() : new StatusCodeResult(500);
        return result;
    }

    public async Task<IActionResult> StopListening(string rtspUrl)
    {
        var success = await _rtspService.StopStream(rtspUrl);
        IActionResult result = success ? new OkResult() : new StatusCodeResult(500);
        return result;
    }
}
