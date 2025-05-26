namespace Painel.Models
{
    public class RenomearVideo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public int PastaId { get; set; }
        public Pasta Pasta { get; set; }  // Supondo que 'Pasta' seja outra entidade no seu modelo
    }
}
