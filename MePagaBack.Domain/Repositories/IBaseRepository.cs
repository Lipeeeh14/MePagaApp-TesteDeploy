namespace MePagaBack.Domain.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task Cadastrar(T entity);
    Task Atualizar(T entity);
    Task Deletar(T entity);
    Task<T?> ObterPorId(long id);
    Task<IEnumerable<T>> ObterTodos();
    Task SaveChangesAsync();
}
