using App.UnitOfWork;
using Domain.Interfaces;

namespace API.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
    });

    public static void AddAplicacionServices(this IServiceCollection services)
        {
            //Services.AddScoped<IpaisInterface,PaisRepository>();
            //Services.AddScoped<ITipoPersona,TipoPeronsaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
}
