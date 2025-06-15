using ControleDeBar.Dominio.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Dominio.ModuloConta
{
  public class Pedido
    {
        public Guid Id { get; set; }

        public Produto Produto { get; set; }
        public int QuantidadeSolicitada { get; set; }
    public Pedido() { }

        public Pedido(Produto produto, int quantidadeEscolhida) : this()
        {
            Id = Guid.NewGuid();
            Produto = produto;
            QuantidadeSolicitada = quantidadeEscolhida;
        }
        public decimal CalcularTotaParcial()
        {
            return Produto.Preco * QuantidadeSolicitada;
        }
    }
}
