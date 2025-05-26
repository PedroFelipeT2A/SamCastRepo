namespace Painel.Models
{
    public class RelayConfigViewModel
    {
        public string RelayStatus { get; set; } = "nao"; // "sim" ou "nao"
        public string RelayUrl { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty; // Identificador do usuário/logado
        public string StatusMensagem { get; set; } = string.Empty; // Mensagem para feedback (opcional)
    }
}
