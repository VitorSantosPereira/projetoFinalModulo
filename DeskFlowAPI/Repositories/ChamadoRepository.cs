using DeskFlowAPI.Data;
using DeskFlowAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI.Repositories;

public class ChamadoRepository
{
    private readonly AppDbContext _context;

    public ChamadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Chamado>> BuscarTodos()
    {
        return await _context.Chamados
            .Include(c => c.Categoria)
            .ToListAsync();
    }

    public async Task<Chamado?> BuscarPorId(int id)
    {
        return await _context.Chamados
            .Include(c => c.Categoria)
            .Include(c => c.Interacoes)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Adicionar(Chamado chamado)
    {
        await _context.Chamados.AddAsync(chamado);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Chamado chamado)
    {
        _context.Chamados.Update(chamado);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Chamado>> BuscarComFiltros(
        Status? status,
        Prioridade? prioridade,
        int? categoriaId)
    {
        var consulta = _context.Chamados
            .Include(c => c.Categoria)
            .AsQueryable();

        if (status.HasValue)
        {
            consulta = consulta.Where(c => c.Status == status.Value);
        }

        if (prioridade.HasValue)
        {
            consulta = consulta.Where(c => c.Prioridade == prioridade.Value);
        }

        if (categoriaId.HasValue)
        {
            consulta = consulta.Where(c => c.CategoriaId == categoriaId.Value);
        }

        return await consulta.ToListAsync();
    }
}