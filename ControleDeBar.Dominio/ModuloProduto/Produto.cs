using ControleDeBar.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco )
        {
            Nome = nome;
            Preco = preco;
        }

        public override void AtualizarRegistro(Produto registroEditado)
        {
            Nome = registroEditado.Nome;
            Preco = registroEditado.Preco;
        }
    }
}
