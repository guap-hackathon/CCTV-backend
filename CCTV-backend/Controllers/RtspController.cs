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

    [HttpGet("{rtspUrl}")]
    public async Task<IActionResult> RtspUrl(
        [FromRoute]string rtspUrl)
    {
        await _rtspFacade.GetStreamAsync(rtspUrl);
        return Ok();
    }
}
