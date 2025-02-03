using MePagaBack.Domain.Models;

namespace MePagaBack.Domain.Repositories.Interfaces;

public interface IDividaRepository : IBaseRepository<Divida>
{
    Task<IEnumerable<Divida>> ObterDividasPorDevedorId(long devedorId);
}
