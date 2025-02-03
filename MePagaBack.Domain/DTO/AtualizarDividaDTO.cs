namespace MePagaBack.Domain.DTO;

public record AtualizarDividaDTO(
    long DividaId,
    decimal Valor,
    bool Quitada);