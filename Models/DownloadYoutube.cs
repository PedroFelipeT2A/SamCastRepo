public class StreamingViewModel
{
    public Servidor Servidor { get; set; }
    public Streaming Streaming { get; set; }
    public string ConfiguracoesJson { get; set; }
}

public class Servidor
{
    public string Nome { get; set; }
}

public class Streaming
{
    public string Login { get; set; }
}
