﻿using SistemadeTarefa.Integracao.Interfaces;
using SistemadeTarefa.Integracao.Response;
using SistemadeTarefa.Integracao.Response.Refit;

namespace SistemadeTarefa.Integracao;

public class ViaCepIntegracao : IViaCepIntegracao
{
    private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;

    public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
    {
        _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
    }

    public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
    {
      var responseData = await  _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

        if(responseData != null && responseData.IsSuccessStatusCode)
        {
            return responseData.Content;
        }

        return null;
    }
}
