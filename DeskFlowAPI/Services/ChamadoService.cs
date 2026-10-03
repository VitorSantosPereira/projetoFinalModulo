using DeskFlowAPI.Models.Entities;
using DeskFlowAPI.Repositories;

namespace DeskFlowAPI.Services;

public class ChamadoService
{
    private readonly ChamadoRepository _repository;

    public ChamadoService(ChamadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Chamado>> BuscarTodos(
        Status? status,
        Prioridade? prioridade,
        int? categoriaId)
    {
        return await _repository.BuscarComFiltros(
            status,
            prioridade,
            categoriaId
        );
    }

    public async Task<Chamado?> BuscarPorId(int id)
    {
        return await _repository.BuscarPorId(id);
    }

    public async Task<Chamado> Criar(Chamado chamado)
    {
        if (string.IsNullOrWhiteSpace(chamado.Titulo))
        {
            throw new ArgumentException("O título do chamado é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(chamado.Descricao))
        {
            throw new ArgumentException("A descrição do chamado é obrigatória.");
        }

        if (string.IsNullOrWhiteSpace(chamado.SolicitanteNome))
        {
            throw new ArgumentException("O nome do solicitante é obrigatório.");
        }

        if (chamado.CategoriaId <= 0)
        {
            throw new ArgumentException("A categoria do chamado é obrigatória.");
        }

        chamado.Status = Status.Aberto;
        chamado.DataAbertura = DateTime.Now;

        await _repository.Adicionar(chamado);

        return chamado;
    }

    public async Task Iniciar(Chamado chamado)
    {
        if (chamado.Status != Status.Aberto)
        {
            throw new InvalidOperationException(
                "Somente chamados abertos podem ser iniciados."
            );
        }

        chamado.Status = Status.EmAndamento;

        await _repository.Atualizar(chamado);
    }

    public async Task Encerrar(Chamado chamado, string solucao)
    {
        if (chamado.Status == Status.Fechado)
        {
            throw new InvalidOperationException(
                "O chamado já está fechado."
            );
        }

        if (string.IsNullOrWhiteSpace(solucao))
        {
            throw new ArgumentException(
                "A solução do chamado é obrigatória."
            );
        }

        chamado.Solucao = solucao;
        chamado.DataFechamento = DateTime.Now;
        chamado.Status = Status.Fechado;

        await _repository.Atualizar(chamado);
    }
}