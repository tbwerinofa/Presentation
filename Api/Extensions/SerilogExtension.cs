using Serilog;
using Serilog.Formatting.Json;

namespace Presentation.Extensions;

public static class SerilogExtension
{
    public static void SerilogConfiguration(this IHostBuilder host, string? logsPath) {

        if(String.IsNullOrEmpty(logsPath))
            throw new System.ArgumentNullException("Logs path must be provided");

        host.UseSerilog(configureLogger: (context,loggerConfig) =>
        {
            loggerConfig.WriteTo.Console();
            loggerConfig.WriteTo.File(new JsonFormatter(),logsPath,rollingInterval: RollingInterval.Day);
        });

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }
}

