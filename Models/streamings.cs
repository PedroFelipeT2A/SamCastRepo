using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.ComponentModel.DataAnnotations;

namespace Painel.Models;

public partial class streamings
{
    [Key]
    public int codigo { get; set; }
    public int codigo_cliente { get; set; }
    public int codigo_servidor { get; set; }
    public string login { get; set; }
    public string? senha { get; set; }
    public string? senha_transmissao { get; set; }
    public string? autenticar_live { get; set; }
    public int? espectadores { get; set; }
    public int? bitrate { get; set; }
    public int? espaco { get; set; }
    public int? espaco_usado { get; set; }
    public int? ipcameras { get; set; }
    public string? ftp_dir { get; set; }
    public string? identificacao { get; set; }
    public string? email { get; set; }
    public string? timezone  { get; set; }
    public string? formato_data { get; set; }
    public string? descricao { get; set; }
    public string? idioma_painel { get; set; }
    public string? pagina_inicial{ get; set; }
    public string? exibir_atalhos{ get; set; }
    public string? player_autoplay { get; set; }
    public string? player_volume_inicial { get; set; }
    public string? permitir_alterar_senha{ get; set; }
    public DateTime? data_cadastro { get; set; }
    public string? aplicacao { get; set; }
    public string? player_titulo { get; set; }
    public string? player_descricao { get; set; }
    public string? status_gravando { get; set; }
    public string? gravador_arquivo { get; set; }
    public DateTime? gravador_data_inicio { get; set; }
    public string? exibir_app_android { get; set; }
    public int? status { get; set; }
    public string? transcoder { get; set; }
    public string? transcoder_qualidades  { get; set; }
    public string? aparencia_exibir_stats_espectadores { get; set; }
    public string? aparencia_exibir_stats_ftp { get; set; }
    public int? ultima_playlist { get; set; }
    public string? live_youtube { get; set; }
    public string? app_nome { get; set; }
    public string? app_email { get; set; }
    public string? app_whatsapp { get; set; }
    public string? app_url_logo { get; set; }
    public string? app_url_icone { get; set; }
    public string? app_url_background { get; set; }
    public string? app_url_facebook { get; set; }
    public string? app_url_instagram { get; set; }
    public string? app_url_twitter { get; set; }
    public string? app_url_site { get; set; }
    public string? app_url_chat { get; set; }
    public string? app_cor_texto { get; set; }
    public string? app_cor_menu_claro { get; set; }
    public string? app_cor_menu_escuro{ get; set; }
    public string? app_win_nome { get; set; }
    public string? app_win_email { get; set; }
    public string? app_win_whatsapp { get; set; }
    public string? app_win_url_logo { get; set; }
    public string? app_win_url_icone { get; set; }
    public string? app_win_url_background { get; set; }
    public string? app_win_url_facebook { get; set; }
    public string? app_win_url_instagram { get; set; }
    public string? app_win_url_twitter { get; set; }
    public string? app_win_url_site { get; set; }
    public string? app_win_url_chat { get; set; }
    public string? app_win_cor_texto { get; set; }
    public string? app_win_cor_menu_claro { get; set; }
    public string? app_win_cor_menu_escuro{ get; set; }
    public string? app_win_url_youtube { get; set; }
    public string? app_win_text_prog { get; set; }
    public string? app_win_text_hist { get; set; }
    public int? app_tela_inicial { get; set; }
    public string? watermark_posicao { get; set; }
    public string? geoip_ativar { get; set; }
    public string? geoip_paises_bloqueados { get; set; }
    public string? relay_status { get; set; }
    public string? relay_url { get; set; }
    public string? webrtc_chave { get; set; }
    public string? srt_status { get; set; }
    public int? srt_porta { get; set; }
    public string? app_certificado { get; set; }

}
