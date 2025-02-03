using MePagaBack.Domain.DTO;
using MePagaBack.Domain.ViewModels;

namespace MePagaBack.Domain.Services.Interfaces;

public interface IDividaService
{
    Task<DividaViewModel> Cadastrar(CadastrarDividaDTO dto);
    Task<DividaViewModel> Atualizar(AtualizarDividaDTO dto);
    Task<DividaViewModel> AtualizarDividaQuitada(DividaQuitadaDTO dto);
    Task<IEnumerable<DividaViewModel>> ConsultarDividasPorDevedorId(long devedorId);
    Task<DividaViewModel> ConsultarDividaPorId(long id);
}
