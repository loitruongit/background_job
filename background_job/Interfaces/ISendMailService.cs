using background_job.Models.Requests;

namespace background_job.Interfaces
{
    public interface ISendMailService
    {
        Task SendMailAsync(SendMailRequest request);
    }
}
