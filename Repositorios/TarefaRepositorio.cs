using Microsoft.EntityFrameworkCore;
using SistemadeTarefa.Data;
using SistemadeTarefa.Models;
using SistemadeTarefa.Repositorios.Interfaces;

namespace SistemadeTarefa.Repositorios;

public class TarefaRepositorio : ITarefaRepositorio
{
    private readonly SistemaDeTarefasDbContext _dbContext;
    public TarefaRepositorio(SistemaDeTarefasDbContext sistemaDeTarefasDbContext)
    {
        _dbContext = sistemaDeTarefasDbContext;
    }

    public async Task<TarefaModel> BuscarTarefaPorId(int id)
    {
        return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<TarefaModel>> BuscarTodasTarefas()
    {
        return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .ToListAsync();

    }

    public async Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();

        return tarefa;
    }

    public async Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id)
    {
        TarefaModel tarefaPorId = await BuscarTarefaPorId(id);

        if (tarefaPorId == null)
        {
            throw new Exception($"Tarefa não encontrada, ID: {id}");
        }

        tarefaPorId.Nome = tarefa.Nome;
        tarefaPorId.Descricao = tarefa.Descricao;
        tarefa.Status = tarefa.Status;
        tarefaPorId.UsuarioId = tarefa.UsuarioId;

        _dbContext.Tarefas.Update(tarefaPorId);
        await _dbContext.SaveChangesAsync();

        return tarefaPorId;
    }


    public async Task<bool> Deletar(int id)
    {
        TarefaModel tarefaPorId = await BuscarTarefaPorId(id);

        if (tarefaPorId == null)
        {
            throw new Exception($"Não foi possivel encontrar Tarefa com ID: {id} para exclusão");
        }

        _dbContext.Tarefas.Remove(tarefaPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
