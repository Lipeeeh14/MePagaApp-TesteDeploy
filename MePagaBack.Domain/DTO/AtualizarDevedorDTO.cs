namespace MePagaBack.Domain.DTO;

public record AtualizarDevedorDTO(long Id, string Nome, string? Email, string NumeroTelefone, bool Ativo);