using System.Text.Json.Serialization;
using System.Text.Json;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloGarcon;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Dominio.ModuloConta;

namespace ControleDeBar.Infraestrura.Arquivos.Compartilhado;

public class ContextoDados
{
    private string pastaArmazenamento = "C:\\temp";
    private string arquivoArmazenamento = "dados-controle-bar.json";

    public List<Mesa> Mesas { get; set; }
    public List<Garcom> garcons { get; set; }

    public List<Produto> produtos { get; set; }

    public List <Conta> contas { get; set; }
    public ContextoDados()
    {
        Mesas = new List<Mesa>();
        garcons = new List<Garcom>();
        produtos = new List<Produto>();
        contas = new List<Conta>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOptions);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(
            json, 
            jsonOptions
        )!;

        if (contextoArmazenado == null) return;

        Mesas = contextoArmazenado.Mesas;
        garcons = contextoArmazenado.garcons;
        produtos = contextoArmazenado.produtos;
        contas = contextoArmazenado.contas;
    }
}
