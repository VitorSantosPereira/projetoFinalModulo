using DeskFlowAPI.Data;
using DeskFlowAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI.Repositories;

public class CategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> BuscarTodas()
    {
        return await _context.Categorias
            .ToListAsync();
    }

    public async Task<Categoria?> BuscarPorId(int id)
    {
        return await _context.Categorias
            .Include(c => c.Chamados)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Adicionar(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}