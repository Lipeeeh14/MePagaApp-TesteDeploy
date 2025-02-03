using MePagaBack.Data;
using MePagaBack.Data.Repositories;
using MePagaBack.Domain.Repositories.Interfaces;
using MePagaBack.Domain.Services;
using MePagaBack.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MePagaBack.API.Configuration;

public static class BuilderExtensions
{
    public static void AddConfigurations(this WebApplicationBuilder builder) 
    {
        builder.AddDataContext();
        builder.AddRepositories();
        builder.AddServices();
    }

    private static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<MePagaDbContext>(x => 
            { 
                x.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]); 
            });
    }

    private static void AddRepositories(this WebApplicationBuilder builder) 
    {
        builder.Services.AddScoped<IDevedorRepository, DevedorRepository>();
        builder.Services.AddScoped<IDividaRepository, DividaRepository>();
    }

    private static void AddServices(this WebApplicationBuilder builder) 
    {
        builder.Services.AddScoped<IDevedorService, DevedorService>();
        builder.Services.AddScoped<IDividaService, DividaService>();
    }
}
