using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeTarefa.Integracao.Interfaces;
using SistemadeTarefa.Integracao.Response;

namespace SistemadeTarefa.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase
{
    private readonly IViaCepIntegracao _viaCepIntegracao;

    public CepController(IViaCepIntegracao viaCepIntegracao)
    {
        _viaCepIntegracao = viaCepIntegracao;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereço(string cep)
    {
        var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if(responseData == null)
            {
            return BadRequest("CEP nao encontrado");
            }

            return Ok(responseData);
    }
}
