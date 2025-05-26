using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Painel.Data;
using Painel.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using static Painel.Models.AgendamentoRelay;

namespace Painel.Controllers
{
    [Authorize(AuthenticationSchemes = "auth")]
    public class HomeController : WShare
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ctxContext _context;

        public HomeController(ctxContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult PlayersM3u8()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult PlayersVideoAds()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult PlayersVideoChat()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult PlayersAndroid()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult PlayersLinkCelulares()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult PlayersHTML5()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult Players()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult Configuracoes()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }

        public IActionResult DadosConexao()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            return View();
        }
        public IActionResult GerenciadorVideos()
        {
            // Dados simulados para teste
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
            new Video { Id = 2, Nome = "Video 2", PastaId = 2, Caminho = "/videos/video2.mp4" },
            new Video { Id = 3, Nome = "Video 3", PastaId = 1, Caminho = "/videos/video3.mp4" }
        },
                Mensagem = "Testando interface",
                EspacoUsado = "10 GB",
                EspacoTotal = "50 GB"
            };

            return View(viewModel);
        }

        public IActionResult GerenciarLives()
        {
            var viewModel = new List<LiveResumoViewModel>
    {
        new LiveResumoViewModel
        {
            Nome = "Live de Teste 1",
            DataHora = DateTime.Now.AddHours(2), // Exemplo de live futura
            DuracaoFormatada = FormatDuracao(7200), // 2 horas
            Status = true,
            Code = "LIV123"
        },
        new LiveResumoViewModel
        {
            Nome = "Live de Teste 2",
            DataHora = DateTime.Now.AddHours(1), // Exemplo de live futura
            DuracaoFormatada = FormatDuracao(3600), // 1 hora
            Status = false,
            Code = "LIV456"
        }
    };

            // Verifique no console ou log se viewModel está correto
            Console.WriteLine("Número de lives: " + viewModel.Count);

            return View(viewModel);
        }

        public IActionResult Playlist()
        {
            var playlists = new List<PlaylistResumoViewModel>
    {
        new PlaylistResumoViewModel
        {
            Nome = "Playlist de Teste",
            TotalVideos = 5,
            TotalAgendamentos = 2,
            Comerciais = true,
            Code = "ABC123",
            DuracaoFormatada = FormatDuracao(620)
        },
        new PlaylistResumoViewModel
        {
            Nome = "Sem Comerciais",
            TotalVideos = 3,
            TotalAgendamentos = 1,
            Comerciais = false,
            Code = "XYZ789",
            DuracaoFormatada = FormatDuracao(240)
        }
    };

            var viewModel = new GerenciadorPlaylistsViewModel
            {
                LoginCode = "user123",
                Playlists = playlists
            };

            return View(viewModel);
        }

        // Deixe esse método como static pra evitar o erro do EF
        public static string FormatDuracao(int totalSegundos)
        {
            TimeSpan duracao = TimeSpan.FromSeconds(totalSegundos);
            return duracao.ToString(@"hh\:mm\:ss");
        }

        public async Task<IActionResult> Relay()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            // Obtém as informações do streaming
            var streaming = await _context.streamings.FirstOrDefaultAsync(x => x.login == NomeUsuario);

            // Cria o viewModel com os dados necessários
            var viewModel = new RelayConfigViewModel
            {
                RelayStatus = streaming.relay_status,
                RelayUrl = streaming.relay_url,
                Login = streaming.login
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("idusuario") == null) { return Redirect("/Revendas/Login"); }

            revendas revenda = await _context.revendas.FirstOrDefaultAsync(x => x.codigo == IdUsuario);
            configuracoes configuracao = _context.configuracoes.First();
            streamings streaming = await _context.streamings.FirstOrDefaultAsync(x => x.login == NomeUsuario);
            servidores servidor = await _context.servidores.FirstOrDefaultAsync(x => x.codigo == streaming.codigo_servidor);

            SetRevenda(revenda);
            SetConfiguracao(configuracao);
            SetStreaming(streaming);
            SetServidor(servidor);

            return View(revenda);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GerenciarAgendamentos()
        {
            if (HttpContext.Session.GetString("idusuario") == null)
                return Redirect("/Revendas/Login");

            var viewModel = new List<EditarAgendamentoModel.AgendamentoResumoViewModel>
    {
        new EditarAgendamentoModel.AgendamentoResumoViewModel
        {
            PlaylistNome = "Playlist Manhã",
            DataHora = DateTime.Today.AddHours(8),
            DiasSemana = "Seg, Qua, Sex",
            Horario = "08:00",
            Comerciais = true,
            Idioma = "pt-br"
        },
        new EditarAgendamentoModel.AgendamentoResumoViewModel
        {
            PlaylistNome = "Playlist Noite",
            DataHora = DateTime.Today.AddHours(20),
            DiasSemana = "Todos os dias",
            Horario = "20:00",
            Comerciais = false,
            Idioma = "pt-br"
        }
    };

            return View(viewModel);
        }

        public IActionResult GerenciarComerciais()
        {
            if (HttpContext.Session.GetString("idusuario") == null)
                return Redirect("/Revendas/Login");

            // Exemplo de dados simulados para os comerciais
            var viewModel = new ComercialViewModel
            {
                PlaylistSelecionada = "Playlist Teste",
                PastaComerciais = "/comerciais/pasta1",
                Comerciais = new List<Comercial>
            {
                new Comercial { Nome = "Comercial 1", Bitrate = "128kbps", Duração = "30s", Thumbnail = "/images/thumb1.jpg" },
                new Comercial { Nome = "Comercial 2", Bitrate = "256kbps", Duração = "45s", Thumbnail = "/images/thumb2.jpg" },
                new Comercial { Nome = "Comercial 3", Bitrate = "512kbps", Duração = "60s", Thumbnail = "/images/thumb3.jpg" }
            }
            };

            return View(viewModel);
        }

        public IActionResult RenomearVideo(int id)
        {
            // Dados simulados para visualização
            var video = new Video
            {
                Id = id,
                Nome = "Video Exemplo",
                Caminho = "/videos/videoexemplo.mp4"
            };

            // Retornar a view com o vídeo para edição
            return View(video);
        }

        // Ação POST para salvar a alteração do nome do vídeo (simulação)
        [HttpPost]
        public IActionResult RenomearVideo(int id, string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
            {
                ModelState.AddModelError("", "O nome do vídeo não pode ser vazio.");
                return View();
            }

            var videoAtualizado = new Video
            {
                Id = id,
                Nome = novoNome,
                Caminho = "/videos/videoexemplo.mp4"
            };

            return RedirectToAction("GerenciadorVideos");
        }

        public IActionResult MigrarVideos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MigrarVideos(MigracaoFtpModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["StatusAcao"] = "Migração de vídeos realizada com sucesso!";
                return RedirectToAction("GerenciarVideos", "Home");
            }
            else
            {
                TempData["StatusAcao"] = "Erro na migração, verifique os dados fornecidos.";
                return View();
            }
        }

        public IActionResult DownloadYoutube()
        {
            if (HttpContext.Session.GetString("idusuario") == null)
                return Redirect("/Revendas/Login");

            // Dados simulados para exibição
            var viewModel = new StreamingViewModel
            {
                Servidor = new Servidor { Nome = "Servidor Alpha" },
                Streaming = new Streaming { Login = "usuario_streaming" },
                ConfiguracoesJson = @"{
                 ""resolucao"": ""1080p"",
                 ""bitrate"": ""4500kbps"",
                 ""frameRate"": ""30fps"",
                 ""protecao"": true
                }"
            };

            return View(viewModel);
        }

        public IActionResult LogoPlayer()
        {
            if (HttpContext.Session.GetString("idusuario") == null)
                return Redirect("/Revendas/Login");

            // Dados simulados para exibição
            var viewModel = new WatermarkViewModel
            {
                WatermarkSelecionada = "logo_watermark.png",  // A marca d'água selecionada
                Watermarks = new List<Watermark>
                {
                    new Watermark
                    {
                        Id = 1,
                        Nome = "Marca d'água 1",
                        Caminho = "/images/logo_watermark.png",
                        Posicao = "Top Left",
                        IsAtivo = true
                    },
                    new Watermark
                    {
                        Id = 2,
                        Nome = "Marca d'água 2",
                        Caminho = "/images/logo_watermark.png",
                        Posicao = "Top Right",
                        IsAtivo = false
                    },
                    new Watermark
                    {
                        Id = 3,
                        Nome = "Marca d'água 3",
                        Caminho = "/images/logo_watermark.png",
                        Posicao = "Bottom Left",
                        IsAtivo = true
                    }
                },
                Mensagem = "Configurações de Marca d'Água carregadas com sucesso!",
                EspacoUsado = "15 MB",
                EspacoTotal = "50 MB"
            };

            return View(viewModel);
        }

        public IActionResult AgendamentoRelay()
        {
            if (HttpContext.Session.GetString("idusuario") == null)
                return Redirect("/Revendas/Login");

            // Dados simulados para exibição
            var viewModel = new List<AgendamentoRelayViewModel>
        {
            new AgendamentoRelayViewModel
            {
                ServidorRelay = "Servidor 1",
                Data = new DateTime(2025, 5, 15),
                Hora = "10",
                Minuto = "30",
                Dias = "Segunda, Quarta, Sexta",
                Duracao = "1 hora",
                Status = 1
            },
            new AgendamentoRelayViewModel
            {
                ServidorRelay = "Servidor 2",
                Data = new DateTime(2025, 5, 16),
                Hora = "14",
                Minuto = "00",
                Dias = "Terça, Quinta",
                Duracao = "45 minutos",
                Status = 0
            },
            new AgendamentoRelayViewModel
            {
                ServidorRelay = "Servidor 3",
                Data = new DateTime(2025, 5, 17),
                Hora = "08",
                Minuto = "15",
                Dias = "Segunda a Sexta",
                Duracao = "30 minutos",
                Status = 1
            }
        };

            return View(viewModel);
        }

        public IActionResult Conversor()
        {
            if (HttpContext.Session.GetString("idusuario") == null)
                return Redirect("/Revendas/Login");

            var viewModel = new ConversorViewModel
            {
                BitrateMaximo = 1000,
                BitrateAlertaMensagem = "O bitrate máximo permitido foi excedido."
            };

            return View(viewModel); // ? Correto: está passando um único objeto
        }
    }
}
