using SistemadeTarefa.Models;

namespace SistemadeTarefa.Repositorios.Interfaces;

public interface IUsuarioRepositorio
{
    Task<List<UsuarioModel>> BuscarTodosUsuarios();
    Task<UsuarioModel> BuscarUsuarioPorId(int id);
    Task<UsuarioModel> Adicionar(UsuarioModel usuario);
    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
    Task<bool> Deletar(int id);
}
