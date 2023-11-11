using CCTV_backend.Entity;
using CCTV_backend.Facades;
using Microsoft.AspNetCore.Mvc;

namespace CCTV_backend.Controllers;

[Controller]
[Route("api/rtsp")]
public class RtspController : ControllerBase
{
    private readonly RtspFacade _rtspFacade;

    public RtspController(RtspFacade rtspFacade)
    {
        _rtspFacade = rtspFacade;
    }

    [HttpPost]
    public Task<IActionResult> ListenNewUrl(
        [FromBody]RtspStreamDto rtspRtspStream)
    {
        return _rtspFacade.ListenNewUrl(rtspRtspStream.RtspUrl);
    }

    [HttpDelete]
    public Task<IActionResult> StopListening(
        [FromBody]RtspStreamDto rtspRtspStream)
    {
        return _rtspFacade.StopListening(rtspRtspStream.RtspUrl);
    }
}
