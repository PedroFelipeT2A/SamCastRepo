using System;
using System.Collections.Generic;

namespace Painel.Models;

public partial class revendas
{
    public int codigo { get; set; }
    public int codigo_revenda { get; set; }
    public string id { get; set; } = null!;
    public string nome { get; set; } = null!;
    public string email { get; set; } = null!;
    public string senha { get; set; } = null!;
    public int streamings { get; set; }
    public int espectadores { get; set; }
    public int bitrate { get; set; }
    public int espaco { get; set; }
    public int subrevendas { get; set; }
    public string chave_api { get; set; } = null!;
    public int status { get; set; }
    public string? url_suporte { get; set; }
    public DateTime data_cadastro { get; set; }
    public string dominio_padrao { get; set; } = null!;
    public string stm_exibir_tutoriais { get; set; } = null!;
    public string url_tutoriais { get; set; } = null!;
    public string stm_exibir_downloads { get; set; } = null!;
    public string stm_exibir_mini_site { get; set; } = null!;
    public string stm_exibir_app_android_painel { get; set; } = null!;
    public string idioma_painel { get; set; } = null!;
    public int tipo { get; set; }
    public DateTime ultimo_acesso_data { get; set; }
    public string ultimo_acesso_ip { get; set; } = null!;
    public string stm_exibir_app_android { get; set; } = null!;
    public string srt_status { get; set; } = null!;
    public string? api_token { get; set; }
    public string? refresh_token { get; set; }
}
