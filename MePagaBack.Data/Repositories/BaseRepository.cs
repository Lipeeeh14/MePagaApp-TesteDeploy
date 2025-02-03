using MePagaBack.Domain.Models.Base;
using MePagaBack.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MePagaBack.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected readonly MePagaDbContext _context;

    public BaseRepository(MePagaDbContext context) => _context = context;

    public async Task Cadastrar(T entity) => await _context.AddAsync(entity);

    public async Task Atualizar(T entity) => await Task.Run(() => _context.Update(entity));

    public async Task Deletar(T entity) => await Task.Run(() => _context.Remove(entity));

    public async Task<IEnumerable<T>> ObterTodos() => await _context.Set<T>().ToListAsync();

    public async Task<T?> ObterPorId(long id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
