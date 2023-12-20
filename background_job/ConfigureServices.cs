using background_job.Interfaces;
using background_job.Services;
using Hangfire;
using Hangfire.MemoryStorage;

namespace background_job
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddHangfire(c => c.UseMemoryStorage());
            services.AddHangfireServer(options => options.WorkerCount = 1);

            return services;
        }
    }
}
