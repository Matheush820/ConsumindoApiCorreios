using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeTarefa.Models;
using SistemadeTarefa.Repositorios.Interfaces;

namespace SistemadeTarefa.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly ITarefaRepositorio _tarefaRepositorio;

    public TarefaController(ITarefaRepositorio tarefaRepositorio)
    {
        _tarefaRepositorio = tarefaRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
    {
        List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaModel>> BuscarTarefaPorId(int id)
    {
        TarefaModel tarefa = await _tarefaRepositorio.BuscarTarefaPorId(id);
        return Ok(tarefa);
    }


    [HttpPost]
    public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefa)
    {
        TarefaModel tarefaSalva = await _tarefaRepositorio.AdicionarTarefa(tarefa);

        return Ok(tarefaSalva);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaModel>> AtualizarTarefa([FromBody] TarefaModel tarefa, int id)
    {
        tarefa.Id = id;

        TarefaModel tarefaAtualizada = await _tarefaRepositorio.AtualizarTarefa(tarefa, id);

        return Ok(tarefaAtualizada);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<TarefaModel>> Apagar(int id)
    {
        bool apagado = await _tarefaRepositorio.Deletar(id);
        return Ok(apagado);
    }
}
