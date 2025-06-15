using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Models
{
    public abstract class FormularioProdutoViewModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    public class CadastrarProdutoViewModel : FormularioProdutoViewModel
    {
        public CadastrarProdutoViewModel() { }

        public CadastrarProdutoViewModel(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
        public class EditarProdutoViewModel : FormularioProdutoViewModel
        {
            public Guid Id { get; set; }

            public EditarProdutoViewModel()
            {
                
            }
            public EditarProdutoViewModel(Guid id, string nome, decimal preco)
            {
                Id = id;
                Nome = nome;
                Preco = preco;
            }
        }
        public class VisualizarProdutoViewModel
        {
            public List<detalhesProdutoViewModel> registros { get; set; }

            public VisualizarProdutoViewModel(List<Produto> produtos)
            {
                registros = [];

                foreach (var p in produtos)
                {
                    var DetalhesVm = p.ParaDetalhesVm();
                    registros.Add(DetalhesVm);
                }
            }
        }

        public class detalhesProdutoViewModel
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }

            public detalhesProdutoViewModel(Guid id, string nome, decimal preco)
            {
                Id = id;
                Nome = nome;
                Preco = preco;
            }
        }
        public class ExcluirProdutoViewModel
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }

            public ExcluirProdutoViewModel() { }

            public ExcluirProdutoViewModel(Guid id, string nome) : this()
            {
                Id = id;
                Nome = nome;
            }
        }
    }
