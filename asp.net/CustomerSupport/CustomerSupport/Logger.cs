using Serilog;
using Serilog.Exceptions;

namespace CustomerSupport
{
    public static class Logging
    {
        public static Action<HostBuilderContext, IServiceProvider, LoggerConfiguration> ConfigureLogger =>
            (context, service, configuration) =>
            {
                var env = context.HostingEnvironment;
                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                    .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                    .Enrich.WithExceptionDetails()
                    .ReadFrom.Configuration(context.Configuration);
            };
    }
}
