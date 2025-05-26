using System;
using System.ComponentModel.DataAnnotations;

namespace Painel.Models
{
    public class Live
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        public int CodigoStm { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string ServidorStm { get; set; }

        [Required]
        public string ServidorLive { get; set; }

        public int Status { get; set; } // 0: Inativo, 1: Ativo, 2: Agendado, 3: Erro
    }

    // ViewModel para exibição das Lives
    public class GerenciadorLivesViewModel
    {
        public string LoginCode { get; set; }

        public List<LiveResumoViewModel> Lives { get; set; } = new();
    }

    public class LiveResumoViewModel
    {
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
        public string DuracaoFormatada { get; set; }
        public bool Status { get; set; }
        public string Code { get; set; }
        public string Tipo { get; set; }
    }

    public class LiveFormViewModel
    {
        [Required]
        public string ServidorRtmp { get; set; }

        [Required]
        public string ServidorRtmpChave { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataFim { get; set; }

        [Required]
        public string Tipo { get; set; }

        public bool InicioImediato { get; set; }
    }

}
