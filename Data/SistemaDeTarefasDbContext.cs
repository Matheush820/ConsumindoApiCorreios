using Microsoft.EntityFrameworkCore;
using SistemadeTarefa.Data.Map;
using SistemadeTarefa.Models;

namespace SistemadeTarefa.Data;

public class SistemaDeTarefasDbContext : DbContext
{
    public SistemaDeTarefasDbContext(DbContextOptions<SistemaDeTarefasDbContext> options)
        : base(options)
    {

    }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefaMap());

        base.OnModelCreating(modelBuilder);
    }
}
