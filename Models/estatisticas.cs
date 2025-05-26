using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Painel.Models;

public partial class estatisticas
{
    [Key]
    public int codigo {get; set; }
    public int codigo_stm {get; set; }
    public string? data {get; set; }
    public string? hora {get; set; }
    public string? ip {get; set; }
    public string? pais {get; set; }
    public int tempo_conectado {get; set; }
    public string? player {get; set; }
    public string? cidade {get; set; }
    public string? estado { get; set; }
    
}
