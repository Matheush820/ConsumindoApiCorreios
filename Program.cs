using Microsoft.EntityFrameworkCore;
using Refit;
using SistemadeTarefa.Data;
using SistemadeTarefa.Integracao;
using SistemadeTarefa.Integracao.Interfaces;
using SistemadeTarefa.Integracao.Response.Refit;
using SistemadeTarefa.Repositorios;
using SistemadeTarefa.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SistemaDeTarefasDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

builder.Services.AddRefitClient<IViaCepIntegracaoRefit>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
