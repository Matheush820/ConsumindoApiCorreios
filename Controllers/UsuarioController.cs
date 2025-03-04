﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeTarefa.Models;
using SistemadeTarefa.Repositorios.Interfaces;

namespace SistemadeTarefa.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    [HttpGet]
    public async Task <ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
    {
        List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
    {
        UsuarioModel usuarios = await _usuarioRepositorio.BuscarUsuarioPorId(id);
        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
    {
        UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
    {
        usuarioModel.Id = id;
        UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UsuarioModel>> Apagar(int id)
    {
        bool apagado = await _usuarioRepositorio.Deletar(id);
        return Ok(apagado);
    }
}
