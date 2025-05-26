namespace Painel.Models
{
    public class ComercialViewModel
    {
        public string PlaylistSelecionada { get; set; }
        public string PastaComerciais { get; set; }
        public List<Comercial> Comerciais { get; set; }
    }

    public class Comercial
    {
        public string Nome { get; set; }
        public string Bitrate { get; set; }
        public string Duração { get; set; }
        public string Thumbnail { get; set; }
    }
}
