using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;


namespace Mvc.Services.Logging
{
    public static class LoggingConfiguration
    {
        private const string OutputTemplate =
            @"[{Timestamp:yy-MM-dd HH:mm:ss} {Level}]{ApplicationName}:{SourceContext}{NewLine}Message:{Message}{NewLine}{Exception}{NewLine}";

        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
        {
            return builder
                .ConfigureLogging((context, logging) => { logging.ClearProviders(); })
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.File(
                        path: "ErrorLog.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Error,
                        outputTemplate: OutputTemplate)
                    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Verbose);
                });
        }
    }
}
