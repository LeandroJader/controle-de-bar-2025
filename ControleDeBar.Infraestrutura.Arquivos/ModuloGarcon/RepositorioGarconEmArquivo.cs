using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Infraestrutura.Arquivos
{
    public class RepositorioGarconEmArquivo : RepositorioBaseEmArquivo<Garcom>, IRepositorioGarcon
    {
        public RepositorioGarconEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Garcom> ObterRegistros()
        {
            return contexto.garcons;
        }
    }
}
