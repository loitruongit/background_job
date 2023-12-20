namespace background_job.Models.Requests
{
    public class SendMailRequest
    {
        public string ReceiverEmail { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
