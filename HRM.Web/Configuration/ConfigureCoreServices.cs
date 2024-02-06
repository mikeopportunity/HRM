using HRM.Core.Interfaces;
using HRM.DAL;
using HRM.Service.Interfaces;
using HRM.Service.Services;

namespace HRM.Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            
            services.AddScoped<IDownloadService, DownloadService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<IReportService, ReportService>();

            return services;
        }
    }
}
