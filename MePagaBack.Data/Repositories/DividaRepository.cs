using MePagaBack.Domain.Models;
using MePagaBack.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MePagaBack.Data.Repositories;

public class DividaRepository(MePagaDbContext context) : BaseRepository<Divida>(context), IDividaRepository
{
    public async Task<IEnumerable<Divida>> ObterDividasPorDevedorId(long devedorId) 
        => await _context.Set<Divida>()
            .Where(x => x.DevedorId == devedorId)
            .ToListAsync();
}
