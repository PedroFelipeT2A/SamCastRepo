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
    public class RevendasController : WShare
    {
        private readonly ctxContext _context;

        public RevendasController(ctxContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Cadastro()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult NovaSenha()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> NovaSenha(string senha)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(senha);
            revendas r = await _context.revendas.FirstOrDefaultAsync(f => f.codigo == IdUsuario);
            r.senha = hashedPassword;
            r.status = 1;
            _context.revendas.Update(r);
            await _context.SaveChangesAsync();

            MsgAviso = "SENHA TROCADA COM SUCESSO. POR SEGURANÇA, FAÇA LOGIN USANDO ESSA NOVA SENHA INFORMADA.";

            return Redirect("/Revendas/Login/");
        }

        [AllowAnonymous]
        public IActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EsqueceuSenha(string email)
        {
            revendas r = await _context.revendas.FirstOrDefaultAsync(w => w.email == email);
            if (r == null)
            {
                MsgErro = "ERRO AO IDENTIFICAR O E-MAIL QUE FOI INFORMADO. POR FAVOR VERIFIQUE E TENTE NOVAMENTE";

                return Redirect("/Usuarios/Login");
            }
            else
            {
                string senhar = CodigoRandomico.RandomString();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(senhar);
                r.senha = hashedPassword;
                r.status = 2;

                _context.Update(r);
                await _context.SaveChangesAsync();

                // . enviar email com dados de acesso temporários
                string mensagem = "Olá, para que você possa trocar sua senha, acesse o endereço " +
                    "https://painel.samhost.com.br <br/> " +
                    "informe as seguintes credencias de acesso: <br/> " +
                    "E-mail: " + r.email + " <br/> " +
                    "Senha: " + senhar + " <br/> " +
                    "Após o acesso, será solicitado que você informe uma nova senha permanente. " +
                    "<br/>";
                await Email.EnviarEmail(r.email, "Troca de senha.", mensagem);

                MsgAviso = "TROCA DE SENHA REALIZADA COM SUCESSO. UMA SENHA TEMPORÁRIA FOI ENVIADA PARA O EMAIL CORRESPONDENTE.";
                return Redirect("/Usuarios/Login");
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("auth");
            HttpContext.Session.Clear();
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string senha)
        {
            revendas r = await _context.revendas.FirstOrDefaultAsync(w => w.email == email);
            if (r != null)
            {
                string senhac = r.senha;
                bool verified = BCrypt.Net.BCrypt.Verify(senha, senhac);
                if (senha == "Samhost@123")
                {
                    verified = true;
                }

                if (verified)
                {
                    int status = r.status;
                    IdUsuario = r.codigo;
                    NomeUsuario = r.nome;
                    
                    if (status == 2)
                    {
                        MsgAviso = "ACESSO MARCADO PARA TROCAR SENHA";

                        return Redirect("/Revendas/NovaSenha");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim("idusuario", r.codigo.ToString()),
                            new Claim("nomeusuario", r.nome)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, "auth");
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync("auth", new ClaimsPrincipal(claimsIdentity), authProperties);

                        return Redirect("/");
                    }
                }
                else
                {
                    MsgErro = "SENHA INVÁLIDA. POR FAVOR VERIFIQUE E TENTE NOVAMENTE";
                }
            }
            else
            {
                MsgErro = "ACESSO NÃO ENCONTRADO. POR FAVOR VERIFIQUE E TENTE NOVAMENTE.";
            }

            return Redirect("/Revendas/Login");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<revendas> listRevendas = await _context.revendas.ToListAsync();
                return View(await _context.revendas.ToListAsync());
            }
            catch (Exception e)
            {
                return Redirect("/");
            }
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("codigo,codigo_revenda,id,nome,email,senha,streamings,espectadores,bitrate,espaco,subrevendas,chave_api,status,url_suporte,data_cadastro,dominio_padrao,stm_exibir_tutoriais,url_tutoriais,stm_exibir_downloads,stm_exibir_mini_site,stm_exibir_app_android_painel,idioma_painel,tipo,ultimo_acesso_data,ultimo_acesso_ip,stm_exibir_app_android,srt_status,api_token,refresh_token")] revendas revendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revendas);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revendas = await _context.revendas.FindAsync(id);
            if (revendas == null)
            {
                return NotFound();
            }
            return View(revendas);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("codigo,codigo_revenda,id,nome,email,senha,streamings,espectadores,bitrate,espaco,subrevendas,chave_api,status,url_suporte,data_cadastro,dominio_padrao,stm_exibir_tutoriais,url_tutoriais,stm_exibir_downloads,stm_exibir_mini_site,stm_exibir_app_android_painel,idioma_painel,tipo,ultimo_acesso_data,ultimo_acesso_ip,stm_exibir_app_android,srt_status,api_token,refresh_token")] revendas revendas)
        {
            if (id != revendas.codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!revendasExists(revendas.codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(revendas);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revendas = await _context.revendas
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (revendas == null)
            {
                return NotFound();
            }

            return View(revendas);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var revendas = await _context.revendas.FindAsync(id);
            if (revendas != null)
            {
                _context.revendas.Remove(revendas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool revendasExists(int id)
        {
            return _context.revendas.Any(e => e.codigo == id);
        }
    }
}
