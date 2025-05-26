namespace Painel.Models
{
    public class ConversorViewModel
    {
        public string NomeServidorCompleto { get; set; }
        public int BitrateMaximo { get; set; }
        public string PresetNome { get; set; }
        public int VideoBitrate { get; set; }
        public int AudioBitrate { get; set; }
        public string MensagemAlertaBitrate { get; set; }
        public string BitrateAlertaMensagem { get; set; }
    }
}
