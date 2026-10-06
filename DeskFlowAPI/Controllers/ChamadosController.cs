using DeskFlowAPI.Models.Entities;
using DeskFlowAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowAPI.Controllers;

[ApiController]
[Route("api/chamados")]
public class ChamadosController : ControllerBase
{
    private readonly ChamadoService _service;
    private readonly InteracaoService _interacaoService;

    public ChamadosController(
    ChamadoService service,
    InteracaoService interacaoService)
    {
        _service = service;
        _interacaoService = interacaoService;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos(
        [FromQuery] Status? status,
        [FromQuery] Prioridade? prioridade,
        [FromQuery] int? categoriaId)
    {
        var chamados = await _service.BuscarTodos(
            status,
            prioridade,
            categoriaId
        );

        return Ok(chamados);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var chamado = await _service.BuscarPorId(id);

        if (chamado == null)
        {
            return NotFound();
        }

        return Ok(chamado);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Chamado chamado)
    {
        var novoChamado = await _service.Criar(chamado);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = novoChamado.Id },
            novoChamado
        );
    }

    [HttpPost("{id}/iniciar")]
    public async Task<IActionResult> Iniciar(int id)
    {
        var chamado = await _service.BuscarPorId(id);

        if (chamado == null)
        {
            return NotFound();
        }

        await _service.Iniciar(chamado);

        return Ok(chamado);
    }

    [HttpPost("{id}/encerrar")]
    public async Task<IActionResult> Encerrar(
        int id,
        EncerrarChamadoRequest request)
    {
        var chamado = await _service.BuscarPorId(id);

        if (chamado == null)
        {
            return NotFound();
        }

        await _service.Encerrar(chamado, request.Solucao);

        return Ok(chamado);
    }

    [HttpPost("{id}/interacoes")]
    public async Task<IActionResult> CriarInteracao(
    int id,
    Interacao interacao)
    {
        var novaInteracao = await _interacaoService.Criar(
            id,
            interacao
        );

        return Ok(novaInteracao);
    }
}

public class EncerrarChamadoRequest
{
    public string Solucao { get; set; } = string.Empty;
}
