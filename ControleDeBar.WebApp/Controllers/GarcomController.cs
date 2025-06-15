using ControleDeBar.Dominio.ModuloGarcon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrura.Arquivos.ModuloMesa;
using ControleDeBar.Infraestrutura.Arquivos;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

[Route("garcons")]
public class GarcomController : Controller
{
    private readonly ContextoDados contextoDados;
    private readonly IRepositorioGarcom repositoriogarcon;

    public GarcomController()
    {
        contextoDados = new ContextoDados(true);
        repositoriogarcon = new RepositorioGarcomEmArquivo(contextoDados);       
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = repositoriogarcon.SelecionarRegistros();

        var visualizarVM = new VisualizarGarcomViewModel(registros);

        return View(visualizarVM);
    }


    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarGarcomViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public ActionResult Cadastrar(CadastrarGarcomViewModel cadastrarVM)
    {
        var entidade = cadastrarVM.ParaEntidade();

        repositoriogarcon.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var registroSelecionado = repositoriogarcon.SelecionarRegistroPorId(id);

        var editarVM = new EditarGarcomViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Cpf
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    public ActionResult Editar(Guid id, EditarGarcomViewModel editarVM)
    {
        var entidadeEditada = editarVM.ParaEntidade();

        repositoriogarcon.EditarRegistro(id, entidadeEditada);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public ActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositoriogarcon.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirGarcomViewModel(registroSelecionado.Id, registroSelecionado.Nome);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public ActionResult ExcluirConfirmado(Guid id)
    {
        repositoriogarcon.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public ActionResult Detalhes(Guid id)
    {
        var registroSelecionado = repositoriogarcon.SelecionarRegistroPorId(id);

        var detalhesVM = new  DetalhesGarcomViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Cpf
        );

        return View(detalhesVM);
    }
}
