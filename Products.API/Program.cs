using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Products.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {

            var hostBuilder = Host.CreateDefaultBuilder(args)
                                  .UseMetrics(options =>
                                      {
                                          options.EndpointOptions = endpointsOptions =>
                                          {
                                              endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                                              endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                                          };
                                      })
                                  .ConfigureWebHostDefaults(webBuilder =>
                                  {
                                      webBuilder.UseStartup<Startup>();
                                  });
            return hostBuilder;
        }            
    }
}
