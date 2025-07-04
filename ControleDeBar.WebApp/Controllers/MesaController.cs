﻿using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrura.Arquivos.ModuloMesa;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

[Route("mesas")]
public class MesaController: Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioMesa repositorioMesa;

    public MesaController()
    {
        contextoDados = new ContextoDados(true);
        repositorioMesa = new RepositorioMesaEmArquivo(contextoDados);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = repositorioMesa.SelecionarRegistros();

        var visualizarVM = new VisualizarMesasViewModel(registros);

        return View(visualizarVM);
    }


    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarMesaViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public ActionResult Cadastrar(CadastrarMesaViewModel cadastrarVM)
    {
        var entidade = cadastrarVM.ParaEntidade();

        repositorioMesa.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var registroSelecionado = repositorioMesa.SelecionarRegistroPorId(id);

        var editarVM = new EditarMesaViewModel(
            id,
            registroSelecionado.Numero,
            registroSelecionado.Capacidade
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    public ActionResult Editar(Guid id, EditarMesaViewModel editarVM)
    {
        var entidadeEditada = editarVM.ParaEntidade();

        repositorioMesa.EditarRegistro(id, entidadeEditada);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public ActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioMesa.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirMesaViewModel(registroSelecionado.Id, registroSelecionado.Numero);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public ActionResult ExcluirConfirmado(Guid id)
    {
        repositorioMesa.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public ActionResult Detalhes(Guid id)
    {
        var registroSelecionado = repositorioMesa.SelecionarRegistroPorId(id);

        var detalhesVM = new DetalhesMesaViewModel(
            id,
            registroSelecionado.Numero,
            registroSelecionado.Capacidade
        );

        return View(detalhesVM);
    }
}
