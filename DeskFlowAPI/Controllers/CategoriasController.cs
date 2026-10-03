using DeskFlowAPI.Models.Entities;
using DeskFlowAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowAPI.Controllers;

[ApiController]
[Route("api/categorias")]
public class CategoriasController : ControllerBase
{
    private readonly CategoriaService _service;

    public CategoriasController(CategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodas()
    {
        var categorias = await _service.BuscarTodas();

        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var categoria = await _service.BuscarPorId(id);

        if (categoria == null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Categoria categoria)
    {
        var novaCategoria = await _service.Criar(categoria);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novaCategoria.Id },
            novaCategoria
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        Categoria categoria)
    {
        var categoriaExistente = await _service.BuscarPorId(id);

        if (categoriaExistente == null)
        {
            return NotFound();
        }

        categoriaExistente.Nome = categoria.Nome;

        await _service.Atualizar(categoriaExistente);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var categoria = await _service.BuscarPorId(id);

        if (categoria == null)
        {
            return NotFound();
        }

        await _service.Excluir(categoria);

        return NoContent();
    }
}