using MePagaBack.Domain.DTO;
using MePagaBack.Domain.Models;
using MePagaBack.Domain.Repositories.Interfaces;
using MePagaBack.Domain.Services.Interfaces;
using MePagaBack.Domain.ViewModels;

namespace MePagaBack.Domain.Services;

public class DividaService : IDividaService
{
    private readonly IDevedorRepository _devedorRepository;
    private readonly IDividaRepository _dividaRepository;

    public DividaService(IDevedorRepository devedorRepository, IDividaRepository dividaRepository)
    {
        _devedorRepository = devedorRepository;
        _dividaRepository = dividaRepository;
    }

    public async Task<DividaViewModel> Cadastrar(CadastrarDividaDTO dto)
    {
        try
        {
            var devedor = await _devedorRepository.ObterPorId(dto.DevedorId);

            if (devedor is null) return null!;

            var divida = new Divida(dto.Valor, dto.DevedorId);

            await _dividaRepository.Cadastrar(divida);
            await _dividaRepository.SaveChangesAsync();

            return new DividaViewModel(
                divida.Id,
                divida.DevedorId,
                divida.Valor,
                divida.Quitada,
                divida.DataCriacao,
                divida.DataAtualizacao);
        }
        catch (Exception)
        {
            throw new Exception("Erro ao cadastrar a divida.");
        }
    }

    public async Task<DividaViewModel> Atualizar(AtualizarDividaDTO dto)
    {
        try
        {
            var divida = await _dividaRepository.ObterPorId(dto.DividaId);

            if (divida is null) return null!;

            divida.Atualizar(dto.Valor, dto.Quitada);

            await _dividaRepository.Atualizar(divida);
            await _dividaRepository.SaveChangesAsync();

            return new DividaViewModel(
                divida.Id,
                divida.DevedorId,
                divida.Valor,
                divida.Quitada,
                divida.DataCriacao,
                divida.DataAtualizacao);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<DividaViewModel> AtualizarDividaQuitada(DividaQuitadaDTO dto)
    {
        var divida = await _dividaRepository.ObterPorId(dto.DividaId);

        if (divida is null) return null!;

        divida.DividaQuitada();

        await _dividaRepository.Atualizar(divida);
        await _dividaRepository.SaveChangesAsync();

        return new DividaViewModel(
            divida.Id,
            divida.DevedorId,
            divida.Valor,
            divida.Quitada,
            divida.DataCriacao,
            divida.DataAtualizacao);
    }

    public async Task<DividaViewModel> ConsultarDividaPorId(long id)
    {
        var divida = await _dividaRepository.ObterPorId(id);

        if (divida is null) return null!;

        return new DividaViewModel(
            divida.Id,
            divida.DevedorId,
            divida.Valor,
            divida.Quitada,
            divida.DataCriacao,
            divida.DataAtualizacao);
    }

    public async Task<IEnumerable<DividaViewModel>> ConsultarDividasPorDevedorId(long devedorId)
    {
        var dividas = await _dividaRepository.ObterDividasPorDevedorId(devedorId);

        return dividas.Select(divida => new DividaViewModel(
            divida.Id,
            divida.DevedorId,
            divida.Valor,
            divida.Quitada,
            divida.DataCriacao,
            divida.DataAtualizacao));
    }
}
