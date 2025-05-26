using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Painel.Data;
using Painel.Lib;
using Painel.Models;
using Email = Painel.Lib.Email;

namespace Painel.Controllers
{
    [Authorize(AuthenticationSchemes = "auth")]
    public class EspectadoresConectadosController : WShare
    {
        private readonly ctxContext _context;

        public EspectadoresConectadosController(ctxContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<espectadores_conectados> listEspectadoresConectados = await _context.espectadores_conectados.ToListAsync();
                return View(listEspectadoresConectados);
            }
            catch (Exception e)
            {
                return Redirect("/");
            }
            
        }
    }
}
