namespace MePagaBack.Domain.ViewModels;

public record DividaViewModel(
    long Id,
    long DevedorId,
    decimal Valor,
    bool Quitada,
    DateTime DataCriacao,
    DateTime? DataAtaulizacao);