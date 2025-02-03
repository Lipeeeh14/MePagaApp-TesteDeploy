using MePagaBack.Domain.Models.Base;

namespace MePagaBack.Domain.Models;

public class Divida : BaseModel
{
    public decimal Valor { get; private set; }
    public bool Quitada { get; private set; }

    public long DevedorId { get; private set; }
    public Devedor? Devedor { get; private set; }

    public Divida()
    {
    }

    public Divida(decimal valor, long devedorId)
    {
        Valor = valor;
        DevedorId = devedorId;
    }

    public void Atualizar(decimal valor, bool quitada) 
    {
        Valor = valor;
        Quitada = quitada;

        base.Atualizar();
    }

    public void DividaQuitada()
    {
        Atualizar();
        Quitada = false;
    }
}
