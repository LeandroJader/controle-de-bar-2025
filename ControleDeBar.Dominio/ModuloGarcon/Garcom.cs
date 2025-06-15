using ControleDeBar.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Dominio.ModuloGarcon
{
    public class Garcom : EntidadeBase<Garcom>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }


        public override void AtualizarRegistro(Garcom registroEditado)
        {
            Nome = registroEditado.Nome;
            Cpf = registroEditado.Cpf;
        }
    }
}
