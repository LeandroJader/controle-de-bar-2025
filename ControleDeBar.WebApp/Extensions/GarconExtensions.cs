using ControleDeBar.Dominio.ModuloGarcon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Extensions;

    public static class GarconExtensions
{
    public static Garcom ParaEntidade(this FormularioGarcomViewModel formularioVM)
    {
        return new Garcom(formularioVM.Nome, formularioVM.Cpf);
    }

    public static DetalhesGarcomViewModel ParaDetalhesVM(this Garcom garson)
    {
        return new DetalhesGarcomViewModel (
                garson.Id,
                garson.Nome,
                garson.Cpf
        );

    }
}