using System.ComponentModel.DataAnnotations;

namespace Painel.Models;

public class Pasta
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public string? UsuarioLogin { get; set; }

    public ICollection<Video> Videos { get; set; } = new List<Video>();
}


public class Video
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public int PastaId { get; set; }

    public string? Caminho { get; set; }

    // Relacionamento com a Pasta
    public Pasta Pasta { get; set; }  // Um vídeo pertence a uma única pasta
}


public class GerenciadorViewModel
{
    public string PastaSelecionada { get; set; }  // Deve ser string
    public List<Pasta> Pastas { get; set; }
    public List<Video> Videos { get; set; }
    public string Mensagem { get; set; }
    public string EspacoUsado { get; set; }
    public string EspacoTotal { get; set; }
}
