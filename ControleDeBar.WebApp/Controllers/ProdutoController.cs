using ControleDeBar.Dominio.ModuloGarcon;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloProduto;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using static ControleDeBar.WebApp.Models.CadastrarProdutoViewModel;

namespace ControleDeBar.WebApp.Controllers
{
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly ContextoDados contextoDados;
        private readonly IrepositorioProduto repositorioProduto;
        public ProdutoController()
        {
            contextoDados = new ContextoDados(true);
            repositorioProduto = new RepositorioProdutoEmArquivo(contextoDados);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var registros = repositorioProduto.SelecionarRegistros();

            var visualizarVm = new VisualizarProdutoViewModel(registros);

            return View(visualizarVm);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarvm = new CadastrarProdutoViewModel();

            return View(cadastrarvm);
        }

        [HttpPost("cadastrar")]

        public IActionResult Cadastrar(CadastrarProdutoViewModel cadastrarvm)
        {
            var entidade = cadastrarvm.ParaEntidade();
            repositorioProduto.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]

        public IActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorioProduto.SelecionarRegistroPorId(id);

            var editarVm = new EditarProdutoViewModel(id, registroSelecionado.Nome,registroSelecionado.Preco);
            
            return View(editarVm);
        }
        [HttpPost("editar/{id:guid}")]

        public IActionResult Editar(Guid id, EditarProdutoViewModel editarvm)
        {
            var entidadeEditada = editarvm.ParaEntidade();
            repositorioProduto.EditarRegistro(id, entidadeEditada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var registroSelecionado = repositorioProduto.SelecionarRegistroPorId(id);

            var excluirVM = new ExcluirProdutoViewModel(registroSelecionado.Id, registroSelecionado.Nome);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public ActionResult ExcluirConfirmado(Guid id)
        {
            repositorioProduto.ExcluirRegistro(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:guid}")]
        public ActionResult Detalhes(Guid id)
        {
            var registroSelecionado = repositorioProduto.SelecionarRegistroPorId(id);

            var detalhesVM = new detalhesProdutoViewModel(
                id,
                registroSelecionado.Nome,
                registroSelecionado.Preco
            );

            return View(detalhesVM);
        }
    }


}

