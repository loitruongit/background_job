using Microsoft.AspNetCore.Mvc;

namespace background_job.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
