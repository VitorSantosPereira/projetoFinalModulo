using DeskFlowAPI.Models.Entities;
using DeskFlowAPI.Repositories;

namespace DeskFlowAPI.Services;

public class InteracaoService
{
    private readonly InteracaoRepository _repository;
    private readonly ChamadoRepository _chamadoRepository;

    public InteracaoService(
        InteracaoRepository repository,
        ChamadoRepository chamadoRepository)
    {
        _repository = repository;
        _chamadoRepository = chamadoRepository;
    }

    public async Task<Interacao> Criar(
        int chamadoId,
        Interacao interacao)
    {
        var chamado = await _chamadoRepository.BuscarPorId(chamadoId);

        if (chamado == null)
        {
            throw new ArgumentException("Chamado não encontrado.");
        }

        if (chamado.Status == Status.Fechado)
        {
            throw new InvalidOperationException(
                "Não é possível adicionar interação em um chamado fechado."
            );
        }

        if (string.IsNullOrWhiteSpace(interacao.Autor))
        {
            throw new ArgumentException(
                "O autor da interação é obrigatório."
            );
        }

        if (string.IsNullOrWhiteSpace(interacao.Mensagem))
        {
            throw new ArgumentException(
                "A mensagem da interação é obrigatória."
            );
        }

        interacao.ChamadoId = chamadoId;
        interacao.DataRegistro = DateTime.Now;

        await _repository.Adicionar(interacao);

        return interacao;
    }
}