using System.ComponentModel.DataAnnotations;

namespace Painel.Models;

public partial class configuracoes
{
    [Key]
    public int codigo { get; set; }
    public string? dominio_padrao { get; set; }
    public int? codigo_servidor_atual { get; set; }
    public string? manutencao { get; set; }    
}
