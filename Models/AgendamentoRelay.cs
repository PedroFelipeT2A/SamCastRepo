using Microsoft.AspNetCore.Mvc;

namespace Painel.Models
{
    public class AgendamentoRelay : Controller
    {
        // Models/RelayAgendamento.cs
        public class RelayAgendamento
        {
            public int Codigo { get; set; }
            public int CodigoStm { get; set; }
            public string ServidorRelay { get; set; }
            public int Frequencia { get; set; }
            public DateTime Data { get; set; }
            public string Hora { get; set; }
            public string Minuto { get; set; }
            public string Dias { get; set; }
            public int Status { get; set; }
            public string Duracao { get; set; }
            public DateTime LogDataInicio { get; set; }
        }
        public class AgendamentoRelayViewModel
        {
            public string ServidorRelay { get; set; }
            public DateTime Data { get; set; }
            public string Hora { get; set; }
            public string Minuto { get; set; }
            public string Dias { get; set; }
            public string Duracao { get; set; }
            public int Status { get; set; } // 0 para Inativo, 1 para Ativo
        }
    }
}
