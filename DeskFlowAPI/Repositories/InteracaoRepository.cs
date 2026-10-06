using DeskFlowAPI.Data;
using DeskFlowAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI.Repositories;

public class InteracaoRepository
{
    private readonly AppDbContext _context;

    public InteracaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Interacao interacao)
    {
        await _context.Interacoes.AddAsync(interacao);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Interacao>> BuscarPorChamadoId(int chamadoId)
    {
        return await _context.Interacoes
            .Where(i => i.ChamadoId == chamadoId)
            .ToListAsync();
    }
}