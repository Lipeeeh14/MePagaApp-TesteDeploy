using MePagaBack.Domain.Models;
using MePagaBack.Domain.Repositories.Interfaces;

namespace MePagaBack.Data.Repositories;

public class DevedorRepository(MePagaDbContext context) : BaseRepository<Devedor>(context), IDevedorRepository
{
}
