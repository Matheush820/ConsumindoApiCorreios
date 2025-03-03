using SistemadeTarefa.Models;

namespace SistemadeTarefa.Repositorios.Interfaces;

public interface ITarefaRepositorio
{
    Task<List<TarefaModel>> BuscarTodasTarefas();
    Task<TarefaModel> BuscarTarefaPorId(int id);
    Task<TarefaModel> AdicionarTarefa(TarefaModel usuario);
    Task<TarefaModel> AtualizarTarefa(TarefaModel usuario, int id);
    Task<bool> Deletar(int id);
}
