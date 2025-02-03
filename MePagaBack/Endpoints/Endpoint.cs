namespace MePagaBack.API.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app) 
    {
        app.MapDevedorEndpoints();
        app.MapDividaEndpoints();
    }
}
