using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol.Plugins;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Painel.Models;

public partial class espectadores_conectados
{
    [Key]
    public int codigo { get;set;}
    public int codigo_stm  { get;set;}
    public string? ip  { get;set;}
    public string? tempo_conectado  { get;set;}
    public string? pais_sigla  { get;set;}
    public string? pais_nome  { get;set;}
    public string? cidade  { get;set;}
    public string? estado  { get;set;}
    public string? player  { get;set;}
    public string? latitude  { get;set;}
    public string? longitude { get;set;}
    public DateTime? atualizacao { get;set;}    

}
