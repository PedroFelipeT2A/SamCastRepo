using Microsoft.AspNetCore.Mvc;
using Painel.Models;
using Painel.Services;
using System;
using System.Threading.Tasks;

namespace Painel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPlaylists()
        {
            try
            {
                var playlists = await _playlistService.GetPlaylistsAsync();
                return Ok(new { success = true, data = playlists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Erro ao buscar playlists: {ex.Message}" });
            }
        }

        [HttpPost("create")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreatePlaylist([FromBody] PlaylistCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Dados inválidos", errors = ModelState });
            }

            try
            {
                var result = await _playlistService.CreatePlaylistAsync(request);

                if (result.Success)
                {
                    return Ok(new { success = true, data = result });
                }

                return BadRequest(new { success = false, message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Erro ao criar playlist: {ex.Message}" });
            }
        }
    }
}