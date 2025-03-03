using SistemadeTarefa.Integracao.Response;

namespace SistemadeTarefa.Integracao.Interfaces;

public interface IViaCepIntegracao
{
    Task<ViaCepResponse> ObterDadosViaCep(string cep);
}
