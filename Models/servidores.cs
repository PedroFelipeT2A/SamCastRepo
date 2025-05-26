using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol.Plugins;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Painel.Models;

public partial class servidores
{
    [Key]
    public int codigo { get; set; }
    public string? nome { get; set; }
    public string? ip { get; set; }
    public string? senha { get; set; }
    public int? porta_ssh { get; set; }
    public string? status { get; set; }
    public int? limite_streamings { get; set; }
    public decimal? load { get; set; }
    public string? trafego { get; set; }
    public string? trafego_out { get; set; }
    public int? ordem { get; set; }
    public string? mensagem_manutencao { get; set; }
    public string? grafico_trafego { get; set; }
    public string? exibir { get; set; }
    public string? path_home { get; set; }
    public int? instalacao_status { get; set; }
    public int? porta_ssh_atual { get; set; }
    public int? instalacao_porta_ssh_atual { get; set; }
    public string? tipo { get; set; }
    public int? instalacao_porta_ssh { get; set; }
    public string? nome_principal { get; set; }
}
