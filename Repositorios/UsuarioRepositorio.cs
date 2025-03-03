using Microsoft.EntityFrameworkCore;
using SistemadeTarefa.Data;
using SistemadeTarefa.Models;
using SistemadeTarefa.Repositorios.Interfaces;

namespace SistemadeTarefa.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly SistemaDeTarefasDbContext _dbContext;
    public UsuarioRepositorio(SistemaDeTarefasDbContext sistemaDeTarefasDbContext)
    {
        _dbContext = sistemaDeTarefasDbContext;
    }

    public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await _dbContext.Usuarios.ToListAsync();

    }

    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioPorId = await BuscarUsuarioPorId(id);

        if (usuarioPorId == null)
        {
            throw new Exception($"Usuario não encontrado, ID: {id}");
        }

        usuarioPorId.Nome = usuario.Nome;
        usuarioPorId.Email = usuario.Email;

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;
    }


    public async Task<bool> Deletar(int id)
    {
        UsuarioModel usuarioPorId = await BuscarUsuarioPorId(id);

        if (usuarioPorId == null)
        {
            throw new Exception($"Não foi possivel encontrar Usuario com ID: {id} para exclusão");
        }

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
