using Microsoft.AspNetCore.Mvc;
using Painel.Models;

public class GerenciadorController : Controller
{
    // Este método irá simular dados para a visualização
    public IActionResult GerenciadorVideos()
    {
        // Criar dados simulados para teste
        var viewModel = new GerenciadorViewModel
        {
            Pastas = new List<Pasta>
            {
                new Pasta { Id = 1, Nome = "Pasta 1", UsuarioLogin = "user1" },
                new Pasta { Id = 2, Nome = "Pasta 2", UsuarioLogin = "user2" }
            },
            Videos = new List<Video>
            {
                new Video { Id = 1, Nome = "Video 1", PastaId = 1, Caminho = "/videos/video1.mp4" },
                new Video { Id = 2, Nome = "Video 2", PastaId = 2, Caminho = "/videos/video2.mp4" }
            },
            PastaSelecionada = "Pasta 1",  // Pasta selecionada inicial
            Mensagem = "Testando interface",
            EspacoUsado = "10 GB",
            EspacoTotal = "50 GB"
        };

        return View(viewModel);
    }
}
