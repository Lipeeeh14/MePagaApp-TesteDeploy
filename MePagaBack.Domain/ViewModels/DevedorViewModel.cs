namespace MePagaBack.Domain.ViewModels;

public record DevedorViewModel(long Id, 
    string Nome, 
    string? Email, 
    string NumeroTelefone, 
    bool Ativo, 
    DateTime DataCriacao, 
    DateTime? DataAtualizacao);