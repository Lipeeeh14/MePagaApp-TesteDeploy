using MePagaBack.Domain.DTO;
using MePagaBack.Domain.Models;
using MePagaBack.Domain.Repositories.Interfaces;
using MePagaBack.Domain.Services.Interfaces;
using MePagaBack.Domain.ViewModels;

namespace MePagaBack.Domain.Services;

public class DevedorService : IDevedorService
{
    private readonly IDevedorRepository _devedorRepository;

    public DevedorService(IDevedorRepository devedorRepository)
    {
        _devedorRepository = devedorRepository;
    }

    public async Task<DevedorViewModel> Cadastrar(CadastrarDevedorDTO dto)
    {
        try
        {
            var devedor = new Devedor(
                dto.Nome,
                dto.Email,
                dto.NumeroTelefone);

            await _devedorRepository.Cadastrar(devedor);
            await _devedorRepository.SaveChangesAsync();

            return new DevedorViewModel(devedor.Id, 
                devedor.Nome, 
                devedor.Email?.Email, 
                devedor.NumeroTelefone, 
                devedor.Ativa, 
                devedor.DataCriacao, 
                devedor.DataAtualizacao);
        }
        catch (Exception)
        {
            throw new Exception("Erro ao cadastrar o devedor.");
        }
    }

    public async Task<DevedorViewModel> Atualizar(AtualizarDevedorDTO dto)
    {
        try
        {
            var devedor = await _devedorRepository.ObterPorId(dto.Id);

            if (devedor is null) return null!;

            devedor.Atualizar(dto.Nome, dto.Email, dto.NumeroTelefone, dto.Ativo);

            await _devedorRepository.Atualizar(devedor);
            await _devedorRepository.SaveChangesAsync();

            return new DevedorViewModel(devedor.Id,
                devedor.Nome,
                devedor.Email?.Email,
                devedor.NumeroTelefone,
                devedor.Ativa,
                devedor.DataCriacao,
                devedor.DataAtualizacao);
        }
        catch (Exception)
        {
            throw new Exception("Erro ao atualizar o devedor.");
        }
    }

    public async Task<IEnumerable<DevedorViewModel>> ConsultarDevedores()
    {
        var devedores = await _devedorRepository.ObterTodos();

        if (devedores is null) return [];

        var devedoresVm = devedores.Select(x => new DevedorViewModel(x.Id,
            x.Nome,
            x.Email?.Email,
            x.NumeroTelefone,
            x.Ativa,
            x.DataCriacao,
            x.DataAtualizacao));

        return devedoresVm;
    }

    public async Task<DevedorViewModel> ConsultarDevedorPorId(long id)
    {
        var devedor = await _devedorRepository.ObterPorId(id);

        if (devedor is null) return null!;

        return new DevedorViewModel(devedor.Id,
            devedor.Nome,
            devedor.Email?.Email,
            devedor.NumeroTelefone,
            devedor.Ativa,
            devedor.DataCriacao,
            devedor.DataAtualizacao);
    }
}
