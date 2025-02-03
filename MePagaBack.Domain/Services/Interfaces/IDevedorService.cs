using MePagaBack.Domain.DTO;
using MePagaBack.Domain.ViewModels;

namespace MePagaBack.Domain.Services.Interfaces;

public interface IDevedorService
{
    Task<DevedorViewModel> Cadastrar(CadastrarDevedorDTO dto);
    Task<DevedorViewModel> Atualizar(AtualizarDevedorDTO dto);
    Task<IEnumerable<DevedorViewModel>> ConsultarDevedores();
    Task<DevedorViewModel> ConsultarDevedorPorId(long id);
}
