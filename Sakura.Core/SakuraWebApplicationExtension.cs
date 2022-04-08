using Serilog;

namespace Sakura.Core;

public static class SakuraWebApplicationExtension
{
    public static WebApplicationBuilder AddGraylog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        return builder;
    }
}