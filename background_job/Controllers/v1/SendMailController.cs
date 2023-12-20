using background_job.Interfaces;
using background_job.Models.Requests;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace background_job.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SendMailController : ApiControllerBase
    {
        public ISendMailService _sendMailService;

        public SendMailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        /// <summary>
        /// Send mail async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("send-email")]
        public async Task<ActionResult> SendMailAsync(SendMailRequest request)
        {
            BackgroundJob.Enqueue(() => _sendMailService.SendMailAsync(request));
            return Ok();
        }
    }
}
