using System.ComponentModel.DataAnnotations;

namespace Painel.Models;

public class Playlist
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public string CodigoStreaming { get; set; }

    public bool Comerciais { get; set; }

    public ICollection<VideoPlaylist> Videos { get; set; } = new List<VideoPlaylist>();

    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}

public class VideoPlaylist
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public int PlaylistId { get; set; }

    public int DuracaoSegundos { get; set; }

    public Playlist Playlist { get; set; }
}

public class Agendamento
{
    [Key]
    public int Id { get; set; }

    public int PlaylistId { get; set; }

    public DateTime DataHora { get; set; }

    public Playlist Playlist { get; set; }
}

public class GerenciadorPlaylistsViewModel
{
    public string LoginCode { get; set; }

    public List<PlaylistResumoViewModel> Playlists { get; set; } = new();
}

public class PlaylistResumoViewModel
{
    public string Nome { get; set; }

    public int TotalVideos { get; set; }

    public int TotalAgendamentos { get; set; }

    public string DuracaoFormatada { get; set; }

    public bool Comerciais { get; set; }

    public string Code { get; set; }  // Código codificado
}
