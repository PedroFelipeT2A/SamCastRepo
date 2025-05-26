using System.Collections.Generic;

namespace Painel.Models
{
    public class WatermarkViewModel
    {
        public string WatermarkSelecionada { get; set; }
        public List<Watermark> Watermarks { get; set; }
        public string Mensagem { get; set; }
        public string EspacoUsado { get; set; }
        public string EspacoTotal { get; set; }
        public bool RemoverWatermark { get; set; }
        public bool Posicao { get; set; }
    }

    public class Watermark
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Posicao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
