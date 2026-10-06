using DeskFlowAPI.Models.Entities;
using DeskFlowAPI.Repositories;

namespace DeskFlowAPI.Services;

public class CategoriaService
{
    private readonly CategoriaRepository _repository;

    public CategoriaService(CategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Categoria>> BuscarTodas()
    {
        return await _repository.BuscarTodas();
    }

    public async Task<Categoria?> BuscarPorId(int id)
    {
        return await _repository.BuscarPorId(id);
    }

    public async Task<Categoria> Criar(Categoria categoria)
    {
        if (string.IsNullOrWhiteSpace(categoria.Nome))
        {
            throw new ArgumentException("O nome da categoria é obrigatório.");
        }

        await _repository.Adicionar(categoria);

        return categoria;
    }

    public async Task Atualizar(Categoria categoria)
    {
        if (string.IsNullOrWhiteSpace(categoria.Nome))
        {
            throw new ArgumentException("O nome da categoria é obrigatório.");
        }

        await _repository.Atualizar(categoria);
    }

    public async Task Excluir(Categoria categoria)
    {
        if (categoria.Chamados.Count > 0)
        {
            throw new InvalidOperationException(
                "Não é possível excluir uma categoria que possui chamados."
            );
        }

        await _repository.Remover(categoria);
    }
}