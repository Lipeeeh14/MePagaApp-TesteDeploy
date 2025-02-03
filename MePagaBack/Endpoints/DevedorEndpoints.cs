using MePagaBack.Domain.DTO;
using MePagaBack.Domain.Services.Interfaces;

namespace MePagaBack.API.Endpoints;

internal static class DevedorEndpoints
{
    internal static void MapDevedorEndpoints(this IEndpointRouteBuilder app) 
    {
        var group = app.MapGroup("devedor");

        group.WithTags("Devedor");

        group.MapGet("/", async (IDevedorService service) => 
            Results.Ok(await service.ConsultarDevedores()));

        group.MapGet("{id}", async (IDevedorService service, long id) =>
        {
            var result = await service.ConsultarDevedorPorId(id);

            if (result is null) return Results.BadRequest();

            return Results.Ok(result);
        });

        group.MapPost("/", async (IDevedorService service, CadastrarDevedorDTO dto) 
            => Results.Ok(await service.Cadastrar(dto)));

        group.MapPut("/", async (IDevedorService service, AtualizarDevedorDTO dto) =>
        {
            var result = await service.Atualizar(dto);

            if (result is null) return Results.BadRequest();

            return Results.Ok(result);
        });
    }
}
