using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Painel.Models
{
    public class EditarAgendamentoModel
    {
        public Agendamento Agendamentos { get; set; }

        public List<Playlist> Playlists { get; set; }

        public class Agendamento
        {
            [Required(ErrorMessage = "A frequência é obrigatória.")]
            public int Frequencia { get; set; }

            [Required(ErrorMessage = "O horário é obrigatório.")]
            public TimeSpan Horario { get; set; }

            [Required(ErrorMessage = "Shuffle é obrigatório.")]
            public string Shuffle { get; set; }

            [Required(ErrorMessage = "A ordem de início é obrigatória.")]
            public int Inicio { get; set; }

            [Required(ErrorMessage = "A finalização é obrigatória.")]
            public string Finalizacao { get; set; }

            // Usando int? para permitir null caso não haja playlist de finalização
            public int? CodigoPlaylistFinalizacao { get; set; }
        }

        public class Playlist
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
        }

        public class AgendamentoResumoViewModel
        {
            public string PlaylistNome { get; set; }
            public DateTime DataHora { get; set; }
            public string DiasSemana { get; set; }
            public string Horario { get; set; }
            public bool Comerciais { get; set; } // interpretado como "shuffle"
            public int Inicio { get; set; } // 1 = aleatória, 2 = ordem
            public string Finalizacao { get; set; } // repetir, parar, trocar_playlist
            public string PlaylistFinalizacao { get; set; } // nome da playlist final (se aplicável)
            public string Idioma { get; set; }
        }

    }
}
