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
    public class EstatisticasController : WShare
    {
        private readonly ctxContext _context;

        public EstatisticasController(ctxContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
            //try
            //{
            //    List<estatisticas> listEstatisticas = await _context.estatisticas.ToListAsync();
            //    return View(listEstatisticas);
            //}
            //catch (Exception e)
            //{
            //    return Redirect("/");
            //}
            
        }
    }
}
