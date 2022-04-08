namespace Sakura.Core;

public class SakuraWebApplication
{
    public void Start(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddGraylog();
        builder.Services.AddControllers();
        builder.Services.AddHealthChecks();
        
        WebApplication app = builder.Build();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.Run();
    }
}