using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemadeTarefa.Models;

namespace SistemadeTarefa.Data.Map;

public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Descricao)
            .HasMaxLength(1000);

        builder.Property(u => u.Status)
            .IsRequired();

        builder.Property(u => u.UsuarioId);

        builder.HasOne(u => u.Usuario);
           


    }
}

