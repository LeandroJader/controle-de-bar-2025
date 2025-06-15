using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WebApp.Models;
using static ControleDeBar.WebApp.Models.CadastrarProdutoViewModel;

namespace ControleDeBar.WebApp.Extensions
{
    public static class ProdutoExtensions
    {
        public static Produto ParaEntidade (this FormularioProdutoViewModel formularioVm)
        {
            return new Produto(formularioVm.Nome, formularioVm.Preco);
        }

        public static detalhesProdutoViewModel ParaDetalhesVm(this Produto produto)
        {
            return new detalhesProdutoViewModel(produto.Id, produto.Nome, produto.Preco);
        }
    }
}
