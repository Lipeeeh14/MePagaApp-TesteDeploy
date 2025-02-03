namespace MePagaBack.Domain.Models.Base;

public abstract class BaseModel
{
    public long Id { get; private set; }
    public DateTime DataCriacao { get; private set; } = DateTime.Now;
    public DateTime? DataAtualizacao { get; private set; }

    protected BaseModel()
    {
    }

    public void Atualizar() => DataAtualizacao = DateTime.Now;
}
