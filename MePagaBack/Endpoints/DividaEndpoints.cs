using MePagaBack.Domain.DTO;
using MePagaBack.Domain.Services.Interfaces;

namespace MePagaBack.API.Endpoints;

internal static class DividaEndpoints
{
    internal static void MapDividaEndpoints(this IEndpointRouteBuilder app) 
    {
        var group = app.MapGroup("divida");

        group.WithTags("Divida");

        group.MapGet("/devedor/{devedorId}", async (IDividaService service, long devedorId) =>
            Results.Ok(await service.ConsultarDividasPorDevedorId(devedorId)));

        group.MapGet("{id}", async (IDividaService service, long id) =>
        {
            var result = await service.ConsultarDividaPorId(id);

            if (result is null) return Results.BadRequest();

            return Results.Ok(result);
        });

        group.MapPost("/", async (IDividaService service, CadastrarDividaDTO dto) =>
            Results.Ok(await service.Cadastrar(dto)));

        group.MapPut("/", async (IDividaService service, AtualizarDividaDTO dto) =>
            Results.Ok(await service.Atualizar(dto)));
        
        group.MapPut("/quitada", async (IDividaService service, DividaQuitadaDTO dto) =>
            Results.Ok(await service.AtualizarDividaQuitada(dto)));
    }
}
